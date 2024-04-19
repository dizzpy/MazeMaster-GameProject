using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeMasterGame.Views.LevelViews
{
    public partial class Level01View : Form
    {
        public Level01View()
        {
            InitializeComponent();
            MouseMoveStart();
        }

        private void EndPoint(object sender, EventArgs e)
        {
            MessageBox.Show("Congratulations! You have completed the level!");
            this.Close();
            DashboardView dashboard = new DashboardView();
            dashboard.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MouseMoveStart() {
        
            Point startPoint = panel3.Location;
            startPoint.Offset(175, 15);
            Cursor.Position = PointToScreen(startPoint);
        }
    }
}
