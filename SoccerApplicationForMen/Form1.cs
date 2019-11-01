using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Dapper;
using System.Diagnostics;

namespace SoccerApplicationForMen
{
    public partial class frmFootball : Form
    {
        List<Team> listOfTeamsToDisplay = null;
        int pageIndex = 0;
        int numberOfPages = 0;
        DateTime selectedDate;
        Panel pnlPages;
        decimal numAveWinLose;
        decimal numGamesToCount;
        CheckedListBox chkConsistancy;
        //DateTime selectedDate = FixtureControl.selectedDate;
        RadioButton rdbON;
        public frmFootball()
        {
            InitializeComponent();
            pnlPages = Pages.pages;
            selectedDate = FixtureControl.selectedDate;
            numAveWinLose = FixtureControl.sNumAveWinLose;
            //date = dtpFilterDate.Value;
            //this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel1_LinkClicked);
        }

        private void linklabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //btnRollFixture.PerformClick();
        }

        private void frmFootball_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < pnlPages.Controls.Count; i++)
            //{
            //    string text = pnlPages.Controls[i].ToString();
            //    //MessageBox.Show(text);
            //    pnlPages.Controls[i].Visible = false;
            //}

            //this.RetrieveAllTitles();
            //Filter filter = new Filter();
            //Results results = new Results();
            //Data_Organiser dor = new Data_Organiser();
            ////results.FullUpdateOfResults();
            ////results.GetTeamWhoWon();
            ////filter.GetHomeWinner();
            ////filter.GetOnFormWinner(5);
            ////filter.GetHomeWinner(4);
            ////filter.GetRegularCleanSheets(5);
            ////filter.GetTopBottom();

            ////Data_Organiser dor = new Data_Organiser();
            ////dor.GetHomeFormsData();

            //Team team = new Team();
            ////team.GeneratePoints();
            
        }

        private void RetrieveAllTitles()
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    IEnumerable<COMPETITION> collection = DbData.COMPETITIONs.Select(COMPETITION => (COMPETITION));
            //    foreach (COMPETITION league in collection)
            //    {
            //        if (!cmbCountry.Items.Contains(league.country))
            //        {
            //            cmbCountry.Items.Add(league.country);
            //        }
            //        cmbCompetition.Items.Add(league.titleOfCompetition);
            //    }
            //    cmbCountry.Text = "Select country..";
            //    cmbCompetition.Text = "Select COMPETITION..";
            //}
        }

        private void btnRollFixture_Click(object sender, EventArgs e)
        {
            RollMethod(0);
        }

        private void RollMethod(int pIndex)
        {
            //pageIndex = pIndex;

            //for (int i = 0; i < pnlPages.Controls.Count; i++)
            //{
            //    string text = pnlPages.Controls[i].ToString();
            //    pnlPages.Controls[i].Visible = false;
            //}

            //selectedDate = dtpFilterDate.Value;
            ////Set pager variable to true because it is possible to have more than 
            ////50 records when you retrieve an unfiltered fixture list
            //bool pager = true;
            //this.ShowFixtures(selectedDate, null, pageIndex, pager);
        }

        //HAVE BEEN COMMENTED ONCE
        private void ShowFixtures(DateTime pDate, List<Team> pListOfTeamsToDisplay, int pIndex, bool pager)
        {
            //pnlFixture.Controls.Clear();
            //List<TextBox> txthomeTeam = new List<TextBox>();
            //List<TextBox> txtAwayTeam = new List<TextBox>();
            //List<Label> lblVerses = new List<Label>();

            //GamePlay game = new GamePlay();
            //Match match = new Match();
            //List<GamePlay> listOfGames = game.GetFixture(pDate);
            //List<GamePlay> gamesBroughtForward;
            ////Only enters AddToList if the list of teams to display are not null
            //if (pager || pListOfTeamsToDisplay == null)
            //{
            //    gamesBroughtForward = AddToList(listOfGames, pIndex).ToList();
            //}
            //else
            //{
            //    gamesBroughtForward = listOfGames;
            //}

            ////gamesBroughtForward.RemoveAll(r => (r.Equals(null)));
            //this.ReleaseFixtureOrResults(gamesBroughtForward, match, pListOfTeamsToDisplay);
        }

        private IEnumerable<GamePlay> AddToList(List<GamePlay> fixture, int index)
        {
            int count;
            //The number of games per page
            int numberPerPage = 50;
            List<GamePlay> gamesToReturn = new List<GamePlay>();
            //This arraylist will indicate how many pages will be collect
            ArrayList pageCollection = new ArrayList();
            //GamePlay[] game = fixture.ToArray();
            GamePlay[] page;
            //fixture.CopyTo(0, page, 0, 30);

            if (fixture.Count > 50)
            {
                count = fixture.Count() / 50;
                //Count how many pages to add
                count = fixture.Count % 50 > 0 ? count = count + 1 : count = count + 0;
                for (int i = 0; i < count; i++)
                {
                    if (fixture.Count < 50)
                    {
                        page = new GamePlay[numberPerPage];
                        fixture.CopyTo(0, page, 0, fixture.Count);
                        pageCollection.Add(page);
                        fixture.RemoveRange(0, fixture.Count - 1);
                    }
                    else
                    {
                        page = new GamePlay[numberPerPage];
                        fixture.CopyTo(0, page, 0, 50);
                        pageCollection.Add(page);
                        fixture.RemoveRange(0, 50);
                    }
                }
            }
            else
            {
                page = new GamePlay[fixture.Count];
                fixture.CopyTo(0, page, 0, fixture.Count);
                pageCollection.Add(page);
            }

            Control control = pnlPages.Controls[index];
            numberOfPages = pageCollection.Count;
            for (int i = 0; i < numberOfPages; i++)
            {
                pnlPages.Controls[i].Visible = true;
                string text = pnlPages.Controls[i].ToString();
                pnlPages.Controls[index].Font = new System.Drawing.Font(control.Font.Name, control.Font.Size,
                        control.Font.Style);
            }

            pnlPages.Controls[index].Font = new System.Drawing.Font(control.Font.Name, control.Font.Size,
                        control.Font.Style ^ FontStyle.Bold);
            if (pageCollection.Count - 1 == index)
            {
                index = 0;
            }
            int check = index;
            return (IEnumerable<GamePlay>)pageCollection[index];
        }

        //HAVE BEEN COMMENTED ONCE
        private void btnApply_Click_1(object sender, EventArgs e)
        {
        //    for (int i = 0; i < pnlPages.Controls.Count; i++)
        //    {
        //        string text = pnlPages.Controls[i].ToString();
        //        pnlPages.Controls[i].Visible = false;
        //    }

        //    int numberOfPreviousMatchesToCount = (int)numGamesToCount;
        //    int averageWinLose = (int)numAveWinLose;
        //    Filter getFilter = new Filter();
        //    switch (chkConsistancy.SelectedIndex)
        //    {
        //        case 0: listOfTeamsToDisplay = null;
        //            break;
        //        case 1: listOfTeamsToDisplay = getFilter.GetHomeWinner(numberOfPreviousMatchesToCount);
        //            break;
        //        case 2: listOfTeamsToDisplay = getFilter.GetAwayWinner(numberOfPreviousMatchesToCount);
        //            break;
        //        case 3: listOfTeamsToDisplay = getFilter.GetOnFormWinner(numberOfPreviousMatchesToCount);
        //            break;
        //        case 4: listOfTeamsToDisplay = getFilter.GetOnFormLoser(numberOfPreviousMatchesToCount);
        //            break;
        //        case 5: listOfTeamsToDisplay = getFilter.GetRegularScorer(numberOfPreviousMatchesToCount);
        //            break;
        //        case 6: listOfTeamsToDisplay = getFilter.GetHomeLoser(numberOfPreviousMatchesToCount);
        //            break;
        //        case 7: listOfTeamsToDisplay = getFilter.GetAwayLoser(numberOfPreviousMatchesToCount);
        //            break;
        //        case 8: listOfTeamsToDisplay = getFilter.GetRegularDrawer(numberOfPreviousMatchesToCount);
        //            break;
        //        case 9: listOfTeamsToDisplay = getFilter.GetRegularHomeDrawer(numberOfPreviousMatchesToCount);
        //            break;
        //        case 10: listOfTeamsToDisplay = getFilter.GetAwayDrawer(numberOfPreviousMatchesToCount);
        //            break;
        //        case 11: listOfTeamsToDisplay = getFilter.GetRegularCleanSheets(numberOfPreviousMatchesToCount);
        //            break;
        //        default: listOfTeamsToDisplay = null;
        //            break;
        //    }

        //    if (rdbON.Checked)
        //    {
        //        listOfTeamsToDisplay = getFilter.GetSeasonPerformer(averageWinLose);
        //    }
        //    //Set pager variable to false because it is possible to have less than 
        //    //50 records when you retrieve an filtered fixture list
        //    bool pager = false;
        //    //Call to show the fixtures
        //    this.ShowFixtures(selectedDate, listOfTeamsToDisplay, pageIndex, pager);
        }

        public void ReleaseFixtureOrResults(List<GamePlay> pListOfGames, Match pMatch, List<Team> pListOfTeamsToDisplay)
        {
            //pbShowProgress.Value = 0;
            //int fixtureCount = 0;
            ////List of team names to display
            //List<string> teamNamesArray = new List<string>();
            //if (pListOfTeamsToDisplay != null)
            //{
            //    foreach (Team teamName in pListOfTeamsToDisplay)
            //    {
            //        teamNamesArray.Add(teamName.nameOfTeam);
            //    }
            //}

            //foreach (GamePlay fix in pListOfGames)
            //{
            //    try
            //    {
            //        pMatch.HomeTeam(fix.HomeTeam, fix.HomePrediction);
            //        pMatch.HomeWins(fix.HomeWins);
            //        pMatch.HomeLosses(fix.HomeLosses);
            //        pMatch.HomeDraws(fix.HomeDraws);

            //        pMatch.AwayTeam(fix.AwayTeam);
            //        pMatch.AwayWins(fix.AwayWins);
            //        pMatch.AwayLosses(fix.AwayLosses);
            //        pMatch.AwayDraws(fix.AwayDraws);

            //        pMatch.GetHomeForm1(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetHomeForm2(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetHomeForm3(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetHomeForm4(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetHomeForm5(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);

            //        pMatch.GetAwayForm1(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetAwayForm2(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetAwayForm3(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetAwayForm4(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
            //        pMatch.GetAwayForm5(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);

            //        //Add all the compenents from Match Class
            //        GroupBox groupbox = pMatch.AddComponent(fix.Date, fix.Time, fix.Country, fix.Competition);

            //        //Display the fixture that matches the condition
            //        if (((teamNamesArray.Contains(fix.HomeTeam) || teamNamesArray.Contains(fix.AwayTeam))) && (pListOfTeamsToDisplay != null))
            //        {
            //            pnlFixture.Controls.Add(groupbox);
            //            fixtureCount++;
            //            pbShowProgress.PerformStep();
            //        }
            //        else if (pListOfTeamsToDisplay == null)
            //        {
            //            pnlFixture.Controls.Add(groupbox);
            //            fixtureCount++;
            //            pbShowProgress.PerformStep();
            //        }

            //        lblFixtureCount.Text = fixtureCount.ToString();
            //    }
            //    catch (NullReferenceException nEx)
            //    {
            //        continue;
            //    }
            //}
            //pbShowProgress.Value = 100;
            //MessageBox.Show("Completed");
        }

        private void ShowAppropriateCOMPETITION(string pCountry)
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    IEnumerable<string> COMPETITION = DbData.COMPETITIONs.Where(x => (x.country.Equals(pCountry))).Select(y => (y.titleOfCompetition));
            //    foreach (string COMPETITIONs in COMPETITION)
            //    {
            //        cmbCompetition.Items.Add(COMPETITIONs);
            //    }
            //}
        }

        private void cmbCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string country = cmbCountry.SelectedText;
            //this.ShowAppropriateCOMPETITION(country);
            ////using (SampleDataDataContext DbData = new SampleDataDataContext())
            ////{
            ////    IEnumerable<string> COMPETITIONs = DbData.COMPETITIONs.Where(x => (x.country.Equals(country))).Select(y => (y.titleOfCOMPETITION));
            ////    cmbCompetition.Items.Clear();
            ////    foreach (string getCOMPETITION in COMPETITIONs)
            ////    {
            ////        MessageBox.Show(getCOMPETITION);
            ////        cmbCompetition.Items.Add(getCOMPETITION);
            ////    }
            ////}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RetrieveAllTitles();
        }

        private void btnShowLeague_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string country = cmbCountry.SelectedText;
            //    string competition = cmbCompetition.SelectedText;

            //    using (SampleDataDataContext DbData = new SampleDataDataContext())
            //    {
            //        List<Team> log = DbData.TEAMs.Where(x => (x.country.Equals(country) && (x.currentCompetition.Equals(competition)))).ToList();
                    
            //        sampleGridView.DataSource = log;
            //    }
            //}
            //catch (Exception sql)
            //{
            //    MessageBox.Show("An error occurred while showing the appropraite COMPETITION title\n" + sql.Message);
            //}
        }

        private void btnResults_Click(object sender, EventArgs e)
        {
            ////string day = dtpFilterDate.Value.Day.ToString();
            ////string month = dtpFilterDate.Value.Month.ToString();
            //DateTime selectedDate = dtpFilterDate.Value;

            //Results result = new Results();
            //MatchResults mResults = new MatchResults();
            //List<RESULT> getEVResults = result.GetResults(selectedDate);
            
            //foreach (RESULT evResults in getEVResults)
            //{
            //    mResults.HomeTeam(evResults.homeTeam);
            //    mResults.AwayTeam(evResults.awayTeam);
            //    mResults.HomeScore(Int16.Parse(evResults.homeTeamScore));
            //    mResults.AwayScore(Int16.Parse(evResults.awayTeamScore));
            //    GroupBox group = mResults.AddComponent(evResults.dateOfmatch, evResults.timeOfMatch,
            //                            evResults.country, evResults.competition);
            //    pnlFixture.Controls.Add(group);
            //}
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //Results results = new Results();
            //Data_Organiser dataOrganiser = new Data_Organiser();
            //int value = 0;
            //pbShowProgress.Value = value + 5;
            //dataOrganiser.GetCountryLink();
            //pbShowProgress.Value = value + 5;
            //dataOrganiser.GetCompetitionData();
            //pbShowProgress.Value = value + 5;
            //dataOrganiser.GetHomeFormsData();
            //pbShowProgress.Value = value + 5;
            //results.FullUpdateOfResults();
            //pbShowProgress.Value = 100;
            ////File_Organiser objFile = new File_Organiser();
            //Fixture fixture = new Fixture();
            ////objFile.GetFilesFromFolder(results.FileName, results.NumOfRowsToSkip, results.GroupLoop, "Results");
            ////objFile.GetFilesFromFolder(fixture.FileName, fixture.NumOfRowsToSkip, fixture.GroupLoop, "Fixture");
            //Team team = new Team();
            //team.GeneratePoints();
        }

        private void btnClearList_Click_1(object sender, EventArgs e)
        {
            //pnlFixture.Controls.Clear();
            //pbShowProgress.Value = 0;
        }

        private void chkConsistancy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filter getFilter = new Filter();
            //if (chkConsistancy.SelectedIndex == 0)
            //{
            //    for (int i = 0; i < chkConsistancy.Items.Count; i++)
            //    {
            //        chkConsistancy.SetItemChecked(i, true);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < chkConsistancy.Items.Count; i++)
            //    {
            //        chkConsistancy.SetItemChecked(i, false);
            //    }
            //}

            //switch (chkConsistancy.SelectedIndex)
            //{
            //    //case 1: getFilter.GetHomeWinner();
            //    //    chkConsistancy.SetItemCheckState(1, CheckState.Checked);
            //    //    this.AddToList(getFilter.homeWinner);
            //    //    break;
            //    //case 2: getFilter.GetAwayWinner();
            //    //    break;
            //    //case 3: getFilter.GetOnFormWinner();
            //    //    chkConsistancy.SetItemCheckState(3, CheckState.Checked);
            //    //    this.AddToList(getFilter.onFormWinner);
            //    //    break;
            //    //case 4: getFilter.GetOnFormLoser();
            //    //    break;
            //    //case 5: getFilter.GetRegularScore();
            //    //    break;
            //    //default: btnApply.PerformClick();
            //    //    break;
            //}
        }

        //private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(6);
        //}

        //private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(7);
        //}

        //private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(8);
        //}

        //private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(9);
        //}

        //private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(10);
        //}

        //private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(11);
        //}

        //private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(12);
        //}

        //private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(13);
        //}

        //private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(14);
        //}

        //private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(15);
        //}

        //private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(16);
        //}

        //private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(17);
        //}

        //private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(18);
        //}

        //private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(10);
        //}

        //private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(20);
        //}

        //private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(5);
        //}

        //private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(0);
        //}

        //private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(1);
        //}

        //private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(2);
        //}

        //private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(3);
        //}

        //private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(4);
        //}

        private void btnQuickUpdate_Click(object sender, EventArgs e)
        {
            //Results results = new Results();
            //Data_Organiser dataOrganiser = new Data_Organiser();
            //int value = pbShowProgress.Value;
            //pbShowProgress.Value = value + 10;
            //dataOrganiser.GetCountryLink();
            //pbShowProgress.Value = value + 25;
            //dataOrganiser.GetCompetitionData();
            //pbShowProgress.Value = value + 25;
            //dataOrganiser.GetHomeFormsData();
            //pbShowProgress.Value = value + 40;
            ////pbShowProgress.Value = 100;
        }

        private void rdbON_CheckedChanged(object sender, EventArgs e)
        {
            //numAveWinLose.Enabled = true;
        }

        private void rdbOFF_CheckedChanged(object sender, EventArgs e)
        {
            //numAveWinLose.Enabled = false;
        }

        private void chkConsistancy_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void frmFootball_Load_1(object sender, EventArgs e)
        {
            Data_Organiser data = new Data_Organiser();
            Team team = new Team();
            //data.GetCountryLink();
            //data.GetCompetitionData();
            //team.GeneratePoints();
            //data.GetHomeFormsData();

//            double homeWins, awayWins;
//            string date = "12/24/2018";
//            double minPercent = 70;
//            double maxPercent = 80;
//            using (IDbConnection conn = data.Connection())
//            {
//                List<Fixture> retval = conn.Query<Fixture>(@"SELECT * FROM [dbo].[FIXTURES] 
//                                                   WHERE [dateOfmatch] = @Date 
//                                                   ORDER BY [timeOfMatch] DESC",
//                    new
//                    {
//                        Date = Convert.ToDateTime(date)
//                    }).ToList();

//                foreach (Fixture fixItem in retval)
//                {
//                    try
//                    {
//                        homeWins = conn.Query<double>("[dbo].[sp_GetSeasonPerformance]",
//                                new
//                                {
//                                    TeamName = fixItem.homeTeam,
//                                    Country = fixItem.country,
//                                    Competition = fixItem.competition
//                                },commandType: CommandType.StoredProcedure).FirstOrDefault();

//                    awayWins = conn.Query<double>("[dbo].[sp_GetSeasonPerformance]",
//                                new
//                                {
//                                    TeamName = fixItem.awayTeam,
//                                    Country = fixItem.country,
//                                    Competition = fixItem.competition
//                                }, commandType: CommandType.StoredProcedure).FirstOrDefault();
//                    }
//                    catch (Exception ex)
//                    {
//                        continue;
//                    }

//                    Debug.WriteLineIf((homeWins >= minPercent && homeWins < maxPercent) || (awayWins >= minPercent && homeWins >= maxPercent),
//                        "\n" + fixItem.homeTeam + "---> " + homeWins + " VS " + awayWins + 
//                        " <---" + fixItem.awayTeam + " ===" + fixItem.timeOfMatch + "===");
//                    Debug.WriteLineIf((homeWins >= minPercent && homeWins < maxPercent) || (awayWins >= minPercent && homeWins >= maxPercent), 
//                        fixItem.competition);
//                    Debug.WriteLineIf((homeWins >= minPercent && homeWins < maxPercent) || (awayWins >= minPercent && homeWins >= maxPercent),
//                        fixItem.country);
//                }
//            }
        }

        private void GetCompetitionTree()
        {
            //using (SampleDataDataContext DbData = new SampleDataDataContext())
            //{
            //    List<Country> country = DbData.COUNTRies.Select(c => (c)).ToList();

            //    foreach (Country countryTree in country)
            //    {
            //        string[] competition = DbData.COMPETITIONs
            //            .Where(c => (c.country.Equals(countryTree.country_Name)))
            //            .Select(x => (x.titleOfCompetition)).ToArray();
            //        int countCompetition = competition.Length;
            //        TreeNode[] tree = new TreeNode[countCompetition];
                    
            //        for (int i = 0; i < countCompetition; i++)
            //        {
            //            TreeNode node = new TreeNode();
            //            node.Text = competition[i];
            //            node.Name = "n" + competition[i];
            //            tree[i] = node;
            //        }

            //        treeView1.Nodes.Add(new TreeNode(countryTree.country_Name, tree));
            //    }
            //}
        }

        bool available = true;

        private void btnFixtures_Click(object sender, EventArgs e)
        {
            Pages pages = new Pages();
            FixtureControl fixCon = new FixtureControl();

            pages.Location = new Point(271, 535);
            fixCon.Location = new Point(271, 15);

            if (available)
            {
                pnlBelow.Controls.Add(pages);
                pnlBelow.Controls.Add(fixCon);
                available = false;
            }
            else
            {
                pnlBelow.Controls.Remove(fixCon);
                pnlBelow.Controls.Remove(pages);
            }
        }

        private void btnQuickUpdate_Click_1(object sender, EventArgs e)
        {
            Results results = new Results();
            Data_Organiser dataOrganiser = new Data_Organiser();
            //int value = pbShowProgress.Value;
            //pbShowProgress.Value = value + 10;
            dataOrganiser.GetCountryLink();
            //pbShowProgress.Value = value + 25;
            dataOrganiser.GetCompetitionData();
            //pbShowProgress.Value = value + 25;
            dataOrganiser.GetHomeFormsData();
            //pbShowProgress.Value = value + 40;
            //pbShowProgress.Value = 100;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsControl setCon = new SettingsControl();
            setCon.Location = new Point(271, 15);
            pnlBelow.Controls.Add(setCon);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Results results = new Results();
            Data_Organiser dataOrganiser = new Data_Organiser();
            int value = 0;
            //pbShowProgress.Value = value + 5;
            ///dataOrganiser.GetCountryLink();
            //pbShowProgress.Value = value + 5;
            ///dataOrganiser.GetCompetitionData();
            //pbShowProgress.Value = value + 5;
            //dataOrganiser.GetHomeFormsData();
            //pbShowProgress.Value = value + 5;
            //results.FullUpdateOfResults();
            //pbShowProgress.Value = 100;
            //File_Organiser objFile = new File_Organiser();
            
            Fixture fixture = new Fixture();
            //objFile.GetFilesFromFolder(results.FileName, results.NumOfRowsToSkip, results.GroupLoop, "Results");
            //objFile.GetFilesFromFolder(fixture.FileName, fixture.NumOfRowsToSkip, fixture.GroupLoop, "Fixture");
            Team team = new Team();
            team.GeneratePoints();
        }

        private void pnlBelow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
