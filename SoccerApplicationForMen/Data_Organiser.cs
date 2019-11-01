using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace SoccerApplicationForMen
{
    public class Data_Organiser
    {
        //Results results = new Results();
        //Fixture fixture = new Fixture();
        RecalledMatch recalledMatch = new RecalledMatch();

        public enum OptionState { Fixture, Result }
        public enum ResultState { Draw, HomeWin, AwayWin, POSTPONED, CANCELLED, UNDEFINED }

        List<string> countryLinks = new List<string>();
        List<string> leaguelinks = new List<string>();
        public static string constantUrl = "https://us.soccerway.com/";
        public string url { get; set; }

        public async void GetCountryLink()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                String html = await httpClient.GetStringAsync(constantUrl);

                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);

                List<HtmlNode> countryNode = htmlDocument.DocumentNode.Descendants("tr")
                    .Where(node => (node.GetAttributeValue("id", "")
                    .Contains("date_matches"))).ToList();

                foreach (HtmlNode countryNodeItem in countryNode)
                {
                    List<HtmlNode> countryInfo = countryNodeItem.Descendants("th")
                        .Where(node => (node.GetAttributeValue("class", "")
                        .Equals("competition-link"))).ToList();

                    string link = countryInfo[0].Element("a")
                        .GetAttributeValue("href", "");

                    countryLinks.Add(link);
                }
                //string test = "";
                this.GetCompetitionLink();
            }
            catch (HttpRequestException http)
            {
                MessageBox.Show("PLEASE CHECK YOUR CONNECTION, YOU NOT BE CONNECTED TO THE INTERNET\nCountryLinks\n" + http.Message);
            }
            catch (TaskCanceledException tex)
            {
                
            }
        }

        public async void GetCompetitionLink()
        {
            foreach (string countryLinksItem in countryLinks)
            {
                try
                {
                    HttpClient httpClient = new HttpClient();
                    String html = await httpClient.GetStringAsync(constantUrl + countryLinksItem);

                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    List<HtmlNode> element = htmlDocument.DocumentNode.Descendants("ul")
                        .Where(node => (node.GetAttributeValue("class", "")
                        .Equals("left-tree"))).ToList();

                    List<HtmlNode> htmlNode = element[0].Descendants("li")
                        .Where(node => (node.GetAttributeValue("class", "")
                        .Contains("odd") || node.GetAttributeValue("class", "")
                        .Contains("even"))).ToList();
                    foreach (HtmlNode htmlNodeItem in htmlNode)
                    {
                        string leagueLinkNode = htmlNodeItem.Element("a")
                            .GetAttributeValue("href", "");

                        string link = leagueLinkNode;
                        leaguelinks.Add(link);

                        GetData(link, countryLinksItem);
                    }
                }
                catch (HttpRequestException http)
                {
                    MessageBox.Show("PLEASE CHECK YOUR CONNECTION, YOU NOT BE CONNECTED TO THE INTERNET\nCountryLinks\n" + http.Message);
                    break;
                }
                catch (TaskCanceledException tex)
                {
                    continue;
                }
                catch (Exception tex)
                {
                    continue;
                }
            }

            string test = "";
        }

        public void GetData(string pCompetitionLink, string pCountryLink)
        {
            Country countryObj = new Country();
            Competition leagueObj = new Competition();
            string country, league, testString;
            string link = pCompetitionLink;

            testString = pCompetitionLink.Remove(0, 3);
            testString = testString.Remove(0, testString.IndexOf('/') + 1);
            country = testString.Substring(0, testString.IndexOf('/'));
            testString = testString.Remove(0, testString.IndexOf('/') + 1);
            league = testString.Substring(0, testString.IndexOf('/'));

            countryObj.InsertCountry(country, pCountryLink);
            leagueObj.InsertCompetition(league, country, pCompetitionLink);
            //country = testString;
        }

        public async void GetCompetitionData()
        {
            try
            {
                Results results = new Results();

                using (IDbConnection conn = this.Connection())
                {
                    List<Competition> links = conn.Query<Competition>("SELECT * FROM COMPETITION").ToList();
                    foreach (Competition linksItem in links)
                    {
                        HttpClient httpClient = new HttpClient();
                        String html = await httpClient.GetStringAsync(constantUrl + linksItem.link);

                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);

                        List<HtmlNode> MatchHtml = htmlDocument.DocumentNode.Descendants("tr")
                    .Where(node => (node.GetAttributeValue("id", "")
                    .Contains("page_competition_1_block_competition_matches"))).ToList();

                        foreach (HtmlNode MatchListItem in MatchHtml)
                        {
                            string date = results.GetMatchData(MatchListItem).Item1;
                            DateTime evaluatedDate = Convert.ToDateTime(date);

                            string homeTeam = results.GetMatchData(MatchListItem).Item2;

                            string awayTeam = results.GetMatchData(MatchListItem).Item3;

                            string score = results.GetMatchData(MatchListItem).Item4;

                            string homeScore = "";
                            string awayScore = "";
                            ResultState state = ResultState.UNDEFINED;
                            OptionState optionState = OptionState.Result;
                            string time = "";
                            if (IsSubstringable(score, ref homeScore, ref awayScore) && score.Contains(':'))
                            {
                                optionState = OptionState.Fixture;
                                time = score;
                                this.SlicingData(linksItem.country, linksItem.titleOfCompetition, evaluatedDate, homeTeam, awayTeam,
                                            homeScore, awayScore, OptionState.Fixture.ToString(), time);
                            }
                            else if (IsSubstringable(score, ref homeScore, ref awayScore) && score.Contains('P') || score.Contains('E') || score.Contains("PSTP"))
                            {
                                state = ResultState.POSTPONED;
                                recalledMatch.InsertRecalledMatch(linksItem.country, linksItem.titleOfCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                            else if (IsSubstringable(score, ref homeScore, ref awayScore) && IsNumber(homeScore, awayScore))
                            {
                                optionState = OptionState.Result;
                                this.SlicingData(linksItem.country, linksItem.titleOfCompetition, evaluatedDate, homeTeam, awayTeam,
                                            homeScore, awayScore, OptionState.Result.ToString(), time);
                            }
                            else if (IsSubstringable(score, ref homeScore, ref awayScore) && score == "CANC")
                            {
                                state = ResultState.CANCELLED;
                                recalledMatch.InsertRecalledMatch(linksItem.country, linksItem.titleOfCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                            else
                            {
                                state = ResultState.UNDEFINED;
                                recalledMatch.InsertRecalledMatch(linksItem.country, linksItem.titleOfCompetition, evaluatedDate,
                                    homeTeam, awayTeam, state.ToString());
                                continue;
                            }
                        }
                    }
                }
            }
            catch (HttpRequestException http)
            {
                MessageBox.Show("PLEASE CHECK YOUR CONNECTION, YOU NOT BE CONNECTED TO THE INTERNET\nCompetitionData\n" + http.Message);
            }
            catch (TaskCanceledException tex)
            {
                this.GetCompetitionData();
            }
            catch (Exception tex)
            {
                this.GetCompetitionData();
            }
            
            string test = "";
        }

        public void SlicingData(string country, string league, DateTime pDate, 
            string pHomeTeam, string pAwayTeam, string pHomeScore, string pAwayScore, string option, string pTime)
        {
            Results compStat = new Results();
            Results results = new Results();
            Fixture fixture = new Fixture();
            try
            {
                ResultState state = ResultState.Draw;


                if (Int16.Parse(pHomeScore) > Int16.Parse(pAwayScore))
                {
                    state = ResultState.HomeWin;
                }
                else if (Int16.Parse(pAwayScore) > Int16.Parse(pHomeScore))
                {
                    state = ResultState.AwayWin;
                }
                else if (Int16.Parse(pAwayScore) == Int16.Parse(pHomeScore))
                {
                    state = ResultState.Draw;
                }
                
                if (option != OptionState.Fixture.ToString())
                {
                    results.InsertResults(pHomeTeam, pAwayTeam, pDate, country, league, pHomeScore, pAwayScore, state.ToString());
                }
                else
                {
                    fixture.InsertFixture(country, league, pHomeTeam, pAwayTeam, pDate, pTime);
                }
            }
            catch (Exception ex)
            {
                recalledMatch.InsertRecalledMatch(country, league, pDate,
                                pHomeTeam, pAwayTeam, "UNDEFINED");
            }
        }

        public bool IsNumber(string pHomeScore, string pAwayScore)
        {
            try
            {
                int homeScoreConverted = Int16.Parse(pHomeScore);
                int awayScoreConverted = Int16.Parse(pAwayScore);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool IsSubstringable(string pScore, ref string pHomeScore, ref string pAwayScore)
        {
            try
            {
                pHomeScore = pScore.Substring(0, pScore.IndexOf(" "));
                pAwayScore = pScore.Substring(pScore.LastIndexOf(" "), pScore.Length - pScore.LastIndexOf(" "));
                if (pHomeScore != string.Empty || pAwayScore != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async void GetHomeFormsData()
        {
            Results result = new Results();

            using (IDbConnection conn = this.Connection())
            {
                var competitionLink = conn.Query<Competition>("SELECT * FROM [Football].[dbo].[COMPETITION]").ToList();
                
                foreach (Competition competitionLinkItem in competitionLink)
                {
                    try
                    {
                        const int NUMBEROFGAMES = 5;
                        TeamsForm teamForm = new TeamsForm();
                        Queue<char> formValues = new Queue<char>(5);
                        HttpClient httpClient = new HttpClient();
                        String html = await httpClient.GetStringAsync(constantUrl + competitionLinkItem.link);

                        HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                        htmlDocument.LoadHtml(html);

                        //Get all the elements with attribute team rank
                        List<HtmlNode> logNode = htmlDocument.DocumentNode.Descendants("tr")
                            .Where(node => (node.GetAttributeValue("id", "")
                            .Contains("team_rank"))).ToList();

                        foreach (HtmlNode logNodeItem in logNode)
                        {
                            //Get the team node
                            List<HtmlNode> teamNameNode = logNodeItem.Descendants("td")
                                .Where(node => (node.GetAttributeValue("class", "")
                                .Contains("text team"))).ToList();

                            string teamName = teamNameNode[0].Element("a").InnerText;

                            List<HtmlNode> teamFormNode = logNodeItem.Descendants("td")
                                .Where(node => (node.GetAttributeValue("class", "")
                                .Contains("form"))).ToList();

                            if (!teamFormNode.Equals(null) && teamFormNode.Count() == 1)
                            {
                                List<HtmlNode> value = teamFormNode[0].Descendants("a")
                                    .Where(node => (node.GetAttributeValue("title", "")
                                        .Contains(teamName))).ToList();

                                foreach (var nodeItem in value)
                                    formValues.Enqueue(char.Parse(nodeItem.InnerText.Trim()));
                                {
                                }

                                int count = value.Count();

                                if (count < NUMBEROFGAMES)
                                {
                                    int numOfElementsToInsert = NUMBEROFGAMES - count;
                                    for (int i = 0; i < numOfElementsToInsert; i++)
                                    {
                                        formValues.Enqueue(' ');
                                    }
                                }
//                                Debug.WriteLine(@"\nCountry: {0}\nCompetition: {1}\nLink: {2}\nTeam: {3}\n1: {4}\n2: {5}\n3: {6}\n4: {7}\n5: {8}\n
//                                        ", competitionLinkItem.country, competitionLinkItem.titleOfCompetition, competitionLinkItem.link,
//                                         formValues.ElementAt(0), formValues.ElementAt(1), formValues.ElementAt(2),
//                                formValues.ElementAt(3), formValues.ElementAt(4));

                                teamForm.InsertTeamsForm(competitionLinkItem.country, competitionLinkItem.titleOfCompetition, teamName,
                                competitionLinkItem.link, formValues.ElementAt(0), formValues.ElementAt(1), formValues.ElementAt(2),
                                formValues.ElementAt(3), formValues.ElementAt(4));

                                formValues.Clear();
                            }
                            string test = "";
                        }
                    }
                    catch (HttpRequestException http)
                    {
                        MessageBox.Show("PLEASE CHECK YOUR CONNECTION, YOU NOT BE CONNECTED TO THE INTERNET\nYouBitch\n" + http.Message);
                        break;
                    }
                    catch (TaskCanceledException tex)
                    {
                        continue;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }

                //Evaluate results
                //result.GetTeamWhoWon();
            }
        }

        public async Task<HtmlAgilityPack.HtmlDocument> GetHtml(string pUrl)
        {
            HttpClient httpClient = new HttpClient();
            String html = await httpClient.GetStringAsync(pUrl);

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            return htmlDocument;
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(@"Integrated Security=SSPI;Initial Catalog=Football;Data Source=localhost;");
        }
    }
}
