﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace V2.Elements.Paramers
{
    public class DelegateCommand<T>:CommandBase
    {
        public DelegateCommand(Action<T> execute) : base(o=> execute((T)((object)o)))
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<object> canExecute) : base(o => execute((T)((object)o)), canExecute)
        {
        }
    }

    public class DelegateCommand : CommandBase
    {
        public DelegateCommand(Action execute) : base(o => execute())
        {
        }

        public DelegateCommand(Action<object> execute) : base(execute)
        {
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
        {
        }
    }
}
