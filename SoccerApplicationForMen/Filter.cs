using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Dapper;

namespace SoccerApplicationForMen
{
    public class Filter
    {
        Data_Organiser dor = new Data_Organiser();
        #region Variables



        #endregion
        #region Properties

        internal List<Team> homeWinner = new List<Team>();
        internal List<Team> homeLoser = new List<Team>();
        internal List<Team> awayWinner = new List<Team>();
        internal List<Team> awayLoser = new List<Team>();
        internal List<Team> onFormWinner = new List<Team>();
        internal List<Team> onFormLoser = new List<Team>();
        internal List<Team> regularDrawer = new List<Team>();
        internal List<Team> regularHomeDrawer = new List<Team>();
        internal List<Team> regularAwayDrawer = new List<Team>();
        internal List<Team> regularScorer = new List<Team>();
        internal List<Team> regularCleanSheeter = new List<Team>();
        internal List<Team> seasonPerformer = new List<Team>();
        internal List<Team> topBottom = new List<Team>();
        internal List<Team> getTeamStats = new List<Team>();
        
        public string Date { get; set; }
        public double Wins { get; set; }

        #endregion

        #region Methods

        public List<Team> GetRegularScorer(int pGamesToCount)
        {
            using (IDbConnection conn = dor.Connection())
            {
                IEnumerable<Team> team = conn.Query<Team>(@"SELECT * FROM [dbo].[TEAM]");
                //Go Through all the teams in the TEAMs table
                foreach (Team selectedTeam in team)
                {
                    int totalHomeGamesPlayed = 0;
                    int countScore = 0;
                    string teamName = selectedTeam.nameOfTeam;
                    string competition = selectedTeam.currentCompetition;
                    string country = selectedTeam.country;
                    int totalGamesToCount = pGamesToCount;
                    int countWins = 0;
                    //Team must atleast have played 5 games
                    const int TOTALNUMBER = 5;
                    //Retrieve all the results from the stored procedure
                    var evResults = conn.Query<Results>(@"SELECT * FROM [dbo].[RESULTS] WHERE [homeTeam]=@teamName OR [awayTeam]=@teamName
                                                        [country]=@country AND [competition]=@competition",
                                                        new
                                                            {
                                                                teamName = teamName,
                                                                country = country,
                                                                competition = competition
                                                            }).ToList();
                    //List<Results> evResults = DbData.RESULTs.Where(r => ((r.homeTeam.Equals(teamName) || r.awayTeam.Equals(teamName))
                    //    && (r.country.Equals(country) && r.competition.Equals(competition))))
                    //    .Select(x => (x)).ToList();

                    //Get how many of those games the team scored
                    countScore = evResults.FindAll(x => (x.HomeTeamScore) > 0 || (x.AwayTeamScore > 0)).Count;

                    if (countScore >= totalGamesToCount && selectedTeam.played > TOTALNUMBER)
                    {
                        //MessageBox.Show("Total Home Games: " + totalHomeGamesPlayed + "\nTotal Home Wins: " + countHomeWins + "\n" + selectedTeam.nameOfTeam);
                        regularScorer.Add(selectedTeam);
                    }
                }
            }

            return regularScorer;
        }

        //public List<Team> GetHomeWinner(int pGamesToWin)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToWin;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<vwHomeGame> evResults = DbData.vwHomeGames
        //                .Where(x => (x.homeTeam.Equals(teamName) && x.competition.Equals(competition) && x.country.Equals(country)))
        //                .Select(x => (x)).ToList();

        //            //Count the number home games won
        //            countHomeWins = evResults.FindAll(x => (x.matchState.Equals("WON"))).Count;

        //            if (countHomeWins >= totalGamesToWin && selectedTeam.played > TOTALNUMBER)
        //            {
        //                homeWinner.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return homeWinner;
        //}

