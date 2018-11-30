using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Labb1OOAD.MementoPattern;
using Xamarin.Forms;

namespace Labb1OOAD.VieModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand UndoProperty { get; set; }
        public ICommand RedoProperty { get; set; }
        public ICommand SaveProperty { get; set; }
        public Originator MyOriginator { get; set; }
        public Caretaker MyCaretaker { get; set; }
        private Color _contentPageBackgroundColor = Color.Transparent;
        public Color ContentPageBackgroundColor { 
            get { return _contentPageBackgroundColor; } 
            set { SetProperty(ref _contentPageBackgroundColor, value); } 
        }
        private string sliderValue = "0";
        public string SliderValue { get { return sliderValue; } 
            set { 
                sliderValue = value; 
                MyOriginator.State = value;
                int index = (int)double.Parse(sliderValue);
                ContentPageBackgroundColor = ColorList[index];
            } 
        }
        private List<Color> ColorList { get; set; } = new List<Color>{Color.Transparent, Color.Aqua, Color.Fuchsia, Color.ForestGreen, Color.Lime, Color.LightGoldenrodYellow, Color.OrangeRed, Color.Olive, Color.White};

        public MainPageViewModel()
        {
            MyOriginator = new Originator(SliderValue);
            MyCaretaker = new Caretaker(MyOriginator);
            UndoProperty = new Command(Undo, () => { return !MyCaretaker.isUndoListEmpty(); });
            RedoProperty = new Command(Redo, () => { return !MyCaretaker.isRedoListEmpty(); });
            SaveProperty = new Command(Save);
        }

        private void RefreshCanExecute()
        {
            (UndoProperty as Command).ChangeCanExecute();
            (RedoProperty as Command).ChangeCanExecute();
        }

        private void Undo()
        {
            MyCaretaker.Undo();
            SliderValue = MyOriginator.State;
            RefreshCanExecute();
        }

        private void Redo()
        {
            MyCaretaker.Redo();
            SliderValue = MyOriginator.State;
            RefreshCanExecute();
        }

        private void Save()
        {
            MyCaretaker.SaveMemento();
            RefreshCanExecute();
        }
    }
}
