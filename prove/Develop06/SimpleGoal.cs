namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                MarkAsCompleted();
                return Points;
            }
            return 0;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal|{Name}|{Description}|{Points}|{IsCompleted}";
        }
    }
}
