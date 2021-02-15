using System;

namespace Lab1Components
{
    public abstract class MenuState
    {
        public string StateTitle { get; set; }

        protected ShopUserInterface View { get; set; }

        protected MenuState(ShopUserInterface userInterface)
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