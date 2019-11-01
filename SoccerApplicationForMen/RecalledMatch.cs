using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class RecalledMatch
    {
        //Data_Organiser data = new Data_Organiser();
        public void InsertRecalledMatch(string pCountry, string pCompetition, DateTime pDate,
                    string pHomeTeam, string pAwayTeam, string pMatchState)
        {
            Data_Organiser data = new Data_Organiser();

            using (IDbConnection conn = data.Connection())
            {
                var value = conn.Query<bool>("sp_InsertRecalledMatch",
                    new
                    {
                        Country = pCountry,
                        Competition = pCompetition,
                        DateOfmatch = pDate,
                        HomeTeam = pHomeTeam,
                        AwayTeam = pAwayTeam,
                        MatchState = pMatchState
                    }, commandType: CommandType.StoredProcedure);

                Debug.WriteLine("Match RECALLED at " + DateTime.Now + " Result: " + value.ToString().ToUpper());
            }
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    RECALLEDMATCH match = DbData.RECALLEDMATCHes.SingleOrDefault(x => (x.homeTeam.Equals(pHomeTeam)) && (x.awayTeam.Equals(pAwayTeam))
            //                                                    && (x.dateOfmatch.Equals(pDate)) && (x.country.Equals(pCountry))
            //                                                    && (x.competition.Equals(pCompetition)));
            //    RECALLEDMATCH newRematch = new RECALLEDMATCH()
            //    {
            //        country = pCountry,
            //        competition = pCompetition,
            //        dateOfmatch = pDate,
            //        homeTeam = pHomeTeam,
            //        awayTeam = pAwayTeam
            //    };

            //    if (match == null)
            //    {
            //        try
            //        {
            //            RECALLEDMATCH recalledMatch = new RECALLEDMATCH()
            //            {
            //                country = pCountry,
            //                competition = pCompetition,
            //                dateOfmatch = pDate,
            //                homeTeam = pHomeTeam,
            //                awayTeam = pAwayTeam,
            //                matchState = pMatchState
            //            };

            //            DbData.RECALLEDMATCHes.InsertOnSubmit(recalledMatch);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("An error occurred while inserting into RecalledMatch...\n" + ex);
            //        }
            //    }
            //    else
            //    {
            //        string continueString = "";
            //    }
            //}
        }
    }
}
