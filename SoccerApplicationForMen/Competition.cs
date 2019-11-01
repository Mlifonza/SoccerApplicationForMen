using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class Competition : Country
    {
        //Data_Organiser data = new Data_Organiser();

        #region Properties

        public string titleOfCompetition { get; set; }
        public string country { get; set; }
        public string link { get; set; }
        //protected int NumberOfTeams { get; set; }

        #endregion

        #region Methods

        public void InsertCompetition(string pCompetition, string pCountry, string pLink)
        {
            Data_Organiser data = new Data_Organiser();

            using (IDbConnection conn = data.Connection())
            {
                var retval = conn.Query<bool>("[dbo].[sp_InsertCompetition]",
                    new
                    {
                        Competition = pCompetition,
                        Country = pCountry,
                        Link = pLink
                    }, commandType: CommandType.StoredProcedure);

                Debug.WriteLine("COMPETITION at " + DateTime.Now + " Result: " + retval.ToString().ToUpper());
            }


            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    COMPETITION league = DbData.COMPETITIONs.SingleOrDefault(x => (x.titleOfCompetition == pCompetition));
            //    if (league == null)
            //    {
            //        try
            //        {
            //            COMPETITION newCompetition = new COMPETITION()
            //            {
            //                titleOfCompetition = pCompetition,
            //                country = pCountry,
            //                link = pLink
            //            };

            //            DbData.COMPETITIONs.InsertOnSubmit(newCompetition);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred while inserting league..\n" + sql.Message);
            //        }
            //    }
            //}
        }

        #endregion

    }
}