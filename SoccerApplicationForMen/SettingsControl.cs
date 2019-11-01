using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerApplicationForMen
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }

        private void btnGamePlay_Click(object sender, EventArgs e)
        {
            GamePlaySettings gameplaySetting = new GamePlaySettings();
            gameplaySetting.Location = new Point(5, 7);
            pnlTypes.Controls.Add(gameplaySetting);
        }
    }
}
