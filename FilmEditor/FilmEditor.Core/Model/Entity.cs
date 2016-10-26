using System;
using System.ComponentModel;

namespace FilmEditor.Core.Model
{
    public abstract class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Guid id;

        public Guid Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Copy(Entity other)
        {
            this.Id = other.Id;
        }
        public abstract Entity Clone();
    }
}
