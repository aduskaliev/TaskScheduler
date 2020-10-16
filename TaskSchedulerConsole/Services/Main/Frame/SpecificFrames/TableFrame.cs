using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaskSchedulerConsole.Services.Main
{
    internal class TableFrame<KeyType, ValueType> : IFrame
        where KeyType : IFormattable
    {
        private TableFrameContext<KeyType, ValueType> _frameContext;
        private IFrame _nextFrame;
        private ICommand _command;
        private object _returnData;
        private string _input;

        public TableFrameContext<KeyType, ValueType> FrameContext => _frameContext;
        public ICommand Command => _command;
        public object ReturnData => _returnData;


        public TableFrame(FrameContext frameContext)
        {
            _frameContext = (TableFrameContext<KeyType, ValueType>) frameContext;
        }

        public void DisplayMenu()
        {
            _frameContext.Menu.Display();
        }

        public void GetInput()
        {
            _input = Console.ReadLine();            
        }

        public void ProcessInput(out string message)
        {
            bool result = false;
            string[] strArr =
                Regex.Replace(_input, @"\s+", " ")
                .Trim()
                .ToLower()
                .Split(' ');
            if (strArr.Length > 0)
            {
                _command = _frameContext.CommandList.FirstOrDefault(el => el.Name.ToLower() == strArr[0]);
                if (_command == null)
                {
                    _nextFrame = this;
                    message = "Command not found. Please try again";
                    return;
                }
                string userData = strArr.Length > 1 ? strArr[1] : null;
                result = _command.Execute(userData, out _returnData, out message);
                if (!result)
                {
                    _nextFrame = this;
                    message ??= "Something went wrong. Please try again";
                }
            }
            else
            {
                _nextFrame = this;
                message = "Please provide input";
            }
        }

        public IFrame Next()
        {
            if (_nextFrame == null)
            {
                _nextFrame = FrameManager.BuildFrame(this);
            }
            return _nextFrame;
        }
    }
}
