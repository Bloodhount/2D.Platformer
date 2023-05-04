namespace PlatformerMVC
{
    public class CoinView : InteractiveObjectView
    {
        private int _ScorePoint = 5;
        public int AddCoinPoint { get => _ScorePoint; set => _ScorePoint = value; }
    }
}
