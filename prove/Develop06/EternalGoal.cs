namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            return Points; // Eternal goals are never completed
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal|{Name}|{Description}|{Points}";
        }

        public override string GetDetailsString()
        {
            return $"{Name} - {Description} (Points: {Points})";
        }
    }
}
