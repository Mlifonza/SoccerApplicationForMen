using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SoccerApplicationForMen
{
    public class GamePlay
    {
        Data_Organiser data = new Data_Organiser();
        #region Properties

        ArrayList gameList = new ArrayList();
        public List<GamePlay> player = new List<GamePlay>();
        public string HomeTeam { get; set; }
        public double HomeWins { get; set; }
        public double HomeLosses { get; set; }
        public double HomeDraws { get; set; }

        public string AwayTeam { get; set; }
        public double AwayWins { get; set; }
        public double AwayLosses { get; set; }
        public double AwayDraws { get; set; }

        public string Country { get; set; }
        public string Competition { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string HomePrediction { get; set; }
        public string AwayPrediction { get; set; }

        #endregion

        #region Constructor

        //public GamePlay(string pHomePrediction, string pAwayPrediction, string pDate, double pHomeWins, double pHomeLosses, double pHomeDraws,
        //                double pAwayWins, double pAwayLosses, double pAwayDraws)
        //{
        //    this.HomePrediction = pHomePrediction;
        //    this.AwayPrediction = pAwayPrediction;
        //    this.Date = pDate;
        //    this.HomeWins = pHomeWins;
        //    this.HomeLosses = pHomeLosses;
        //    this.HomeDraws = pHomeDraws;
        //    this.AwayWins = pAwayWins;
        //    this.AwayLosses = pAwayLosses;
        //    this.AwayDraws = pAwayDraws;
            
        //}

        #endregion

        public virtual List<GamePlay> GetFixture(DateTime pDate)
        {
            using (IDbConnection conn = data.Connection())
            {
                IEnumerable<Fixture> fixture = conn.Query<Fixture>("sp_GetFixture",
                    new { DateOfmatch = pDate }, commandType: CommandType.StoredProcedure).ToList();
                //IEnumerable<Fixture> fixture = DbData.FIXTUREs
                //    .Where(game => (game.dateOfmatch.Equals(pDate) && (!game.competition.Contains("copa")
                //     && !game.competition.Contains("cup"))))
                //    .OrderByDescending(team => (team.timeOfMatch)).Select(team => (team));

                //Go through each fixture
                foreach (Fixture match in fixture)
                {
                    //Copy the team's form statement
                    player.Add(GetTeamsForm(match));
                    player.Remove(null);
                }
                string test = "";
                return player;
            }
        }

        public GamePlay GetTeamsForm(Fixture pFixture)
        {
            Fixture fixture = pFixture;
            string country = pFixture.country;
            string league = pFixture.competition;
            string homeTeam = pFixture.homeTeam;
            string awayTeam = pFixture.awayTeam;
            string matchResult;

            using (IDbConnection conn = data.Connection())
            {
                Team home = conn.Query<Team>("sp_GetTeamsForm_Home",
                    new { 
                            homeTeam = homeTeam,
                            currentCompetition = league,
                            country = country
                        }, commandType: CommandType.StoredProcedure).SingleOrDefault();

                Team away = conn.Query<Team>("sp_GetTeamsForm_Away",
                    new
                    {
                        awayTeam = awayTeam,
                        currentCompetition = league,
                        country = country
                    }, commandType: CommandType.StoredProcedure).SingleOrDefault();

                if (home != null && away != null)
                {
                    return CheckSimilarPattern(new Tuple<int, int, int, int>(home.played, home.wins, home.lost, home.draws),
                     new Tuple<int, int, int, int>(away.played, away.wins, away.lost, away.draws), fixture);
                }
                else
                {
                    return null;
                }
            }
        }

        public GamePlay CheckSimilarPattern(Tuple<int, int, int, int> pHomeTuple, Tuple<int, int, int, int> pAwayTuple, Fixture pFixture)
        {
            Fixture fixture = pFixture;

            int homePlayed = pHomeTuple.Item1;
            int awayPlayed = pAwayTuple.Item1;
            int homeWins = pHomeTuple.Item2;
            int awayWins = pAwayTuple.Item2;
            int homeLoses = pHomeTuple.Item3;
            int awayLoses = pAwayTuple.Item3;
            int homeDraws = pHomeTuple.Item4;
            int awayDraws = pAwayTuple.Item4;

            //Change the number to a double
            double homePlayedDouble = Convert.ToDouble(string.Format("{0:0.0}", homePlayed));
            double homeWinsDouble = Convert.ToDouble(string.Format("{0:0.0}", homeWins));
            double homeLossesDouble = Convert.ToDouble(string.Format("{0:0.0}", homeLoses));
            double homeDrawsDouble = Convert.ToDouble(string.Format("{0:0.0}", homeDraws));

            double awayPlayedDouble = Convert.ToDouble(string.Format("{0:0.0}", awayPlayed));
            double awayWinsDouble = Convert.ToDouble(string.Format("{0:0.0}", awayWins));
            double awayLossesDouble = Convert.ToDouble(string.Format("{0:0.0}", awayLoses));
            double awayDrawDouble = Convert.ToDouble(string.Format("{0:0.0}", awayDraws));
            //Finds the percentage and rounds up the nearest decimal
            double countHomeWins = Convert.ToDouble(string.Format("{0:0}", ((homeWinsDouble) / (homePlayedDouble)) * 100));
            double countHomeLoses = Convert.ToDouble(string.Format("{0:0}", ((homeLossesDouble) / homePlayedDouble) * 100));
            double countHomeDraws = Convert.ToDouble(string.Format("{0:0}", ((homeDrawsDouble) / homePlayedDouble) * 100));

            double countAwayWins = Convert.ToDouble(string.Format("{0:0}", ((awayWinsDouble) / awayPlayedDouble) * 100));
            double countAwayLoses = Convert.ToDouble(string.Format("{0:0}", ((awayLossesDouble) / awayPlayedDouble) * 100));
            double countAwayDraws = Convert.ToDouble(string.Format("{0:0}", ((awayDrawDouble) / awayPlayedDouble) * 100));
            string test = "";

            return AppropriateFixture(fixture, countHomeWins, countHomeLoses, countHomeDraws, countAwayWins, countAwayLoses, countAwayDraws);
        }

        public GamePlay AppropriateFixture(Fixture pFixture, double pHomeWins, double pHomeLosses, double pHomeDraws, double pAwayWins,
                                            double pAwayLosses, double pAwayDraws)
        {
            string time = pFixture.timeOfMatch;
            DateTime date = pFixture.dateOfmatch;
            string homeTeam = pFixture.homeTeam;
            string awayTeam = pFixture.awayTeam;
            string country = pFixture.country;
            string competition = pFixture.competition;
            string stringToSendAway = "Unknown";
            string stringToSendHome = "Unknown";

            if ((pHomeWins > pAwayWins))
            {
                stringToSendHome = "WIN";
                stringToSendAway = "LOSE";
            }
            else if (pAwayWins > pHomeWins)
            {
                stringToSendHome = "LOSE";
                stringToSendAway = "WIN";
            }
            else if ((pHomeWins > pAwayWins) && (pHomeDraws == pAwayDraws))
            {
                stringToSendHome = "WIN/DRAW";
                stringToSendAway = "DRAW";
            }
            else if ((pAwayWins > pHomeWins) && (pHomeDraws == pAwayDraws))
            {
                stringToSendHome = "DRAW";
                stringToSendAway = "WIN/DRAW";
            }

            string show = homeTeam + "\tvs\t" + awayTeam;

            return new GamePlay()
            {
                HomeWins = pHomeWins,
                HomeLosses = pHomeLosses,
                HomeDraws = pHomeDraws,
                AwayWins = pAwayWins,
                AwayLosses = pAwayLosses,
                AwayDraws = pAwayDraws,
                HomePrediction = stringToSendHome,
                AwayPrediction = stringToSendAway,
                Country = country,
                Competition = competition,
                Date = date,
                Time = time,
                HomeTeam = homeTeam,
                AwayTeam = awayTeam
            };
        }

        //public List<string> PopulateCountrySettings()
        //{
        //    using (IDbConnection conn = data.Connection())
        //    {
        //        List<string> country = DbData.COUNTRies.Select(c => (c.country_Name)).ToList();

        //        return country;
        //    }
        //}

        //public void PopulateFavouriteCompetition()
        //{

        //}

        //public void RemoveCompetition(string pCountry, string pCompetition)
        //{

        //}
    }
}
