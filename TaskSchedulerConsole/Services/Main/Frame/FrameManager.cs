using System;
using System.Collections.Generic;
using System.Text;

namespace TaskSchedulerConsole.Services.Main
{
    internal static class FrameManager
    {
        private static Stack<IFrame> frameStack;

        private static object _lastReturnedData;
        public static object LastReturnedData => _lastReturnedData;

        public static IFrame BuildFrame(IFrame frame)
        {
            switch (frame.Command.Name)
            {
                case "ShowTaskLists":
                    {

                    }
                    break;
            }
        }
    }
}
