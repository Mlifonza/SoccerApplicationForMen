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
    public partial class Pages : UserControl
    {
        int pageIndex = 0;
        //FixtureControl fixCon = new FixtureControl();
        DateTime selectedDate;
        
        public static ProgressBar progress;
        public static Label matchCount;
        public static Panel pages;
        Panel fixturePanel;
        View view;
        public Pages()
        {
            InitializeComponent();
            
            selectedDate = FixtureControl.selectedDate;
            progress = pbShowProgress;
            matchCount = lblFixtureCount;
            pages = pnlPages;
            fixturePanel = FixtureControl.fixturePanel;
            view = new View(fixturePanel, pbShowProgress, pnlPages);
        }

        private void Pages_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < pnlPages.Controls.Count; i++)
            {
                string text = pnlPages.Controls[i].ToString();
                pnlPages.Controls[i].Visible = false;
            }
        }

        //private void RollMethod(int pIndex)
        //{
        //    pageIndex = pIndex;

        //    for (int i = 0; i < pnlPages.Controls.Count; i++)
        //    {
        //        string text = pnlPages.Controls[i].ToString();
        //        pnlPages.Controls[i].Visible = false;
        //    }

        //    //Set pager variable to true because it is possible to have more than 
        //    //50 records when you retrieve an unfiltered fixture list
        //    bool pager = true;
        //    view.ShowFixtures(selectedDate, null, pageIndex, pager);
        //}

        public IEnumerable<GamePlay> AddToList(List<GamePlay> fixture, int index, Panel pPnlPages)
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

            Control control = pages.Controls[index];
            int numberOfPages = pageCollection.Count;
            for (int i = 0; i < numberOfPages; i++)
            {
                pPnlPages.Controls[i].Visible = true;
                string text = pages.Controls[i].ToString();
                pPnlPages.Controls[index].Font = new System.Drawing.Font(control.Font.Name, control.Font.Size,
                        control.Font.Style);
                //pnlPages.Controls.Add(control);
            }

            pPnlPages.Controls[index].Font = new System.Drawing.Font(control.Font.Name, control.Font.Size,
                        control.Font.Style ^ FontStyle.Bold);
            if (pageCollection.Count - 1 == index)
            {
                index = 0;
            }

            string test = "";
            return (IEnumerable<GamePlay>)pageCollection[index];

        }

        //private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 1;
        //    view.pnlFixture = FixtureControl.fixturePanel;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 2;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 3;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 4;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 5;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 6;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 7;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 8;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 9;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 10;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 11;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 12;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 13;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 14;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 15;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 16;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 17;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 18;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 19;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}

        //private void lnk1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    pageIndex = 20;
        //    view.RollMethod(ref pageIndex, selectedDate);
        //}
    }
}
