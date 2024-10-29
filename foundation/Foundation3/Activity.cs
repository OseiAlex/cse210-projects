public class Activity
{
    protected DateTime Date { get; set; }
    protected double LengthInMinutes { get; set; }

    public Activity(DateTime date, double lengthInMinutes)
    {
        Date = date;
        LengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance() { return 0; }
    public virtual double GetSpeed() { return 0; }
    public virtual double GetPace() { return 0; }

    public virtual string GetSummary()
    {
        string activityType = this.GetType().Name;  // Gets the name of the derived class (e.g., "Running", "Cycling")
        return $"{Date:dd MMM yyyy} ({LengthInMinutes} min) {activityType} - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}
