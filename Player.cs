namespace example
{
    public class Player
    {
        public GameBoard GameBoard;
        public Player()
        {
            GameBoard = new GameBoard();
        }

        public void HitBoard(int position)
        {
            GameBoard.DetermineIfHit(position - 1);
        }
    }
}