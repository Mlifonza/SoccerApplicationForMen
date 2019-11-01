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
    public class TeamsForm
    {
        #region Properties

        public string nameOfTeam { get; set; }
        public string competition { get; set; }
        public string country { get; set; }
        public string competitionLink { get; set; }
        public char _1 { get; set; }
        public char _2 { get; set; }
        public char _3 { get; set; }
        public char _4 { get; set; }
        public char _5 { get; set; }

        #endregion

        public void InsertTeamsForm(string pCountry, string pCompetition, string teamName, string pLink
                    , char num1, char num2, char num3, char num4, char num5)
        {
            Data_Organiser data = new Data_Organiser();
            using (IDbConnection conn = data.Connection())
            {
                var retval = conn.Query<bool>("sp_InsertTeamsForm",
                        new
                        {
                            nameOfTeam = teamName,
                            country = pCountry,
                            competition = pCompetition,
                            competitionLink = pLink,
                            _1 = num1,
                            _2 = num2,
                            _3 = num3,
                            _4 = num4,
                            _5 = num5
                        }, commandType: CommandType.StoredProcedure).ToList();

                
                Debug.WriteLine("TEAMS FORM at " + DateTime.Now + " Result: " + retval[0].ToString().ToUpper());
                //TEAMSFORM team = DbData.TEAMSFORMs.SingleOrDefault(t => (t.country.Equals(pCountry) && (t.competition.Equals(pCompetition)
                //                  && (t.nameOfTeam.Equals(teamName)))));
                //if (team == null)
                //{
                //    try
                //    {
                //        TEAMSFORM teamsForm = new TEAMSFORM()
                //        {
                //            nameOfTeam = teamName,
                //            country = pCountry,
                //            competition = pCompetition,
                //            competitionLink = pLink,
                //            _1 = num1,
                //            _2 = num2,
                //            _3 = num3,
                //            _4 = num4,
                //            _5 = num5
                //        };

                //        DbData.TEAMSFORMs.InsertOnSubmit(teamsForm);
                //        DbData.SubmitChanges();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("An error occurred while inserting teams form..." + ex.Message);
                //    }
                //}
                //else
                //{
                //    try
                //    {
                //        team._1 = num1;
                //        team._2 = num2;
                //        team._3 = num3;
                //        team._4 = num4;
                //        team._5 = num5;

                //        DbData.SubmitChanges();
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("An error occurred while updating teams form..." + ex.Message);
                //    }
                //}
            }
        }
    }
}
