using System;
namespace Labb1OOAD.MementoPattern
{
    public class Originator
    {

        public string State { get; set; }

        public Originator(string text)
        {
            State = text;
        }

        public void RestoreMemento(Memento memento) 
        {
            State = memento.Text;
        }

        public Memento SaveToMomento()
        {
            return new Memento(State);
        }
    }
}
