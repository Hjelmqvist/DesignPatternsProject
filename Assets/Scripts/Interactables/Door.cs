using UnityEngine.Events;

public class Door : Interactable
{
    int _maxScore;
    public UnityEvent<ScoreArgs> OnReachedDoor;

    public struct ScoreArgs
    {
        public readonly int Score;
        public readonly int MaxScore;

        public ScoreArgs(int score, int maxScore)
        {
            Score = score;
            MaxScore = maxScore;
        }
    }

    private void Awake()
    {
        Coin[] coins = FindObjectsOfType<Coin>();
        foreach (Coin coin in coins)
        {
            _maxScore += coin.Value;
        }
    }

    protected override void Interact(PlayerCharacter player)
    {
        OnReachedDoor.Invoke( new ScoreArgs( Wallet.Instance.Gold, _maxScore ) );
    }
}