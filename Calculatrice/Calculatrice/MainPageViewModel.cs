using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calculatrice
{
    internal class MainPageViewModel : ViewModelBase
    {
        private string _result;
        private string _story;
        private int _lastNum;
        private string _symbol;

        public string Result { 
            get => _result; 
            set => SetProperty<string>(ref _result, value); 
        }

        public string Story
        {
            get => _story;
            set => SetProperty<string>(ref _story, value);
        }

        public int LastNum
        {
            get => _lastNum;
            set => SetProperty<int>(ref _lastNum, value);
        }

        public string Symbol
        {
            get => _symbol;
            set => SetProperty<string>(ref _symbol, value);
        }

        public Command<string> ClickNumberCommand { get; }
        public Command ClickSUPPCommand { get; }
        public Command ClickACCommand { get; }
        public Command<string> ClickSymbolCommand { get; }
        public Command ClickEqualCommand { get; }

        public MainPageViewModel()
        {
            ClickNumberCommand = new Command<string>(OnClickNumber);
            ClickSUPPCommand = new Command(OnClickSUPP);
            ClickACCommand = new Command(OnClickAC);
            ClickSymbolCommand = new Command<string>(OnClickSymbol); 
            ClickEqualCommand = new Command(OnClickEqual);
        }

        private void OnClickNumber(string number)
        {
            Result += number;
        }

        private void OnClickAC()
        {
            Result = "";
        }

        private void OnClickSUPP()
        {
            Result = Result.Remove(Result.Length - 1);
        }

        private void OnClickSymbol(string symbol)
        {
            Symbol = symbol;
            LastNum = int.Parse(Result);
            Story += $"{LastNum} {Symbol} ";
            Result = "";
        }
        private void OnClickEqual()
        {
            string newResult;
            int newNum = int.Parse(Result);
            switch (Symbol)
            {
                case "%":
                    newResult = (LastNum % newNum).ToString();
                    break;

                case "/":
                    newResult = (LastNum / newNum).ToString();
                    break;

                case "-":
                    newResult = (LastNum - newNum).ToString();
                    break;

                case "x":
                    newResult = (LastNum * newNum).ToString();
                    break;

                default: 
                    newResult = (LastNum + newNum).ToString();
                    break;
            }
            Story += $"{Result} = {newResult}\n";
            Result = newResult;
        }
    }
}
