using System;
using System.Collections.Generic;
using System.Text;
using TaskSchedulerConsole.Services.Main.Commands;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal class InputFrame : IFrame
    {
        private InputFrameContext _frameContext;
        private Dictionary<string, string> _userInput;
        public Dictionary<string, string> UserInput => _userInput;
        private ICommand _command;
        private IFrame _nextFrame;
        private object _returnData;

        public InputFrame(FrameContext frameContext)
        {
            _frameContext = (InputFrameContext) frameContext;
            _command = _frameContext.Command;
            _userInput = new Dictionary<string, string>();
        }

        public void DisplayMenu()
        {
            _frameContext.Menu.Display();
        }

        public void GetInput()
        {
            foreach (var el in _frameContext.DataTemplate)
            {
                Console.Write($"{el.Key}: ");
                if (!String.IsNullOrEmpty(el.Value))
                {
                    Console.Write($"[{el.Value}]");
                }

                string input = Console.ReadLine();

                string checkInput = input.Trim().ToLower();
                if (checkInput == "!skip")
                {
                    break;
                }
                if(checkInput == "!back")
                {
                    //_command = Back
                    return;
                }
                if (checkInput == "!exit")
                {
                    //_command = Exit
                    return;
                }

                _userInput[el.Key] = input;
            }
        }        

        public void ProcessInput(out string message)
        {
            bool result = _frameContext.Command.Execute(UserInput, out _returnData, out message);
            if (!result)
            {
                _nextFrame = this;
                message ??= "Something went wrong. Try again";
            }
        }

        public IFrame Next()
        {
            if (_nextFrame == null)
            {
                _nextFrame = FrameManager.BuildFrame(_frameContext.Command, _returnData);
            }
            return _nextFrame;
        }
    }
}