        //public List<Team> GetAwayWinner(int pGamesToWin)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToWin;
        //            int countWins = 0;
        //            string gameState = "WIN";
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            ToSearchAwayGames(DbData, selectedTeam, countHomeWins, teamName, competition,
        //                country, totalGamesToWin, TOTALNUMBER, gameState);
        //        }
        //    }

        //    return awayWinner;
        //}

        //private int ToSearchAwayGames(SampleDataDataContext DbData, Team selectedTeam, int countHomeWins, string teamName,
        //    string competition, string country, int totalGamesToWin, int TOTALNUMBER, string pGameState)
        //{
        //    List<vwAwayGame> evResults = DbData.vwAwayGames
        //        .Where(x => (x.awayTeam.Equals(teamName) && x.competition.Equals(competition) && x.country.Equals(country)))
        //        .Select(x => (x)).ToList();

        //    //Count the number home games won
        //    countHomeWins = evResults.FindAll(x => (x.matchState.Equals(pGameState))).Count;

        //    if (countHomeWins >= totalGamesToWin && selectedTeam.played > TOTALNUMBER)
        //    {
        //        awayWinner.Add(selectedTeam);
        //    }
        //    return countHomeWins;
        //}

        //public List<Team> GetOnFormWinner(int pGamesToWin)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToWin;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<COMPETITION_STAT> compStat = DbData.spTeamsForm(teamName, competition, country).ToList();

        //            //Count the number home games won
        //            countWins = compStat.FindAll(x => (x.matchState.Equals("WON"))).Count;

        //            if (countWins >= totalGamesToWin && selectedTeam.played >= TOTALNUMBER)
        //            {
        //                onFormWinner.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return onFormWinner;
        //}

        //public List<Team> GetOnFormLoser(int pGamesToLose)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToLose = pGamesToLose;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<COMPETITION_STAT> compStat = DbData.spTeamsForm(teamName, competition, country).ToList();

        //            //Count the number home games won
        //            countWins = compStat.FindAll(x => (x.matchState.Equals("LOST"))).Count;

        //            if (countWins >= totalGamesToLose && selectedTeam.played >= TOTALNUMBER)
        //            {
        //                onFormLoser.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return onFormLoser;
        //}

        //public List<Team> GetHomeLoser(int pHomeGamesToLose)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToLose = pHomeGamesToLose;
        //            int countWins = 0;
        //            //The state of the matches to search for
        //            string gameState = "LOST";
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            ToSearchAwayGames(DbData, selectedTeam, countHomeWins, teamName, competition,
        //                country, totalGamesToLose, TOTALNUMBER, gameState);
        //        }
        //    }

        //    return homeLoser;
        //}

        //public List<Team> GetAwayLoser(int pGamesToLose)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToLose;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<vwAwayGame> evResults = DbData.vwAwayGames
        //                .Where(x => (x.awayTeam.Equals(teamName) && x.competition.Equals(competition) && x.country.Equals(country)))
        //                .Select(x => (x)).ToList();

        //            //Count the number home games won
        //            countHomeWins = evResults.FindAll(x => (x.matchState.Equals("LOST"))).Count;

        //            if (countHomeWins >= totalGamesToWin && selectedTeam.played > TOTALNUMBER)
        //            {
        //                //MessageBox.Show("Total Home Games: " + totalHomeGamesPlayed + "\nTotal Home Wins: " + countHomeWins + "\n" + selectedTeam.nameOfTeam);
        //                awayLoser.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return awayLoser;
        //}

        //public List<Team> GetRegularDrawer(int pGamesToDrawCount)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToDrawCount;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<COMPETITION_STAT> compStat = DbData.spTeamsForm(teamName, competition, country).ToList();

        //            //Count the number home games won
        //            countWins = compStat.FindAll(x => (x.matchState.Equals("DRAW"))).Count;

        //            if (countWins >= totalGamesToWin && selectedTeam.played >= TOTALNUMBER)
        //            {
        //                regularDrawer.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return regularDrawer;
        //}

        //public List<Team> GetRegularHomeDrawer(int pGamesToDrawCount)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToDrawCount;
        //            int countWins = 0;
        //            //The state of the matches to search for
        //            string gameState = "DRAW";
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;

        //            ToSearchHomeGames(DbData, selectedTeam, countHomeWins, teamName, competition,
        //                country, totalGamesToWin, TOTALNUMBER, gameState);
        //        }
        //    }

        //    return regularHomeDrawer;
        //}

        //public List<Team> GetAwayDrawer(int pGamesToDraw)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countHomeWins = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToDraw;
        //            int countWins = 0;
        //            string gameState = "DRAW";
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            ToSearchAwayGames(DbData, selectedTeam, countHomeWins, teamName, competition,
        //                country, totalGamesToWin, TOTALNUMBER, gameState);
        //        }
        //    }

        //    return regularAwayDrawer;
        //}

        //public List<Team> GetRegularCleanSheets(int pGamesToCount)
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        IEnumerable<Team> team = DbData.TEAMs.Select(x => (x));
        //        //Go Through all the teams in the TEAMs table
        //        foreach (Team selectedTeam in team)
        //        {
        //            int totalHomeGamesPlayed = 0;
        //            int countCleanSheets = 0;
        //            string teamName = selectedTeam.nameOfTeam;
        //            string competition = selectedTeam.currentCompetition;
        //            string country = selectedTeam.country;
        //            int totalGamesToWin = pGamesToCount;
        //            int countWins = 0;
        //            //Team must atleast have played 5 games
        //            const int TOTALNUMBER = 5;
        //            //Retrieve all the results from the stored procedure
        //            List<Results> evResults = DbData.RESULTs
        //                .Where(x => (Convert.ToInt64(x.homeTeamScore) == 0 || Convert.ToInt64(x.awayTeamScore) == 0))
        //                .Select(x => (x)).ToList();

        //            List<Results> homeRecord = evResults
        //                .Where(x => (x.homeTeam.Equals(teamName) && Convert.ToInt64(x.homeTeamScore) == 0))
        //                .Select(h => (h))
        //                .OrderByDescending(o => (o.dateOfmatch)).ToList();


        //            List<Results> awayRecord = evResults
        //                .Where(x => (x.awayTeam.Equals(teamName) && Convert.ToInt64(x.awayTeamScore) == 0))
        //                .Select(h => (h)).ToList();

        //            //Count the number home games won
        //            countCleanSheets = homeRecord.Count + awayRecord.Count;
        //            string test = "";
        //            if (countCleanSheets >= totalGamesToWin && selectedTeam.played > TOTALNUMBER)
        //            {
        //                regularCleanSheeter.Add(selectedTeam);
        //            }
        //        }
        //    }

        //    return regularCleanSheeter;
        //}

        public List<Team> GetSeasonPerformer(int pAveWinLose)
        {
            using (IDbConnection conn = dor.Connection())
            {
                DateTime date = FixtureControl.selectedDate;
                GamePlay game = new GamePlay();
                List<GamePlay> gameList = game.GetFixture(date).FindAll(g => (g.HomeWins >= pAveWinLose || g.AwayWins >= pAveWinLose ||
                    g.HomeLosses >= pAveWinLose || g.AwayLosses >= pAveWinLose || g.HomeDraws >= pAveWinLose || g.AwayDraws >= pAveWinLose));

                foreach (GamePlay gameItem in gameList)
                {
                    Team homeTeam = conn.Query<Team>(@"SELECT * FROM [dbo].[TEAM] WHERE [nameOfTeam]=@nameOfTeam AND 
                                                    [country]=@country AND [currentCompetition]=@currentCompetition",
                                                    new
                                                        {
                                                            nameOfTeam = gameItem.HomeTeam,
                                                            country = gameItem.Country,
                                                            currentCompetition = gameItem.Competition
                                                        }).FirstOrDefault();
                    Team awayTeam = conn.Query<Team>(@"SELECT * FROM [dbo].[TEAM] WHERE [nameOfTeam]=@nameOfTeam AND 
                                                    [country]=@country AND [currentCompetition]=@currentCompetition",
                                                    new
                                                    {
                                                        nameOfTeam = gameItem.AwayTeam,
                                                        country = gameItem.Country,
                                                        currentCompetition = gameItem.Competition
                                                    }).FirstOrDefault();
                    //Team homeTeam = DbData.TEAMs.SingleOrDefault(t => (t.nameOfTeam.Equals(gameItem.HomeTeam) &&
                    //    t.country.Equals(gameItem.Country) && t.currentCompetition.Equals(gameItem.Competition)));
                    //Team awayTeam = DbData.TEAMs.SingleOrDefault(t => (t.nameOfTeam.Equals(gameItem.AwayTeam) &&
                    //    t.country.Equals(gameItem.Country) && t.currentCompetition.Equals(gameItem.Competition)));

                    seasonPerformer.Add(homeTeam);
                    seasonPerformer.Add(awayTeam);
                }
            }

            return seasonPerformer;
        }

        //public List<Team> GetTopBottom()
        //{
        //    using (IDbConnection conn = dor.Connection())
        //    {
        //        DateTime date = FixtureControl.selectedDate;

        //        List<COMPETITION> comp = DbData.COMPETITIONs
        //            .Where(x => !(x.titleOfCompetition.Contains("cup") || x.titleOfCompetition.Contains("copa") ||
        //                x.titleOfCompetition.Contains("qualif")))
        //            .Select(c => (c)).ToList();
        //        List<FIXTURE> fixture = DbData.FIXTUREs
        //            .Where(f => (f.dateOfmatch.Equals(date)))
        //            .Select(x => (x))
        //            .OrderBy(o => (o.country)).ToList();
        //        List<Team> teamToCampture = new List<Team>();

        //        foreach (COMPETITION compItem in comp)
        //        {
        //            int numOfTeams = DbData.TEAMs.
        //                Where(t => (t.country.Equals(compItem.country) &&
        //                    t.currentCompetition.Equals(compItem.titleOfCompetition))).Count();
        //            Team upperPosition = DbData.TEAMs
        //                .First(t => (t.position.Equals(1) && t.country.Equals(compItem.country) &&
        //                    t.currentCompetition.Equals(compItem.titleOfCompetition)));
        //            Team lowerPosition = DbData.TEAMs
        //                .First(t => (t.position.Equals(numOfTeams) && t.country.Equals(compItem.country) &&
        //                    t.currentCompetition.Equals(compItem.titleOfCompetition)));
        //            teamToCampture.AddRange(new Team[]
        //            {
        //                upperPosition,
        //                lowerPosition
        //            });

        //            string test = "";
        //        }
        //    }

        //    return topBottom;
        //}

        //private void ToSearchHomeGames(SampleDataDataContext DbData, Team selectedTeam, int countHomeWins, string teamName, string competition,
        //    string country, int totalGamesToWin, int TOTALNUMBER, string pGameState)
        //{
        //    //Retrieve all the results from the stored procedure
        //    List<vwHomeGame> evResults = DbData.vwHomeGames
        //        .Where(x => (x.homeTeam.Equals(teamName) && x.competition.Equals(competition) && x.country.Equals(country)))
        //        .Select(x => (x)).ToList();

        //    //Count the number home games won
        //    countHomeWins = evResults.FindAll(x => (x.matchState.Equals(pGameState))).Count;

        //    if (countHomeWins >= totalGamesToWin && selectedTeam.played > TOTALNUMBER)
        //    {
        //        regularHomeDrawer.Add(selectedTeam);
        //    }
        //}

        public List<Team> GetTeamStats(int pPlayed, int pWins, int pLosses, int pDraws, string pStatType)
        {
            using (IDbConnection conn = dor.Connection())
            {
                //TODO
            }

            return getTeamStats;
        }

        private void GetStat(int pPlayed, string pStatType)
        {
            var lambda = "<";
            int.Parse(lambda);
        }

        public bool ShowMatch(Fixture pFixture, string condition)
        {
            bool value = true;

            return value;
        }

        #endregion
    }
}
