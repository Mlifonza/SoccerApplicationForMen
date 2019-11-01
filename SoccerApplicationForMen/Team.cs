using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Http;
using HtmlAgilityPack;
using System.Data;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class Team : Competition
    {
        Data_Organiser data = new Data_Organiser();
        public List<Team> TeamList;
        string constantUrl = "https://us.soccerway.com/";

        #region Properties

        public string nameOfTeam { get; set; }
        public string currentCompetition { get; set; }
        public string Country { get; set; }
        public int played { get; set; }
        public int position { get; set; }
        public int points { get; set; }
        public int wins { get; set; }
        public int lost { get; set; }
        public int draws { get; set; }
        public int goalDifference { get; set; }
        public int goalAgainst { get; set; }
        public int goalForward { get; set; }
        public string link { get; set; }

        #endregion

        #region Constructor

        public Team()
        {
            this.played = 0;
            this.position = 0;
            this.points = 0;
            this.wins = 0;
            this.lost = 0;
            this.draws = 0;
            this.goalDifference = 0;
            this.goalAgainst = 0;
        }

        #endregion

        #region Methods

        public void PopulateTeamObject(string pCountryName, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            //TeamList = new List<Team>() 
            //{
            //    new Team() { Name = pHomeTeam, Position = Position++, NumberOfTeams = NumberOfTeams++, CountryName = pCountryName },
            //    new Team() { Name = pAwayTeam, Position = Position++, NumberOfTeams = NumberOfTeams++, CountryName = pCountryName }
            //};
        }

        //Populate the log standings in each Competition
        public void PopulateLog(string pTeamName, string pCountry, string pCompetition, string pLink,
            int pW, int pL, int pD, int pPos, int pMP, int pGA, int pGF, string pGD, int pPoints)
        {
            
            using (IDbConnection conn = data.Connection())
            {
                var retval = conn.Query<string>("sp_PopulateLog",
                    new
                    {
                        country = pCountry,
                        currentCompetition = pCompetition,
                        nameOfTeam = pTeamName,
                        wins = pW,
                        draws = pD,
                        lost = pL,
                        position = pPos,
                        points = pPoints,
                        played = pMP,
                        goalAgainst = pGA,
                        goalForward = pGF,
                        goalDifference = pGD,
                        link = pLink
                    }, commandType: CommandType.StoredProcedure).ToList();

                Debug.WriteLine("TEAM at " + DateTime.Now + " Result: " + retval[0].ToString().ToUpper());
            }
            //    using (SampleDataDataContext DbData = new SampleDataDataContext())
            //    {
            //        Team getRow = DbData.TEAMs.SingleOrDefault(x => ((x.country == pCountry) &&
            //                (x.currentCompetition == pCompetition)) && (x.nameOfTeam == pTeamName));

            //        Team newTeam = new Team 
            //        {
            //            country = pCountry,
            //            currentCompetition = pCompetition,
            //            nameOfTeam = pTeamName,
            //            wins = pW,
            //            draws = pD,
            //            lost = pL,
            //            position = pPos,
            //            points = pPoints,
            //            played = pMP,
            //            goalAgainst = pGA,
            //            goalForward = pGF,
            //            goalDifference = pGD,
            //            link = pLink
            //        };
            //        if (getRow == null)
            //        {
            //            try
            //            {
            //                Team newHomeTeam = new Team()
            //                {
            //                    country = pCountry,
            //                    currentCompetition = pCompetition,
            //                    nameOfTeam = pTeamName,
            //                    wins = pW,
            //                    draws = pD,
            //                    lost = pL,
            //                    position = pPos,
            //                    points = pPoints,
            //                    played = pMP,
            //                    goalAgainst = pGA,
            //                    goalForward = pGF,
            //                    goalDifference = pGD,
            //                    link = pLink
            //                };
            //                DbData.TEAMs.InsertOnSubmit(newHomeTeam);
            //                DbData.SubmitChanges();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("An error occurred while inserting team..\n" + ex.Message);
            //            }
            //        }
            //        else if (!getRow.Equals(newTeam))
            //        {
            //            try
            //            {
            //                getRow.link = pLink;
            //                getRow.wins = pW;
            //                getRow.draws = pD;
            //                getRow.lost = pL;
            //                getRow.position = pPos;
            //                getRow.points = pPoints;
            //                getRow.played = pMP;
            //                getRow.goalAgainst = pGA;
            //                getRow.goalForward = pGF;
            //                getRow.goalDifference = pGD;

            //                DbData.SubmitChanges();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show("An error occurred while update log team...\n" + ex.Message);
            //            }
            //        }
            //    }
            }

            //Generate points to all the teams
            public async void GeneratePoints()
        {
            int teamRank = 0;
            int totalPoints = 0;
            string teamName = "";
            string teamLink = "";
            int matchPlayed = 0;
            int totalWon = 0;
            int totalLost = 0;
            int totalDrawn = 0;
            int totalGoalAgainst = 0;
            int totalGoalForward = 0;
            string totalGoalDifference = "";
            using (IDbConnection conn = data.Connection())
            {
                var competition = conn.Query<Team>("SELECT * FROM [Football].[dbo].[COMPETITION]").ToList();

                foreach (var competitionItem in competition)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string html = await httpClient.GetStringAsync(constantUrl + competitionItem.link);

                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);

                        List<HtmlNode> TeamsNode = htmlDocument.DocumentNode.Descendants("tr")
                            .Where(node => (node.GetAttributeValue("id", "")
                            .Contains("team_rank"))).ToList();


                        foreach (HtmlNode teamsNodeItem in TeamsNode)
                        {
                            List<HtmlNode> teamRankNode = GetNode("rank", teamsNodeItem);
                            if (teamRankNode.Count != 0)
                            {
                                teamRank = Int16.Parse(teamRankNode[0].InnerText);
                            }

                            List<HtmlNode> teamNameNode = GetNode("text team", teamsNodeItem);
                            if (teamNameNode.Count != 0)
                            {
                                teamName = teamNameNode[0].InnerText;
                                teamLink = teamNameNode[0].Element("a").GetAttributeValue("href", "");
                            }

                            List<HtmlNode> matchPlayedNode = GetNode("total mp", teamsNodeItem);
                            if (matchPlayedNode.Count != 0)
                            {
                                matchPlayed = Int16.Parse(matchPlayedNode[0].InnerText);
                            }

                            List<HtmlNode> totalWonNode = GetNode("total won", teamsNodeItem);
                            if (totalWonNode.Count != 0)
                            {
                                totalWon = Int16.Parse(totalWonNode[0].InnerText);
                            }

                            List<HtmlNode> totalLostNode = GetNode("total lost", teamsNodeItem);
                            if (totalLostNode.Count != 0)
                            {
                                totalLost = Int16.Parse(totalLostNode[0].InnerText);
                            }

                            List<HtmlNode> totalDrawnNode = GetNode("total drawn", teamsNodeItem);
                            if (totalDrawnNode.Count != 0)
                            {
                                totalDrawn = Int16.Parse(totalDrawnNode[0].InnerText);
                            }

                            List<HtmlNode> totalGoalAgainstNode = GetNode("total ga", teamsNodeItem);
                            if (totalGoalAgainstNode.Count != 0)
                            {
                                totalGoalAgainst = Int16.Parse(totalGoalAgainstNode[0].InnerText);
                            }

                            List<HtmlNode> totalGoalForwardNode = GetNode("total gf", teamsNodeItem);
                            if (totalGoalForwardNode.Count != 0)
                            {
                                totalGoalForward = Int16.Parse(totalGoalForwardNode[0].InnerText);
                            }

                            List<HtmlNode> totalGoalDifferenceNode = GetNode("number gd", teamsNodeItem);
                            if (totalGoalDifferenceNode.Count != 0)
                            {
                                totalGoalDifference = totalGoalDifferenceNode[0].InnerText;
                            }

                            List<HtmlNode> totalPointsNode = GetNode("number points", teamsNodeItem);
                            if (totalPointsNode.Count != 0)
                            {
                                totalPoints = Int16.Parse(totalPointsNode[0].InnerText);
                            }

                            PopulateLog(teamName, competitionItem.country, competitionItem.titleOfCompetition, teamLink,
                                totalWon, totalLost, totalDrawn, teamRank, matchPlayed, totalGoalAgainst, totalGoalForward,
                                totalGoalDifference, totalPoints);
                        }
                    }
                    catch (TaskCanceledException tex)
                    {
                        continue;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                    string test = "";
                }
            }
        }

        public List<HtmlNode> GetNode(string attrValue, HtmlNode pNode)
        {
            List<HtmlNode> value = pNode.Descendants("td")
                            .Where(node => (node.GetAttributeValue("class", "")
                            .Contains(attrValue))).ToList();

            return value;
        }

        #endregion

    }
}
