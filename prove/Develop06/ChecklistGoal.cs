namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _currentCount;
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (!IsCompleted)
            {
                _currentCount++;
                if (_currentCount >= _targetCount)
                {
                    MarkAsCompleted();
                    return Points + _bonusPoints;
                }
                return Points;
            }
            return 0;
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonusPoints}|{_currentCount}|{IsCompleted}";
        }

        public override string GetDetailsString()
        {
            string status = IsCompleted ? "[x]" : $"[ ] {_currentCount}/{_targetCount}";
            return $"{status} {Name} - {Description} (Points: {Points})";
        }
    }
}
