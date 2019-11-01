using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace SoccerApplicationForMen
{
    public class File_Organiser
    {
        Hashtable monthRoundKeeper = new Hashtable();
        #region Properties

        public enum ResultState { Draw, HomeWin, AwayWin, Posponed }

        #endregion

        Results results = new Results();
        Fixture fixture = new Fixture();
        string country, Competition, time = "Unknown",
                       homeTeam = "Unknown", awayTeam = "Unknown";
        DateTime date;
        int homeScore = 0, awayScore = 0, round = 0;
        ResultState state = ResultState.Draw;

        public string GetCountry(int pPosition, List<string> pLineContains)
        {
            country = pLineContains[0].Substring(0, pLineContains[0].LastIndexOf(':'));
            return country;
        }

        public string GetCOMPETITION(int pPosition, List<string> pLineContains)
        {
            Competition = pLineContains[0].Substring(pPosition, pLineContains[0].Length - pPosition);
            return Competition;
        }

        public DateTime GetDate(int pDateLength, int counter, List<string> pLineContains, ref int? pEvaluatedmonth, int pRound)
        {
            string year, month, day, dateFormat;
            DateTime dt = DateTime.Now;
            string previousYear = Convert.ToString(dt.Year - 1);
            
            year = dt.Year.ToString();
            int dateLength = pLineContains[counter].Length;
            string date = pLineContains[counter].Substring(0, (dateLength - pLineContains[counter].LastIndexOf('.')) - 3);

            day = date.Substring(0, date.LastIndexOf('.'));
            month = date.Substring(date.LastIndexOf('.') + 1, date.Length - 3);

            pEvaluatedmonth = int.Parse(month);
            
            if (pEvaluatedmonth < 1)
            {
                dateFormat = month + "/" + day + "/" + previousYear;
                if (!monthRoundKeeper.ContainsKey(pRound))
                {
                    monthRoundKeeper.Add(pRound, previousYear);
                }
            }
            else
            {
                dateFormat = month + "/" + day + "/" + year;
                if (!monthRoundKeeper.ContainsKey(pRound))
                {
                    monthRoundKeeper.Add(pRound, year);
                }
            }

            pEvaluatedmonth--;
            return Convert.ToDateTime(dateFormat);
        }

        public string GetTime(int pTimePosition, int counter, List<string> pLineContains)
        {
            int timePosition = pLineContains[counter].LastIndexOf('.') + 2;
            time = pLineContains[counter].Substring(timePosition, pLineContains[counter].Length - timePosition);
            return time;
        }

        public string GetHome(int counter, List<string> pLineContains)
        {
            homeTeam = pLineContains[counter].Substring(0, pLineContains[counter].Length);
            return homeTeam;
        }

        public string GetAway(int counter, List<string> pLineContains)
        {
            awayTeam = pLineContains[counter].Substring(0, pLineContains[counter].Length);
            return awayTeam;
        }

        public int GetHomeScore(int counter, List<string> pLineContains)
        {
            homeScore = Convert.ToInt32(pLineContains[counter].Substring(0, 1));
            return homeScore;
        }

        public int GetAwayScore(int counter, List<string> pLineContains)
        {
            awayScore = Convert.ToInt32(pLineContains[counter].Substring(pLineContains[counter].Length - 2));
            return awayScore;
        }

        public void GetFilesFromFolder(string folderName, int row, int group, string category)
        {
            string content;
            List<string> lineContains = new List<string>();
            //Get all the files
            string[] files = Directory.GetFiles(folderName);
            //Go through each file
            ProgressBar pro = new ProgressBar();
            pro.Style = ProgressBarStyle.Continuous;
            pro.Step = 1;
            pro.Location = new System.Drawing.Point(12, 571);
            pro.Size = new System.Drawing.Size(207, 28);
            foreach (string names in files)
            {
                pro.PerformStep();
                
                //MessageBox.Show(names);
                //Read each line of a specific file
                using (StreamReader sr = new StreamReader(new BufferedStream(new FileStream(@names, FileMode.Open, FileAccess.Read))))
                {
                    //int numofLines = sr.Read();

                    //string readToEnd = sr.ReadToEnd();
                    //System.Console.WriteLine(readToEnd);

                    //for (int i = 0; i < (numofLines * 50) - 16; i++)
                    //{
                    //    //Copy each line of string to content
                    //    content = sr.ReadLine();

                    //    //Add to List<> array
                    //    lineContains.Add(content);
                    //}

                    while (sr.EndOfStream == false)
                    {
                        //Copy each line of string to content
                        content = sr.ReadLine();

                        //Add to List<> array
                        lineContains.Add(content);
                    }
                    //Remove all null elements
                    lineContains.RemoveAll(p => (p == " " || p == null || p == string.Empty));

                    Country objCountry = new Country();
                    Competition objCOMPETITION = new Competition();

                    int position = lineContains[0].LastIndexOf(":") + 1;
                    country = this.GetCountry(position, lineContains);
                    Competition = this.GetCOMPETITION(position, lineContains);

                    //objCountry.InsertCountry(country);
                    //objCOMPETITION.InsertCOMPETITION(Competition, country);

                    ExtractDataFromFile(lineContains, country, Competition, ref round, ref date, ref time, ref homeTeam,
                                        ref awayTeam, ref homeScore, ref awayScore, ref state, row, group, category);
                    round = 0;
                    //Removes all the elements in that List<>
                    lineContains.RemoveRange(0, lineContains.Count);
                }
            }
        }

        private void ExtractDataFromFile(List<string> lineContains, string country, string Competition,
                                        ref int round, ref DateTime pDate, ref string time, ref string pHomeTeam,
                                        ref string pAwayTeam, ref int homeScore, ref int awayScore, ref ResultState state, 
                                        int skipRow, int groupLoop, string pCategory)
        {
            //Go through the whole list
            while (!lineContains.Equals(null) && lineContains.Count > 0)
            {
                //Go through each group of strings that need to be extracted
                for (int j = 1; j < groupLoop; j++)
                {
                    //MessageBox.Show(lineContains[j] + "\n" + country + "\n" + Competition);
                    if (lineContains[j].Contains("Round ") && lineContains != null)
                    {
                        round = Convert.ToInt32(lineContains[j].Substring(lineContains[j].Length - 2, 2));
                        lineContains.RemoveAt(j);
                    }

                    switch (j)
                    {
                        case 1:
                            int? evaluatedmonth = null;
                            int timePosition = lineContains[j].LastIndexOf('.') + 2;
                            int dateLength = lineContains[j].Length;
                            time = GetTime(timePosition, j, lineContains);
                            pDate = GetDate(dateLength, j, lineContains, ref evaluatedmonth, round);
                            break;
                        case 2:
                            pHomeTeam = GetHome(j, lineContains);
                            break;
                        case 3:
                            pAwayTeam = GetAway(j, lineContains);
                            break;
                        case 4:
                            homeScore = GetHomeScore(j, lineContains);
                            awayScore = GetAwayScore(j, lineContains);

                            if (homeScore > awayScore)
                            {
                                state = ResultState.HomeWin;
                            }
                            else if (awayScore > homeScore)
                            {
                                state = ResultState.AwayWin;
                            }
                            else
                            {
                                state = ResultState.Draw;
                            }
                            break;
                        default:
                            //int digit = i;
                            MessageBox.Show("This value is not a match!");
                            break;
                    }
                }

                //Add the correct information into the right table
                if (pCategory == "Results")
                {
                    //results.InsertResults(pHomeTeam, pAwayTeam, pDate, time, country, Competition, homeScore, awayScore, state);
                }
                else
                {
                    fixture.InsertFixture(country, Competition, pHomeTeam, pAwayTeam, pDate, time);
                }

                if (country == "SWEDEN")
                {
                    MessageBox.Show("Country: " + country + "\nCOMPETITION: " + Competition + "\nRound: " + round + "\n" + homeTeam + " " + homeScore +
                                " : " + awayScore + " " + awayTeam + "\nCategory: " + pCategory);
                }
                

                //Team team = new Team();
                //team.PopulateTeamObject(country, Competition, pHomeTeam, pAwayTeam);

                //Removes the first 4 elements
                lineContains.RemoveRange(1, skipRow);
                //Removes the last element left
                if (lineContains.Count == 1)
                {
                    lineContains.RemoveAt(0);
                }
            }
        }
    }
}
