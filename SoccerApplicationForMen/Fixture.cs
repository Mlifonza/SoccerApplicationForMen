using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class Fixture : Competition
    {
        //Data_Organiser data = new Data_Organiser();
        #region Properties

        public string country { get; set; }
        public string competition { get; set; }
        public DateTime dateOfmatch { get; set; }
        public string timeOfMatch { get; set; }
        public int currentRound { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }
        public string fixtureState { get; set; }
        
        #endregion

        #region Methods

        public void Rematch(Results match)
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    FIXTURE newFixture = new FIXTURE()
            //    {
            //        country = match.country,
            //        competition = match.competition,
            //        homeTeam = match.homeTeam,
            //        awayTeam = match.awayTeam,
            //        dateOfmatch = match.dateOfmatch,
            //        timeOfMatch = match.timeOfMatch,
            //        fixtureState = "POSTPONED"
            //    };
                
            //    DbData.FIXTUREs.InsertOnSubmit(newFixture);
            //    DbData.SubmitChanges();
            //}
        }

        public void InsertFixture(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam, DateTime pDate, string pTime)
        {
            Data_Organiser data = new Data_Organiser();

            using (IDbConnection conn = data.Connection())
            {
                var value = conn.Query<bool>("sp_InsertFixture",
                    new
                    {
                        Country = pCountry,
                        Competition = pCompetition,
                        HomeTeam = pHomeTeam,
                        AwayTeam = pAwayTeam,
                        DateOfmatch = pDate,
                        TimeOfMatch = pTime,
                        FixtureState = "NORMAL FIXTURE"
                    }, commandType: CommandType.StoredProcedure).ToList();

                Debug.WriteLine("Match FIXTURE at " + DateTime.Now + " Result: " + value[0].ToString().ToUpper());
            }
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    FIXTURE fixture = DbData.FIXTUREs.SingleOrDefault(x => (x.homeTeam == pHomeTeam) && (x.awayTeam == pAwayTeam) && (x.dateOfmatch == pDate));

            //    if (fixture == null)
            //    {
            //        try
            //        {
            //            FIXTURE newFixture = new FIXTURE()
            //            {
            //                country = pCountry,
            //                competition = pCompetition,
            //                homeTeam = pHomeTeam,
            //                awayTeam = pAwayTeam,
            //                dateOfmatch = pDate,
            //                timeOfMatch = pTime,
            //                fixtureState = "NORMAL FIXTURE"
            //            };

            //            DbData.FIXTUREs.InsertOnSubmit(newFixture);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred while inserting fixture...\n" + sql.Message);
            //        }
            //    }
            //}
        }

        #endregion
    }
}
