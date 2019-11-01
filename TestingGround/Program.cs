using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestingGround
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<bool>() { true, false };
            Console.WriteLine("Results: " + list[0].ToString());
            Console.Read();
            //List<string> randomNames = new List<string>()
            //{
            //    "", "Gift", "", "Lamb", "Gate", "", "Breadt"
            //};
            //int numberOfCharacters = 0;
            //string content;
            //List<string> lineContains = new List<string>();
            //StreamReader sr = new StreamReader(new BufferedStream(new FileStream(@"C:\Users\Lifa\Desktop\My digital notepad\Football Results\ARGENTINA Primera B Nacional Results.txt", FileMode.Open, FileAccess.Read)));
            //int numofLines = sr.Read();

            //////Console.WriteLine("Number of repetition: {0}", numofLines * 93);
            //for (int i = 0; i < (numofLines * 39) - 16; i++)
            //{
            //    content = sr.ReadLine();
            //    lineContains.Add(content);
            //}
            ////Remove all elements that contain 'Round'
            //lineContains.RemoveAll(p => (lineContains.Contains("Round")));

            //SampleDataDataContext DbData = new SampleDataDataContext();
            //IEnumerable<TEAM> team = DbData.TEAMs.Select(x => (x));
            //foreach (TEAM xTeam in team)
            //{
            //    IEnumerable<EVALUATED_RESULT> evResult = DbData.EVALUATED_RESULTs.Where(x => (x.homeTeam.Equals(xTeam))).
            //                                            Select(y => (y));
            //    int count = evResult.Count(x => (x.matchState.Equals("homeWin")));
            //    Console.WriteLine("HomeTeam: {0}\nCount: {1}", xTeam.nameOfTeam, count);
                //foreach (EVALUATED_RESULT readResults in evResult)
                //{

                //    if (readResults.matchState.Equals("homeWin"))
                //    {

                //    }
                //}

            //numberOfCharacters = sr.ReadToEnd().Length;
            //sr.Close();

            //foreach (string list in lineContains)
            //{
            //    Console.WriteLine(list);
            //}

            //content = sr.ReadToEnd();
            //numberOfCharacters = content.Length;
            //Console.WriteLine();
            //Console.WriteLine("Number of characters: {0}", numberOfCharacters);

            //string number = "";
            //int num = Int16.Parse(number);
            //Console.WriteLine();

            ////double number = 5;
            //////double num = Convert.ToDouble(string.Format("{0:0.0}", number));
            ////Console.WriteLine(string.Format("{0:0.0}", number));
            //////Console.WriteLine(string.Format("{0:.}", number));

            ////string date = "07/06/2018";
            ////DateTime dt = Convert.ToDateTime(date);
            ////Console.WriteLine("Day: {0}, Month: {1}, Year: {2}", dt.Day, dt.Month, dt.Year);

            //Console.Read();
            }

            public enum ResultState { HomeWin, AwayWin, Draw }
        }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
    }
}

