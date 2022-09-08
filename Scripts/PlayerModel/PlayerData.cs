public class PlayerData
{
    public static int CurrentBitcoin { get; private set; } = 1;
    public int SavedBitcoin = 0;

    public void SetCurrentBitcoin(int value)
    {
        if (value < 1) return;
        CurrentBitcoin = value;
    }
}