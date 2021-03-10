using System;
using System.Timers;

namespace example
{
    public class Mole
    {
        public bool Visible = false;
        private Timer _moleTimer;
        private GameBoard _gameboard;

        public Mole(GameBoard gameboard)
        {
            _gameboard = gameboard;
        }
        public void Appear() 
        {
            Visible = true;
            _moleTimer = new Timer();
            _moleTimer.Interval = 2000;
            _moleTimer.Elapsed += MoletimerElapsed;
            _moleTimer.Start();
        }

        public void MoletimerElapsed(Object source, ElapsedEventArgs e) 
        {
            Disappear();
            _gameboard.UpdateMolePosition();
        }

        public void Disappear() {
            _moleTimer.Stop();
            Visible = false;
        }
    }
}