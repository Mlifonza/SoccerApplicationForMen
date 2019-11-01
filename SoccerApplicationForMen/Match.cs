using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Data;
using Dapper;

namespace SoccerApplicationForMen
{
    public sealed class Match
    {
        Data_Organiser data = new Data_Organiser();
        TextBox homeTeam;
        TextBox homeWins;
        TextBox homeLosses;
        TextBox homeDraws;

        TextBox awayTeam;
        TextBox awayWins;
        TextBox awayLosses;
        TextBox awayDraws;

        TextBox homeForm_1;
        TextBox homeForm_2;
        TextBox homeForm_3;
        TextBox homeForm_4;
        TextBox homeForm_5;

        TextBox awayForm_1;
        TextBox awayForm_2;
        TextBox awayForm_3;
        TextBox awayForm_4;
        TextBox awayForm_5;

        private int teamNameMargin = 3;
        private int homeTeamLocX = 3;
        private int awayTeamLocX = 210;
        private int teamsLocY = 26;
        private int statsLocY = 52;
        private int teamsWidth = 195;
        private int teamsHeight = 20;
        private int statsWidth = 65;
        private int formHeight = 20;
        private int formWidth = 32;
        //private int formLocY = 78;

        public GroupBox AddComponent(DateTime pDate, string pTime, string pCountry, string pCompetition)
        {
            GroupBox group = new GroupBox();
            DataGridView dgv = new DataGridView();
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            group.Width = 412;
            group.Height = 111;
            group.Text = "Date: " + pDate.ToString() + "   Time: " + pTime + "\nCompetition: " + pCompetition.ToUpper() + "    Country: " + pCountry.ToUpper();
            group.BackColor = System.Drawing.Color.Silver;

            group.Controls.AddRange(new Control[]
            {
                this.homeTeam,
                this.awayTeam,

                this.homeWins,
                this.homeLosses,
                this.homeDraws,

                this.awayWins,
                this.awayLosses,
                this.awayDraws,

                this.homeForm_1,
                this.homeForm_2,
                this.homeForm_3,
                this.homeForm_4,
                this.homeForm_5,

                this.awayForm_1,
                this.awayForm_2,
                this.awayForm_3,
                this.awayForm_4,
                this.awayForm_5,
            });
            
            return group;
        }

        #region FixtureMethods

        public void HomeTeam(string pHomeTeam, string pHomePrediction)
        {
            homeTeam = new TextBox()
            {
                Location = new System.Drawing.Point(homeTeamLocX, teamsLocY),
                Margin = new Padding(3),
                Width = teamsWidth,
                Height = teamsHeight,
                Text = pHomeTeam,
                ReadOnly = true,
                BackColor = System.Drawing.Color.Aqua
            };
        }

        public void AwayTeam(string pAwayTeam)
        {
            awayTeam = new TextBox()
            {
                Text = pAwayTeam,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(awayTeamLocX, teamsLocY),
                Width = teamsWidth,
                Height = teamsHeight,
                ReadOnly = true,
                BackColor = System.Drawing.Color.Aqua
            };
        }

        public void HomeWins(double percent)
        {
            homeWins = new TextBox()
            {
                Text = "Wins: " + percent + "%",
                Width = statsWidth,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(homeTeamLocX, statsLocY),
                ReadOnly = true
            };
        }

        public void HomeLosses(double percent)
        {
            int x = homeWins.Location.X;
            homeLosses = new TextBox()
            {
                Text = "Lose: " + percent + "%",
                Width = statsWidth - 4,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(x + statsWidth + 2, statsLocY),
                ReadOnly = true
            };
        }

        public void HomeDraws(double percent)
        {
            int x = homeLosses.Location.X;
            int width = homeLosses.Width;
            homeDraws = new TextBox()
            {
                Text = "Draw: " + percent + "%",
                Width = statsWidth,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(x + width + 2, statsLocY),
                ReadOnly = true
            };
        }

        public void AwayWins(double percent)
        {
            awayWins = new TextBox()
            {
                Text = "Wins: " + percent + "%",
                Width = statsWidth,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(awayTeamLocX, statsLocY),
                ReadOnly = true
            };
        }

        public void AwayLosses(double percent)
        {
            int x = awayWins.Location.X;
            awayLosses = new TextBox()
            {
                Text = "Lose: " + percent + "%",
                Width = statsWidth - 4,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(x + statsWidth + 2, statsLocY),
                ReadOnly = true
            };
        }

        public void AwayDraws(double percent)
        {
            int x = awayLosses.Location.X;
            int width = awayLosses.Width;
            awayDraws = new TextBox()
            {
                Text = "Draw: " + percent + "%",
                Width = statsWidth,
                Height = teamsHeight,
                Margin = new Padding(3),
                Location = new System.Drawing.Point(x + width + 2, statsLocY),
                ReadOnly = true
            };
        }

