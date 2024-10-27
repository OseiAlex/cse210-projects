using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _points;
        private bool _isCompleted;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isCompleted = false;
        }

        public string Name => _name;
        public string Description => _description;
        public int Points => _points;
        public bool IsCompleted => _isCompleted;

        internal void MarkAsCompleted()
        {
            _isCompleted = true;
        }

        public abstract int RecordEvent();

        public virtual string GetDetailsString()
        {
            // Display [ ] or [x] based on completion, but omit for eternal goals
            string status = GetType() == typeof(EternalGoal) ? "" : (_isCompleted ? "[x] " : "[ ] ");
            return $"{status}{_name} - {Description} (Points: {Points})";
        }

        public abstract string GetStringRepresentation();
    }
}
