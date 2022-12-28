using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    class GreyHound
    {
        public int StartingPosition;
        public int RacetrackLenth;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            Location += Randomizer.Next(4);
            MyPictureBox.Left = StartingPosition + Location;
            if(MyPictureBox.Left >= RacetrackLenth - MyPictureBox.Width + 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
