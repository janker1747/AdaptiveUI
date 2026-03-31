public class CapacityModel
{
    public int Current { get; private set; }
    public int Max { get; private set; }

    public CapacityModel(int current, int max)
    {
        Current = current;
        Max = max;
    }

    public bool TryUpgrade(int amount)
    {
        if (Current >= Max)
            return false;

        Current += amount;

        if (Current > Max)
            Current = Max;

        return true;
    }

    public float GetNormalized()
    {
        if (Max == 0)
            return 0f;

        return (float)Current / Max;
    }
}