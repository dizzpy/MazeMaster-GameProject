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
        private int rewardsCount = 00;


        public Level01View()
        {
            InitializeComponent();
            MouseMoveStart();
        }


        private void Level01View_Load(object sender, EventArgs e)
        {
            RewardCount.Text = rewardsCount.ToString();
            AttemptCount.Text = (maxAttempts - numberOfAttempt).ToString();
        }



        private void EndPoint(object sender, EventArgs e)
        {
            if(rewardsCount == 100)
            {
                MessageBox.Show("Congratulations! You have completed the level!");
                this.Close();
                Level02View level02 = new Level02View();
                level02.Show();
            }
            else
            {
                MessageBox.Show("You need to collect all the rewards to complete the level!");
                MouseMoveStart();
                numberOfAttempt = 3;
                AttemptCount.Text= numberOfAttempt.ToString();

            }
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
                MessageBox.Show("You hit the wall! Try again!");
                AttemptCount.Text = (maxAttempts - numberOfAttempt).ToString();
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

        private void StarsPanel_MouseEnter(object sender, EventArgs e)
        {
            Control star = (Control)sender;
            if (star.Tag != null && star.Tag.ToString() == "star-rewards")
            {
                rewardsCount += 10;
                RewardCount.Text = rewardsCount.ToString();

                star.Visible = false; // Hide the star when the reward is collected
            }
        }



    }
}
