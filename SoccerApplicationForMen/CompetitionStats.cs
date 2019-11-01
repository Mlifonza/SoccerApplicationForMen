using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerApplicationForMen
{
    public class CompetitionStats
    {
        public void InsertCompetitionStats(string pTeamName, string pCountry, string pCompetition,
            string pTime, DateTime pDate, string pMatchState)
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    COMPETITION_STAT stat = DbData.COMPETITION_STATs.SingleOrDefault(x => (x.country.Equals(pCountry)) 
            //            & (x.country.Equals(pCountry)) & (x.currentCompetition.Equals(pCompetition))
            //            &(x.dateOfmatch.Equals(pDate)) & (x.nameOfTeam.Equals(pTeamName)));
            //    if (stat == null)
            //    {
            //        try
            //        {
            //            COMPETITION_STAT newStat = new COMPETITION_STAT()
            //            {
            //                nameOfTeam = pTeamName,
            //                country = pCountry,
            //                currentCompetition = pCompetition,
            //                dateOfmatch = pDate,
            //                timeOfMatch = pTime,
            //                matchState = pMatchState
            //            };

            //            DbData.COMPETITION_STATs.InsertOnSubmit(newStat);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred while inserting Competition Stats\n" + sql.Message);
            //        }
            //    }
            //}
        }
    }
}
