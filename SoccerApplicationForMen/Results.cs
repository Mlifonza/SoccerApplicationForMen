using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net.Http;
using System.Data;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class Results : Competition
    {
        //Data_Organiser data = new Data_Organiser();
        
        string constantUrl = Data_Organiser.constantUrl;
        public enum OptionState { Fixture, Result }
        public enum ResultState { Draw, HomeWin, AwayWin, POSTPONED, CANCELLED, UNDEFINED }
        #region Properties

        //List<Results> resultList = new List<Results>();
        public string DateOfMatch { get; set; }
        public string TimeOfMatch { get; set; }
        public int Round { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int MatchState { get; set; }
        private string fileName = @"C:\Users\Lifa\Documents\visual studio 2013\Projects\SoccerApplicationForMen\SoccerApplicationForMen\Resources\Football Results";
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        private int numOfRowsToSkip = 4;
        public int NumOfRowsToSkip
        {
            get
            {
                return numOfRowsToSkip;
            }
            set
            {
                numOfRowsToSkip = value;
            }
        }

        //private int groupLoop = 5;
        //public int GroupLoop
        //{
        //    get
        //    {
        //        return groupLoop;
        //    }
        //    set
        //    {
        //        groupLoop = value;
        //    }
        //}

        //public enum ResultState { Draw, HomeWin, AwayWin, Posponed }

        #endregion

        #region Methods

        public void InsertResults(string pHomeTeam, string pAwayTeam, DateTime pDate, string pCountry,
                                    string pCOMPETITION, string pHomeScore, string pAwayScore, string state)
        {
            Data_Organiser data = new Data_Organiser();

            using (IDbConnection conn = data.Connection())
            {
                var value = conn.Query<bool>("sp_InsertResults",
                    new
                    {
                        Country = pCountry,
                        Competition = pCOMPETITION,
                        DateOfmatch = pDate,
                        HomeTeam = pHomeTeam,
                        AwayTeam = pAwayTeam,
                        HomeTeamScore = pHomeScore,
                        AwayTeamScore = pAwayScore,
                        MatchState = state
                    }, commandType: CommandType.StoredProcedure).ToList();

                Debug.WriteLine("Match RESULTS at " + DateTime.Now + " Result: " + value[0].ToString().ToUpper());
            }
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    RESULT result = DbData.RESULTs.SingleOrDefault(x => (x.homeTeam == pHomeTeam) && (x.awayTeam == pAwayTeam)
            //                    && (x.dateOfmatch == pDate));
            //    if (result == null)
            //    {
            //        try
            //        {
            //            RESULT newResult = new RESULT()
            //            {
            //                country = pCountry,
            //                competition = pCOMPETITION,
            //                dateOfmatch = pDate,
            //                timeOfMatch = "unavailable",
            //                homeTeam = pHomeTeam,
            //                awayTeam = pAwayTeam,
            //                homeTeamScore = pHomeScore,
            //                awayTeamScore = pAwayScore,
            //                matchState = state
            //            };

            //            DbData.RESULTs.InsertOnSubmit(newResult);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred while inserting results..\n" + sql.Message);
            //        }
            //    }
            //}
        }

        //This method recieves the the team that won
        public void GetTeamWhoWon()
        {
            CompetitionStats compStats = new CompetitionStats();

            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    IEnumerable<RESULT> results = DbData.RESULTs.Select(r => (r));

            //    foreach (RESULT resultItem in results)
            //    {
            //        string homeTeam = resultItem.homeTeam;
            //        string awayTeam = resultItem.awayTeam;
            //        string country = resultItem.country;
            //        string competition = resultItem.competition;
            //        string time = resultItem.timeOfMatch;
            //        DateTime date = resultItem.dateOfmatch;
            //        string matchState = resultItem.matchState;
            //        string homeState = "";
            //        string awayState = "";

            //        if (matchState.Equals("HomeWin"))
            //        {
            //            homeState = "WON";
            //            awayState = "LOST";
            //        }
            //        else if (matchState.Equals("AwayWin"))
            //        {
            //            homeState = "LOST";
            //            awayState = "WON";
            //        }
            //        else
            //        {
            //            homeState = "DRAW";
            //            awayState = "DRAW";
            //        }

            //        //Insert home time from RESULTS
            //        compStats.InsertCompetitionStats(homeTeam, country, competition, time, date, homeState);
            //        //Insert away time from RESULTS
            //        compStats.InsertCompetitionStats(awayTeam, country, competition, time, date, awayState);
            //    }
            //}
        }

        public Tuple<string, string, string, string> GetMatchData(HtmlAgilityPack.HtmlNode MatchListItem)
        {
            Tuple<string, string, string> newTuple;
            string date = MatchListItem.Descendants("td")
                        .Where(node => (node.GetAttributeValue("class", "")
                        .Contains("date"))).FirstOrDefault().InnerText.Trim();

            string day = date.Substring(0, date.IndexOf('/'));
            string month = date.Substring(date.IndexOf('/') + 1, 2);
            string year = date.Substring(date.LastIndexOf('/') + 1, 2);
            string testString = date.Remove(date.LastIndexOf('/') + 1, 2);
            date = month + "/" + day + "/" + "20" + year;
            //DateTime evaluatedDate = Convert.ToDateTime(date);

            string homeTeam = MatchListItem.Descendants("td")
            .Where(node => (node.GetAttributeValue("class", "")
            .Contains("team-a"))).FirstOrDefault().InnerText.Trim();

            string awayTeam = MatchListItem.Descendants("td")
                .Where(node => (node.GetAttributeValue("class", "")
                .Contains("team-b"))).FirstOrDefault().InnerText.Trim();

            string score = MatchListItem.Descendants("td")
                .Where(node => (node.GetAttributeValue("class", "")
                .Contains("score-time"))).FirstOrDefault().InnerText.Trim();

            return new Tuple<string, string, string, string>(date, homeTeam, awayTeam, score);
        }

        public async void FullUpdateOfResults()
        {
            int countTimeout = 0;
            RecalledMatch reviewedMatch = new RecalledMatch();
            Data_Organiser dor = new Data_Organiser();
            Fixture fixture = new Fixture();

            using (IDbConnection conn = dor.Connection())
            {
                try
                {
                    var links = conn.Query<Team>("  SELECT * FROM [Football].[dbo].[TEAM]");
                    foreach (Team linksItem in links)
                    {
                        HttpClient httpClient = new HttpClient();
                        String html = await httpClient.GetStringAsync(constantUrl + linksItem.link);

                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);

                        List<HtmlNode> MatchHtml = htmlDocument.DocumentNode.Descendants("tr")
                    .Where(node => (node.GetAttributeValue("id", "")
                    .Contains("page_team_1_block_team_matches"))).ToList();

                        foreach (HtmlNode MatchListItem in MatchHtml)
                        {
                            string date = GetMatchData(MatchListItem).Item1;
                            DateTime evaluatedDate = Convert.ToDateTime(date);

                            string homeTeam = GetMatchData(MatchListItem).Item2;

                            string awayTeam = GetMatchData(MatchListItem).Item3;

                            string score = GetMatchData(MatchListItem).Item4;

                            string homeScore = "";
                            string awayScore = "";
                            ResultState state = ResultState.UNDEFINED;
                            OptionState optionState = OptionState.Result;
                            string time = "";
                            if (dor.IsSubstringable(score, ref homeScore, ref awayScore) && score.Contains(':'))
                            {
                                optionState = OptionState.Fixture;
                                time = score;
                                //dor.SlicingData(linksItem.country, linksItem.currentCompetition, evaluatedDate, homeTeam, awayTeam,
                                //            homeScore, awayScore, OptionState.Fixture.ToString(), score);
                                fixture.InsertFixture(linksItem.country, linksItem.currentCompetition, homeTeam, awayTeam, evaluatedDate, score);
                            }
                            else if (dor.IsSubstringable(score, ref homeScore, ref awayScore) && score.Contains('P') || score.Contains('E') || score.Contains("PSTP"))
                            {
                                state = ResultState.POSTPONED;
                                reviewedMatch.InsertRecalledMatch(linksItem.country, linksItem.currentCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                            else if (dor.IsSubstringable(score, ref homeScore, ref awayScore) && score == "CANC")
                            {
                                state = ResultState.CANCELLED;
                                reviewedMatch.InsertRecalledMatch(linksItem.country, linksItem.currentCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                            else if (dor.IsSubstringable(score, ref homeScore, ref awayScore) && dor.IsNumber(homeScore, awayScore))
                            {
                                optionState = OptionState.Result;
                                dor.SlicingData(linksItem.country, linksItem.currentCompetition, evaluatedDate, homeTeam, awayTeam,
                                            homeScore, awayScore, OptionState.Result.ToString(), time);
                            }
                            else
                            {
                                state = ResultState.UNDEFINED;
                                reviewedMatch.InsertRecalledMatch(linksItem.country, linksItem.currentCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                        }
                    }
                }
                catch (TaskCanceledException tex)
                {
                    Debug.WriteLine("\n" + tex.Message + " " + DateTime.Now + "\n");
                    FullUpdateOfResults();
                    //countTimeout++;
                    //if (countTimeout >= 5)
                    //{
                        
                    //}
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("\n" + ex.Message + " " + DateTime.Now + "\n");
                    //FullUpdateOfResults();
                    //reviewedMatch.InsertRecalledMatch("COUNTRY", "COMPETITION", DateTime.Now,
                    //                "HOME", "AWAY", "UNDEFINED");
                }
            }
        }

        //public List<RESULT> GetResults(DateTime pDate)
        //{
        //    using (SampleDataDataContext DbData = new SampleDataDataContext())
        //    {
        //        if (!resultList.Equals(null))
        //        {
        //            resultList.Clear();
        //        }

        //        IEnumerable<EVALUATED_RESULT> EVResults = DbData.EVALUATED_RESULTs.Select(x => (x)).OrderByDescending(y => (y.dateOfmatch));
        //        int count = 0;
        //        foreach (EVALUATED_RESULT getResult in EVResults)
        //        {
        //            RESULT matchResult = DbData.RESULTs.SingleOrDefault(x => (x.homeTeam.Equals(getResult.homeTeam) && (x.awayTeam.Equals(getResult.awayTeam)
        //                                              && (x.dateOfmatch.Equals(getResult.dateOfmatch) && (x.timeOfMatch.Equals(getResult.timeOfMatch))))));
        //            count++;
        //            resultList.Add(matchResult);
        //        }
        //        MessageBox.Show(count.ToString());
        //        return resultList;
        //    }
        //}

        #endregion
    }
}
