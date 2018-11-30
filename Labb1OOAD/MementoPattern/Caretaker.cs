using System;
using System.Collections.Generic;

namespace Labb1OOAD.MementoPattern
{
    public class Caretaker
    {
        private List<Memento> UndoMementoList { get; set; }
        private List<Memento> RedoMementoList { get; set; }
        private Originator originator { get; set; }
      
        public Caretaker(Originator originator)
        {
            UndoMementoList = new List<Memento>();
            RedoMementoList = new List<Memento>();
            this.originator = originator;
        }

        public void Undo()
        {
            int lastIndex = UndoMementoList.Count - 1;
            Memento memento = UndoMementoList[lastIndex];
            RedoMementoList.Add(memento);
            UndoMementoList.Remove(memento);
            originator.RestoreMemento(UndoMementoList[lastIndex-1]);
        }

        public void Redo()
        {
            int lastIndex = RedoMementoList.Count - 1;
            Memento memento = RedoMementoList[lastIndex];
            UndoMementoList.Add(memento);
            RedoMementoList.Remove(memento);
            originator.RestoreMemento(memento);
             
        }

        public void SaveMemento()
        {
            UndoMementoList.Add(originator.SaveToMomento());
        }

        public bool isRedoListEmpty()
        {
            return RedoMementoList.Count < 1;
        }

        public bool isUndoListEmpty()
        {
            return UndoMementoList.Count < 2;
        }
    }
}
