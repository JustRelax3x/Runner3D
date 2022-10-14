public class PlayerData
{
    public static int CurrentBitcoin { get; private set; } = 1;
    public int SavedBitcoin { get; private set; } = 0;
    public int SavedMoney { get; private set; } = 0;

    public void SetCurrentBitcoin(int value)
    {
        if (value < 1) return;
        CurrentBitcoin = value;
    }

    public void SaveBitcoin()
    {
        SavedBitcoin += CurrentBitcoin;
        CurrentBitcoin = 0;
    }

    public void BuyMoney(float exchangeRate)
    {
        SavedMoney += (int)((CurrentBitcoin+SavedBitcoin) * exchangeRate);
        CurrentBitcoin = 0;
        SavedBitcoin = 0;
    }
}