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
        private int numberOfAttempt = 0;
        private int maxAttempts = 3;

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

        private void WallHit(object sender, EventArgs e)
        {
            numberOfAttempt++;
            if (numberOfAttempt >= maxAttempts)
            {
                GameOver();
            }
            else
            {
                MessageBox.Show("You hit the wall and you have " + (maxAttempts - numberOfAttempt) + " attempts left! Try again!");
                MouseMoveStart();
            }
        }

        private void GameOver()
        {
            MessageBox.Show("Game Over !");
            this.Close();
            DashboardView dashboard = new DashboardView();
            dashboard.Show();
        }


    }
}
