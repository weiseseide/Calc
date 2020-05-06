using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WpfCalc3.ViewModels.Commands;
using System.ComponentModel;
using System.ComponentModel.Composition;
using Itb.Mvvm;

namespace WpfCalc3.ViewModels
{
    [Export(typeof(DisplayViewModel))]
    public class DisplayViewModel : ViewModelBase<DisplayViewModel>
    {
        [Import(typeof(WpfCalc3.CalcDeterminer.IDeterminer))]
        public WpfCalc3.CalcDeterminer.Determiner determiner;

        private String _DisplayInput;
        public String DisplayInput
        {
            get { return _DisplayInput; }
            set
            {
                if (_DisplayInput != value)
                {
                    _DisplayInput = value;
                    NotifyPropertyChanged(nameof(DisplayInput));
                }
            }
        }

        private DelegateCommand<object> _DigitCommand;
        public DelegateCommand<object> DigitCommand
        {
            get
            {
                if (_DigitCommand == null)
                    _DigitCommand = new DelegateCommand<object>((object input) =>
                    {
                        String tmp = input.ToString();
                        DisplayInput = determiner.PushDigit(tmp[0]);
                    });

                return _DigitCommand;
            }
            private set { _DigitCommand = value; }
        }


        private DelegateCommand<object> _OperatorCommand;
        public DelegateCommand<object> OperatorCommand
        {
            get
            {
                if (_OperatorCommand == null)
                    _OperatorCommand = new DelegateCommand<object>((object input) =>
                    {
                        String tmp = input.ToString();
                        DisplayInput = determiner.PushOperator(tmp[0]);
                    });

                return _OperatorCommand;
            }
            private set { _OperatorCommand = value; }
        }


        private DelegateCommand _EqualCommand;
        public DelegateCommand EqualCommand
        {
            get
            {
                if (_EqualCommand == null)
                    _EqualCommand = new DelegateCommand(() =>
                    {
                        DisplayInput = determiner.Equal();
                    });

                return _EqualCommand;
            }
            private set { _EqualCommand = value; }
        }


        private DelegateCommand _ClearCommand;
        public DelegateCommand ClearCommand
        {
            get
            {
                if (_ClearCommand == null)
                    _ClearCommand = new DelegateCommand(() =>
                    {
                        DisplayInput = determiner.Clear();
                    });

                return _ClearCommand;
            }
            private set { _ClearCommand = value; }
        }


        private DelegateCommand<object> _CommaCommand;
        public DelegateCommand<object> CommaCommand
        {
            get
            {
                if (_CommaCommand == null)
                    _CommaCommand = new DelegateCommand<object>((object input) =>
                    {
                        String tmp = input.ToString();
                        DisplayInput = determiner.PushComma(tmp[0]);
                    });

                return _CommaCommand;
            }
            private set { _CommaCommand = value; }
        }


        /*public void DisplayDigit(object input)
        {
            String tmp = input.ToString();
            DisplayInput = determiner.PushDigit(tmp[0]);
        }

        public void DisplayOperator(object input)
        {
            String tmp = input.ToString();
            DisplayInput = determiner.PushOperator(tmp[0]);
        }

        public void DisplayEqual(object input)
        {
            DisplayInput = determiner.Equal();
        }

        public void DisplayClear(object input)
        {
            DisplayInput = determiner.Clear();
        }

        public void DisplayComma(object input)
        {
            String tmp = input.ToString();
            DisplayInput = determiner.PushComma(tmp[0]);
        }*/

    }
}


