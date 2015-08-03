using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using RegexTester;
using V2.Elements.Paramers;

namespace RegexTester
{
    public class MainpageViewModel: ViewmodelBase
    {
        public MainpageViewModel()
        {
            GoCommand=new DelegateCommand(RegexMatched);
#if DEBUG
            _pattern = ".{1,4}";
            _inputText = "sadfs算法afas(asdf撒旦法af)asdf23412412[asd24]asdf2341]asdfs艾丝凡dfajknnkl(lksaldfn)IJLEjl)阿萨德即发即收[倒萨金龙鱼if家(asdfoliasjdfl2342352{aslkfl}}salfjlasj}lasjfdljo撒娇的弗拉季斯拉夫";
#endif
        }

        private void RegexMatched()
        {
            Report = "";
            var sw=new Stopwatch();
            sw.Start();
            var text = InputText;
            var option= RegexOptions.None;
            if (IsCaps)
            {
                option = option|RegexOptions.IgnoreCase;
            }
            if (IsCompile)
            {
                option = option | RegexOptions.Compiled;
            }

            var results=Regex.Matches(text, Pattern, option);
            Result = results.OfType<Match>().Select(o => string .Format("位置：{0}\r\n结果：{1}\r\n------------------------------------------------------",o.Index,o.Value));
            sw.Stop();
            Report = string.Format("共查找到结果数： {0}         用时：{1}毫秒", results.Count, sw.ElapsedMilliseconds);
        }

        private string _report;
        
        public string Report
        {
            get { return _report; }
            set
            {
                _report = value; 
                OnPropertyChanged();
            }
        }


        private string _pattern;

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value; 
                
                OnPropertyChanged();
            }
        }


        private string _inputText;

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value; 
                OnPropertyChanged();
            }
        }

        private IEnumerable<string> _result;

        public IEnumerable<string> Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private ICommand _goCommand  ;

        public ICommand GoCommand
        {
            get { return _goCommand; }
            set
            {
                _goCommand = value; 
                OnPropertyChanged();
            }
        }

        private bool _isCaps;

        public bool IsCaps
        {
            get { return _isCaps; }
            set
            {
                _isCaps = value; 
                OnPropertyChanged();
            }
        }

        private bool _isCompile;

        public bool IsCompile
        {
            get { return _isCompile; }
            set
            {
                _isCompile = value; 
                OnPropertyChanged();
            }
        }

    }
}
