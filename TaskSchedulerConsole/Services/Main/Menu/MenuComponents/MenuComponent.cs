

namespace TaskSchedulerConsole.Services.Main.Menu
{
    internal class MenuComponent : IMenuComponent
    {
        private readonly string _componentContext;
        public string ComponentContext => _componentContext;

        public MenuComponent(string context)
        {
            _componentContext = context;
        }
    }
}
