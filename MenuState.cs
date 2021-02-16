using System;

namespace Lab1Components
{
    public abstract class MenuState
    {
        public string StateTitle { get; set; }

        protected ShopConsoleView View { get; set; }

        protected MenuState(ShopConsoleView userInterface)
        {
            View = userInterface;
        }

        protected void SetViewState(MenuState state)
        {
            View.State = state;
        }

        public abstract void ButtonPressed(ConsoleKey key);

        public abstract void PrintMenuOptions();
    }
}