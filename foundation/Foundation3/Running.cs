public class Running : Activity
{
    private double Distance { get; set; }

    public Running(DateTime date, double lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        Distance = distance;
    }

    public override double GetDistance() => Distance;

    public override double GetSpeed() => (Distance / LengthInMinutes) * 60;

    public override double GetPace() => LengthInMinutes / Distance;
}
