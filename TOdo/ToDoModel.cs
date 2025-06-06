using System;
using System.ComponentModel;

namespace TodoApp.models
{
    class TodoModel : INotifyPropertyChanged
    {
        private bool _isDone;
        private string _text;
        private DateTime? _deadline;

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
                OnPropertyChanged("DaysRemaining");
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public DateTime? Deadline
        {
            get { return _deadline; }
            set
            {
                if (_deadline == value)
                    return;
                _deadline = value;
                OnPropertyChanged("Deadline");
                OnPropertyChanged("DaysRemaining");
            }
        }

        public string DaysRemaining
        {
            get
            {
                if (IsDone) return "✓ Выполнено";
                if (Deadline == null) return "⏳ Нет дедлайна";

                var remaining = Deadline.Value.Date - DateTime.Now.Date;

                if (remaining.Days == 0)
                    return "🔥 Выполняется";
                else if (remaining.Days < 0)
                    return $"⌛ Прошло {-remaining.Days} д.";
                else if (remaining.Days == 1)
                    return $"⏱️ Остался 1 день";
                else
                    return $"⏱️ Осталось {remaining.Days} д.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}