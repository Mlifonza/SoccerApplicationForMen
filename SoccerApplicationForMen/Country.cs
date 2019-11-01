using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public class Country
    {
        Data_Organiser data = new Data_Organiser();
        protected List<Country> countryList;
        protected List<Results> fillResults;

        #region Properties

        public string CountryName { get; set; }

        #endregion

        #region Constructor

        public Country()
        {

        }

        #endregion

        #region Methods

        public void InsertCountry(string pCountry, string pLink)
        {
            using (IDbConnection conn = data.Connection())
            {
                var value = conn.Query<bool>("sp_InsertCounty", 
                    new {
                            Country = pCountry,
                            Link = pLink
                        }, commandType: CommandType.StoredProcedure);

                Debug.WriteLine("Country at " + DateTime.Now + " Result: " + value.ToString());
            }
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    COUNTRY country = DbData.COUNTRies.SingleOrDefault(x => x.country_Name == pCountry);
            //    if (country == null)
            //    {
            //        try
            //        {
            //            COUNTRY newCountry = new COUNTRY()
            //            {
            //                country_Name = pCountry,
            //                link = pLink
            //            };

            //            DbData.COUNTRies.InsertOnSubmit(newCountry);
            //            DbData.SubmitChanges();
            //        }
            //        catch (Exception sql)
            //        {
            //            MessageBox.Show("An error occurred...\n" + sql.Message);
            //        }
            //    }
            //}
        }

        #endregion

    }
}
