public class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, double lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance() => (Laps * 50) / 1000.0;  // Converts meters to km

    public override double GetSpeed() => (GetDistance() / LengthInMinutes) * 60;

    public override double GetPace() => LengthInMinutes / GetDistance();
}
