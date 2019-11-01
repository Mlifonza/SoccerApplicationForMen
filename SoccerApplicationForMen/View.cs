using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections;

namespace SoccerApplicationForMen
{
    public class View
    {
        #region Variables

        public Panel pnlFixture;
        ProgressBar pbShowProgress;
        Panel pnlPages;
        
        Label matchCount;

        #endregion

        #region Properties



        #endregion

        #region Constructor

        public View(Panel cPnlFixture, ProgressBar cPbShowProgress, Panel cPnlPages)
        {
            pnlFixture = cPnlFixture;
            pbShowProgress = cPbShowProgress;
            matchCount = Pages.matchCount;
            pnlPages = cPnlPages;
        }

        #endregion
        
        #region Methods

        public void ShowFixtures(DateTime pDate, List<Team> pListOfTeamsToDisplay, int pIndex, bool pager)
        {
            Pages pages = new Pages();
            pnlFixture.Controls.Clear();
            List<TextBox> txthomeTeam = new List<TextBox>();
            List<TextBox> txtAwayTeam = new List<TextBox>();
            List<Label> lblVerses = new List<Label>();

            GamePlay game = new GamePlay();
            Match match = new Match();
            List<GamePlay> listOfGames = game.GetFixture(pDate);
            List<GamePlay> gamesBroughtForward;
            //Only enters AddToList if the list of teams to display are not null
            if (pager || pListOfTeamsToDisplay == null)
            {
                gamesBroughtForward = pages.AddToList(listOfGames, pIndex, pnlPages).ToList();
            }
            else
            {
                gamesBroughtForward = listOfGames;
            }

            //gamesBroughtForward.RemoveAll(r => (r.Equals(null)));
            this.ReleaseFixtureOrResults(gamesBroughtForward, match, pListOfTeamsToDisplay);
        }

        public void ReleaseFixtureOrResults(List<GamePlay> pListOfGames, Match pMatch, List<Team> pListOfTeamsToDisplay)
        {
            pbShowProgress.PerformStep();
            int fixtureCount = 0;
            //List of team names to display
            List<string> teamNamesArray = new List<string>();
            if (pListOfTeamsToDisplay != null)
            {
                foreach (Team teamName in pListOfTeamsToDisplay)
                {
                    teamNamesArray.Add(teamName.nameOfTeam);
                }
            }

            foreach (GamePlay fix in pListOfGames)
            {
                try
                {
                    pMatch.HomeTeam(fix.HomeTeam, fix.HomePrediction);
                    pMatch.HomeWins(fix.HomeWins);
                    pMatch.HomeLosses(fix.HomeLosses);
                    pMatch.HomeDraws(fix.HomeDraws);

                    pMatch.AwayTeam(fix.AwayTeam);
                    pMatch.AwayWins(fix.AwayWins);
                    pMatch.AwayLosses(fix.AwayLosses);
                    pMatch.AwayDraws(fix.AwayDraws);

                    pMatch.GetHomeForm1(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetHomeForm2(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetHomeForm3(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetHomeForm4(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetHomeForm5(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);

                    pMatch.GetAwayForm1(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetAwayForm2(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetAwayForm3(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetAwayForm4(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);
                    pMatch.GetAwayForm5(fix.Country, fix.Competition, fix.HomeTeam, fix.AwayTeam);

                    //Add all the compenents from Match Class
                    GroupBox groupbox = pMatch.AddComponent(fix.Date, fix.Time, fix.Country, fix.Competition);

                    //Display the fixture that matches the condition
                    if (((teamNamesArray.Contains(fix.HomeTeam) || teamNamesArray.Contains(fix.AwayTeam))) && (pListOfTeamsToDisplay != null))
                    {
                        pnlFixture.Controls.Add(groupbox);
                        fixtureCount++;
                        pbShowProgress.PerformStep();
                    }
                    else if (pListOfTeamsToDisplay == null)
                    {
                        pnlFixture.Controls.Add(groupbox);
                        fixtureCount++;
                        pbShowProgress.PerformStep();
                    }

                    matchCount.Text = fixtureCount.ToString();
                }
                catch (NullReferenceException nEx)
                {
                    continue;
                }
            }
            pbShowProgress.Value = 100;
            //MessageBox.Show("Completed");
        }

        public void RollMethod(ref int pIndex, DateTime selectedDate)
        {
            for (int i = 0; i < pnlPages.Controls.Count; i++)
            {
                string text = pnlPages.Controls[i].ToString();
                pnlPages.Controls[i].Visible = false;
            }

            //Set pager variable to true because it is possible to have more than 
            //50 records when you retrieve an unfiltered fixture list
            bool pager = true;
            this.ShowFixtures(selectedDate, null, pIndex, pager);
        }

        #endregion
    }
}
