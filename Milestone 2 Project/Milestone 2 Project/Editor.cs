using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Milestone_2_Project
{
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void BlueRedTile_CheckedChanged(object sender, EventArgs e)
        {
            //do not show the red and blue tiles
            
        }

        private void GreenTile_CheckedChanged(object sender, EventArgs e)
        {
            //change normal tiles to not show

        }

        private void PurpleTile_CheckedChanged(object sender, EventArgs e)
        {
            //change death tiles to not show

        }

        private void YellowTile_CheckedChanged(object sender, EventArgs e)
        {
            //change move tile to not show
            
        }
    }
}
