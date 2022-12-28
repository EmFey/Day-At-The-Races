using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public partial class Form1 : Form
    {
        GreyHound[] greyHound = new GreyHound[4];
        Guy[] guy = new Guy[3];
        Random MyRandomizer = new Random();
        public Form1()
        {
            InitializeComponent();

            greyHound[0] = new GreyHound()
            {
                MyPictureBox = dog1,
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLenth = racetrackPictureBox.Width - dog1.Width,
                Randomizer = MyRandomizer
            };

            greyHound[1] = new GreyHound()
            {
                MyPictureBox = dog2,
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLenth = racetrackPictureBox.Width - dog2.Width,
                Randomizer = MyRandomizer
            };

            greyHound[2] = new GreyHound()
            {
                MyPictureBox = dog3,
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLenth = racetrackPictureBox.Width - dog3.Width,
                Randomizer = MyRandomizer
            };
            greyHound[3] = new GreyHound()
            {
                MyPictureBox = dog4,
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLenth = racetrackPictureBox.Width - dog4.Width,
                Randomizer = MyRandomizer
            };

            guy[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel };
            guy[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            guy[2] = new Guy() { Name = "Sam", Cash = 45, MyRadioButton = samRadioButton, MyLabel = samBetLabel };

            minimumBetLabel.Text = "Minimum bet: " + cashBet.Minimum + " bucks";

            refreshGuyState();
        }
        public void refreshGuyState()
        {
            for(int i = 0; i < guy.Length; i++)
            {
                guy[i].ClearBet();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            int winningDog = 0;

            for(int i = 0; i< greyHound.Length; i++)
            {
                if (greyHound[i].Run())
                {
                    timer1.Stop();
                    winningDog = i + 1;
                    MessageBox.Show("Dog #" + winningDog + " won the race");

                    for (int b = 0; b < guy.Length; b++)
                    {
                        guy[b].Collect(winningDog);
                    }

                    refreshGuyState();
                    bettingGroup.Enabled = true;
                    break;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < greyHound.Length; c++)
            {
                greyHound[c].TakeStartingPosition();
            }

            bettingGroup.Enabled = false;
            timer1.Start();
        }
    }
}
