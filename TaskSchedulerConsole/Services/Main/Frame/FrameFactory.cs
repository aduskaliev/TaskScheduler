using System;
using System.Collections.Generic;
using System.Text;
using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal class FrameFactory<FrameType>
        where FrameType : IFrame
    {
        public static IFrame Create(FrameContext frameContext)
        {
            return (FrameType)Activator.CreateInstance(typeof(FrameType), new object[] { frameContext });
        }
    }
}
