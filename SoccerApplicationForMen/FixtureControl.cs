using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SoccerApplicationForMen
{
    public partial class FixtureControl : UserControl
    {
        List<Team> listOfTeamsToDisplay = null;
        

        int pageIndex = 0;
        int numberOfPages = 0;
        public static DateTime selectedDate;
        public static Panel fixturePanel;
        public static decimal sNumAveWinLose;
        public static decimal sGamesToCount;
        public static RadioButton sRdbON;
        ProgressBar progress;
        Panel pnlPages;
        View view;
        public FixtureControl()
        {
            InitializeComponent();
            selectedDate = dtpFilterDate.Value;
            pnlPages = Pages.pages;
            progress = Pages.progress;
            fixturePanel = pnlFixture;
            view = new View(fixturePanel, progress, pnlPages);
            //pnlPages = Pages.pages;
        }

        private void FixtureControl_Load(object sender, EventArgs e)
        {
            string test = "";
            fixturePanel = pnlFixture;

            this.InsertComboBox();
        }

        private void InsertComboBox()
        {
            cmbPlayed.DataSource = new List<string>() { "Atleast", "Absolute", "Less Than" };
            cmbWins.DataSource = new List<string>() { "Atleast", "Absolute", "Less Than" };
            cmbLosses.DataSource = new List<string>() { "Atleast", "Absolute", "Less Than" };
            cmbGD.DataSource = new List<string>() { "Atleast", "Absolute", "Less Than" };
            cmbDraws.DataSource = new List<string>() { "Atleast", "Absolute", "Less Than" };
        }

        private void btnRollFixture_Click(object sender, EventArgs e)
        {
            pageIndex = 0;
            view.RollMethod(ref pageIndex, selectedDate);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < pnlPages.Controls.Count; i++)
            {
                string text = pnlPages.Controls[i].ToString();
                pnlPages.Controls[i].Visible = false;
            }

            int numberOfPreviousMatchesToCount = (int)numGamesToCount.Value;
            int averageWinLose = (int)numAveWinLose.Value;
            selectedDate = dtpFilterDate.Value;
            Filter getFilter = new Filter();
            switch (chkConsistancy.SelectedIndex)
            {
                case 0: listOfTeamsToDisplay = null;
                    break;
                case 1: //listOfTeamsToDisplay = getFilter.GetHomeWinner(numberOfPreviousMatchesToCount);
                    break;
                case 2: //listOfTeamsToDisplay = getFilter.GetAwayWinner(numberOfPreviousMatchesToCount);
                    break;
                case 3: //listOfTeamsToDisplay = getFilter.GetOnFormWinner(numberOfPreviousMatchesToCount);
                    break;
                case 4: //listOfTeamsToDisplay = getFilter.GetOnFormLoser(numberOfPreviousMatchesToCount);
                    break;
                case 5: listOfTeamsToDisplay = getFilter.GetRegularScorer(numberOfPreviousMatchesToCount);
                    break;
                case 6: //listOfTeamsToDisplay = getFilter.GetHomeLoser(numberOfPreviousMatchesToCount);
                    break;
                case 7: //listOfTeamsToDisplay = getFilter.GetAwayLoser(numberOfPreviousMatchesToCount);
                    break;
                case 8: //listOfTeamsToDisplay = getFilter.GetRegularDrawer(numberOfPreviousMatchesToCount);
                    break;
                case 9: //listOfTeamsToDisplay = getFilter.GetRegularHomeDrawer(numberOfPreviousMatchesToCount);
                    break;
                case 10: //listOfTeamsToDisplay = getFilter.GetAwayDrawer(numberOfPreviousMatchesToCount);
                    break;
                case 11: //listOfTeamsToDisplay = getFilter.GetRegularCleanSheets(numberOfPreviousMatchesToCount);
                    break;
                default: listOfTeamsToDisplay = null;
                    break;
            }

            if (rdbON.Checked)
            {
                listOfTeamsToDisplay = getFilter.GetSeasonPerformer(averageWinLose);
            }
            //Set pager variable to false because it is possible to have less than 
            //50 records when you retrieve an filtered fixture list
            bool pager = false;
            //Call to show the fixtures
            view.ShowFixtures(selectedDate, listOfTeamsToDisplay, pageIndex, pager);
        }

        private void chkConsistancy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter getFilter = new Filter();
            if (chkConsistancy.SelectedIndex == 0)
            {
                for (int i = 0; i < chkConsistancy.Items.Count; i++)
                {
                    chkConsistancy.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chkConsistancy.Items.Count; i++)
                {
                    chkConsistancy.SetItemChecked(i, false);
                }
            }
        }

        ////private void rdbON_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    numAveWinLose.Enabled = true;
        ////    sRdbON.Checked = true;
        ////}

        ////private void rdbOFF_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    numAveWinLose.Enabled = false;
        ////    sRdbON.Checked = false;
        ////}

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

        //private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(5);
        //}

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

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(10);
        //}

        //private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    RollMethod(20);
        //}

        private void btnClearList_Click(object sender, EventArgs e)
        {
            pnlFixture.Controls.Clear();
        }

        private void rdbOFF_CheckedChanged_1(object sender, EventArgs e)
        {
            numAveWinLose.Enabled = false;
        }

        private void rdbON_CheckedChanged_2(object sender, EventArgs e)
        {
            numAveWinLose.Enabled = true;
        }

        private void btnRollFixture_Click_1(object sender, EventArgs e)
        {

        }

        private void btnApply_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
