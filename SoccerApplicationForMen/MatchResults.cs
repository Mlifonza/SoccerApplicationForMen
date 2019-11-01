using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace SoccerApplicationForMen
{
    public sealed class MatchResults
    {
        #region Properties

        TextBox homeTeam;
        TextBox awayTeam;
        TextBox homeScore;
        TextBox awayScore;

        private int homeTeamLocX = 3;
        private int awayTeamLocX = 210;
        private int teamsLocY = 26;
        private int teamsWidth = 163;
        private int teamsHeight = 20;
        private int scoreWidth = 32;

        #endregion

        #region Methods

        public GroupBox AddComponent(DateTime pDate, string pTime, string pCountry, string pCompetition)
        {
            GroupBox group = new GroupBox();

            group.Width = 412;
            group.Height = 65;
            group.Text = "Date: " + pDate + "   Time: " + pTime + "     Competition: " + pCompetition + "    Country: " + pCountry;

            group.Controls.AddRange(new Control[]
            {
                this.homeTeam,
                this.awayTeam,
                this.homeScore,
                this.awayScore
            });

            return group;
        }

        public void HomeTeam(string pHomeTeam)
        {
            homeTeam = new TextBox()
            {
                Margin = new Padding(3),
                Location = new System.Drawing.Point(homeTeamLocX, teamsLocY),
                Width = teamsWidth,
                Height = teamsHeight,
                Text = pHomeTeam,
                ReadOnly = true
            };
        }

        public void AwayTeam(string pAwayTeam)
        {
            awayTeam = new TextBox()
            {
                Margin = new Padding(3),
                Location = new System.Drawing.Point(awayTeamLocX, teamsLocY),
                Width = teamsWidth,
                Height = teamsHeight,
                Text = pAwayTeam,
                ReadOnly = true
            };
        }

        public void AwayScore(int pAwayScore)
        {
            awayScore = new TextBox()
            {
                Margin = new Padding(3),
                Location = new System.Drawing.Point(awayTeamLocX + teamsWidth + 4, teamsLocY),
                Width = scoreWidth,
                Height = teamsHeight,
                Text = pAwayScore.ToString(),
                ReadOnly = true
            };
        }

        public void HomeScore(int pHomeScore)
        {
            homeScore = new TextBox()
            {
                Margin = new Padding(3),
                Location = new System.Drawing.Point(homeTeamLocX + teamsWidth + 4, teamsLocY),
                Width = scoreWidth,
                Height = teamsHeight,
                Text = pHomeScore.ToString(),
                ReadOnly = true
            };
        }

        #endregion
    }
}
