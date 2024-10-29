public class Cycling : Activity
{
    private double Speed { get; set; }

    public Cycling(DateTime date, double lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        Speed = speed;
    }

    public override double GetDistance() => (Speed * LengthInMinutes) / 60;

    public override double GetSpeed() => Speed;

    public override double GetPace() => 60 / Speed;
}
