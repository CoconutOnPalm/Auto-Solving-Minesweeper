using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Tile
    {
        public Tile() 
        {
            int chancePrc = 10;
            Arm(chancePrc);

            Checked = false;
        }

        public Tile(int chancePrc)
        {
            Arm(chancePrc);

            Checked = false;
        }


        public void Arm(int chancePrc)
        {
            Random random = new Random();
            if (random.Next(100) < chancePrc)
            {
                m_isBomb = true;
                m_threatIndicator = 100;
            }
            else
            {
                m_threatIndicator = 0;
            }
        }

        public void Disarm()
        {
            m_isBomb = false;
            m_threatIndicator = 0;
        }

        public void ArmForSure()
        {
            m_isBomb = true;
            m_threatIndicator = 100;
        }
        
        public bool IsBomb() { return m_isBomb; }


        public int ThreatIndicator { get => m_threatIndicator; set => m_threatIndicator = value; }
        public bool Checked { get => m_checked; set => m_checked = value; }
        public bool Flagged { get => m_flagged; set => m_flagged = value; }

        bool m_isBomb;
        int m_threatIndicator;

        bool m_checked;
        bool m_flagged;

    }
}