        public void GetHomeForm1(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(1, pHomeTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            homeForm_1 = new TextBox()
            {
                Location = new System.Drawing.Point(homeTeamLocX + 14, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetHomeForm2(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(2, pHomeTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = homeForm_1.Location.X;
            homeForm_2 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetHomeForm3(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(3, pHomeTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = homeForm_2.Location.X;
            homeForm_3 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetHomeForm4(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(4, pHomeTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = homeForm_3.Location.X;
            homeForm_4 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetHomeForm5(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(5, pHomeTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = homeForm_4.Location.X;
            homeForm_5 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetAwayForm1(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(1, pAwayTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            awayForm_1 = new TextBox()
            {
                Location = new System.Drawing.Point(awayTeamLocX + 14, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetAwayForm2(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(2, pAwayTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = awayForm_1.Location.X;
            awayForm_2 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetAwayForm3(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(3, pAwayTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = awayForm_2.Location.X;
            awayForm_3 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetAwayForm4(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(4, pAwayTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = awayForm_3.Location.X;
            awayForm_4 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        public void GetAwayForm5(string pCountry, string pCompetition, string pHomeTeam, string pAwayTeam)
        {
            Tuple<char?, Color> symbolValue = this.GetFormValueSymbol(5, pAwayTeam, pCountry, pCompetition);
            string symbolText = symbolValue.Item1.Value.ToString();
            Color color = symbolValue.Item2;
            int x = awayForm_4.Location.X;
            awayForm_5 = new TextBox()
            {
                Location = new System.Drawing.Point(x + formWidth + 2, teamsLocY + 52),
                Margin = new Padding(3),
                Width = formWidth,
                Height = formHeight,
                Text = symbolText,
                BackColor = color,
                TextAlign = HorizontalAlignment.Center
            };
        }

        private Tuple<char?, Color> GetFormValueSymbol(int pFormColumn, string pTeamName, string pCountry, string pCompetition)
        {
            TeamsForm homeTeamForm;
            TeamsForm awayTeamForm;
            char? r1 = null;//, r2, r3, r4, r5;
            Color symbolColor = Color.White;
            using (IDbConnection conn = data.Connection())
            {
                //Tuple<char, char> name;
                //new Tuple<char, char>('s', 'n');
                //object obj = new { Name = pCountry };
                homeTeamForm = conn.Query<TeamsForm>(@"SELECT * FROM [dbo].[TEAMSFORM] WHERE [nameOfTeam]=@TeamName AND 
                                                  [competition]=@Competition AND [country]=@Country",
                                                  new 
                                                  {
                                                      TeamName = pTeamName,
                                                      Competition = pCompetition,
                                                      Country = pCountry
                                                  }).FirstOrDefault();

                awayTeamForm = conn.Query<TeamsForm>(@"SELECT * FROM [dbo].[TEAMSFORM] WHERE [nameOfTeam]=@TeamName AND 
                                                  [competition]=@Competition AND [country]=@Country",
                                                  new
                                                  {
                                                      TeamName = pTeamName,
                                                      Competition = pCompetition,
                                                      Country = pCountry
                                                  }).FirstOrDefault();

                //homeTeamForm = DbData.TEAMSFORMs.SingleOrDefault(t => (t.nameOfTeam.Equals(pTeamName)
                //    && (t.competition.Equals(pCompetition)) && (t.country.Equals(pCountry))));
                //awayTeamForm = DbData.TEAMSFORMs.SingleOrDefault(t => (t.nameOfTeam.Equals(pTeamName)
                //    && (t.competition.Equals(pCompetition)) && (t.country.Equals(pCountry))));

            }

            if (pTeamName == homeTeamForm.nameOfTeam || homeTeamForm != null)
            {
                switch (pFormColumn)
                {
                    case 1: r1 = homeTeamForm._1;
                        symbolColor = GetColor(r1);
                        break;
                    case 2: r1 = homeTeamForm._2;
                        symbolColor = GetColor(r1);
                        break;
                    case 3: r1 = homeTeamForm._3;
                        symbolColor = GetColor(r1);
                        break;
                    case 4: r1 = homeTeamForm._4;
                        symbolColor = GetColor(r1);
                        break;
                    case 5: r1 = homeTeamForm._5;
                        symbolColor = GetColor(r1);
                        break;
                    default: MessageBox.Show("Invalid input");
                        break;
                }
            }
            else
            {
                switch (pFormColumn)
                {
                    case 1: r1 = awayTeamForm._1;
                        symbolColor = GetColor(r1);
                        break;
                    case 2: r1 = awayTeamForm._2;
                        symbolColor = GetColor(r1);
                        break;
                    case 3: r1 = awayTeamForm._3;
                        symbolColor = GetColor(r1);
                        break;
                    case 4: r1 = awayTeamForm._4;
                        symbolColor = GetColor(r1);
                        break;
                    case 5: r1 = awayTeamForm._5;
                        symbolColor = GetColor(r1);
                        break;
                    default: MessageBox.Show("Invalid input");
                        break;
                }
            }

            return new Tuple<char?, Color>(r1, symbolColor);
        }

        private System.Drawing.Color GetColor(char? symbol)
        {
            if (symbol == 'W')
            {
                return System.Drawing.Color.Green;
            }
            else if (symbol == 'L')
            {
                return System.Drawing.Color.Red;
            }
            else if (symbol == 'D')
            {
                return System.Drawing.Color.Orange;
            }
            else
            {
                return System.Drawing.Color.Black;
            }
        }

        #endregion

        
    }
}
