namespace Final_Task.Games
{
    public abstract class CasinoGameBase
    {
        public abstract void PlayGame();


        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;


        protected void OnWinInvoke()
        {
            Console.WriteLine("You won");
            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        {
            Console.WriteLine("You lost");
            OnLoose?.Invoke();
        }

        protected void OnDrawInvoke()
        {
            Console.WriteLine("Draw");
            OnDraw?.Invoke();
        }

        protected abstract void FactoryMethod();
    }
}
