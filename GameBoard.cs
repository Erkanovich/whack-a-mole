using System;
using System.Timers;

namespace example
{
    public class GameBoard
    {
        private int _points = 0;
        private int _misses = 0;
        private Mole[] _holes;
        private int _currentMolePosition;
        private bool _gameOver = false;
        public GameBoard()
        {
            _holes = new Mole[9];
            _holes[0] = new Mole(this);
            _holes[1] = new Mole(this);
            _holes[2] = new Mole(this);
            _holes[3] = new Mole(this);
            _holes[4] = new Mole(this);
            _holes[5] = new Mole(this);
            _holes[6] = new Mole(this);
            _holes[7] = new Mole(this);
            _holes[8] = new Mole(this);
        }

        public void StartGame()
        {
            StartGameTimer();
            UpdateMolePosition();
            HandlePlayerInput();
        }

        public void HandlePlayerInput()
        {
            int input;
            int.TryParse(char.ToString(Console.ReadKey().KeyChar), out input);

            if (_gameOver)
            {
                return;
            }

            if (input < 10 && input > 0)
            {
                var playerHitMole = DetermineIfHit(input - 1);
                
            }
            HandlePlayerInput();
        }

        public void StartGameTimer()
        {
            var gameTimer = new Timer();
            gameTimer.Interval = 10000;
            gameTimer.Elapsed += GameTimerElapsed;
            gameTimer.Enabled = true;
        }

        public void GameTimerElapsed(Object source, ElapsedEventArgs e)
        {
            EndGame();
        }

        public void EndGame()
        {
            _gameOver = true;
            Array.Clear(_holes, 0, _holes.Length);
            Console.Clear();
            Console.WriteLine("Game over");
            Console.WriteLine($"{_points} points!");
        }

        public void UpdateBoardLayout()
        {
            System.Console.Clear();

            for (int i = 0; i < _holes.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    System.Console.WriteLine();
                }
                if (_currentMolePosition == i)
                {
                    System.Console.Write("@|");
                }
                else
                {
                    System.Console.Write("0|");
                }
            }
        }

        public void UpdateMolePosition()
        {
            var random = new Random();
            var randomPosition = random.Next(1, 9);
            _holes[randomPosition].Appear();
            _currentMolePosition = randomPosition;
            UpdateBoardLayout();
        }

        public bool DetermineIfHit(int position)
        {
            if (_holes[position].Visible)
            {
                //Hit!
                _holes[position].Disappear();
                _points++;
                UpdateMolePosition();
                return true;
            }
            else 
            {
                // Miss!
                _misses++;
                if (_misses == 5)
                {
                    EndGame();
                }
                return true;
            }
        }
    }
}