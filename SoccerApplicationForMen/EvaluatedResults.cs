using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerApplicationForMen
{
    public class EvaluatedResults
    {
        public void InsertEvalautedResults(string pHomeTeam, string pAwayTeam, string pCountry, string pLeague, DateTime pDate, string pTime, string pMatchState)
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    EVALUATED_RESULT evResults = DbData.EVALUATED_RESULTs.SingleOrDefault(x => (x.homeTeam == pHomeTeam) && (x.awayTeam == pAwayTeam) && (x.dateOfmatch == pDate));
            //    if (evResults == null && !pMatchState.Equals("Posponed"))
            //    {
            //        try
            //        {
            //            EVALUATED_RESULT newEvResults = new EVALUATED_RESULT()
            //            {
            //                homeTeam = pHomeTeam,
            //                awayTeam = pAwayTeam,
            //                country = pCountry,
            //                competition = pLeague,
            //                dateOfmatch = pDate,
            //                timeOfMatch = pTime,
            //                matchState = pMatchState,
            //                nature = "COMPLETED"
            //            };
            //            DbData.EVALUATED_RESULTs.InsertOnSubmit(newEvResults);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred while adding to evaluated_Results table\n" + sql.Message);   
            //        }
            //    }
            //}
        }
    }
}
