using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TaskSchedulerConsole.Services.Main.Commands;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal class SimpleFrame : IFrame
    {
        private SimpleFrameContext _frameContext;
        private IFrame _nextFrame;
        private ICommand _command;
        private object _returnData;
        private string _input;

        public SimpleFrame(FrameContext frameContext)
        {
            _frameContext = (SimpleFrameContext) frameContext;
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
                _nextFrame = FrameManager.BuildFrame(_command, _returnData);
            }
            return _nextFrame;
        }
    }
}
