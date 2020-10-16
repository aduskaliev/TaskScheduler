using TaskSchedulerConsole.Services.Main.Menu;

namespace TaskSchedulerConsole.Services.Main
{
    internal abstract class FrameContext
    {
        protected IMenu _menu;
        public IMenu Menu => _menu;
    }
}
