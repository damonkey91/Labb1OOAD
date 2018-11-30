using System;
namespace Labb1OOAD.MementoPattern
{
    public class Memento
    {

        public string Text { get; private set; }

        public Memento(string text)
        {
            Text = text;
        }
    }
}
