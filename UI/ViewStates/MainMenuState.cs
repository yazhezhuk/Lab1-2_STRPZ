using System;

namespace UI.ViewStates
{
    public class MainMenuState : MenuState
    {
        public MainMenuState(ShopConsoleView userInterface) : base(userInterface)
        {
            StateTitle = "Main";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    SetViewState(new GoodsMenuState(View));
                    break;

                case ConsoleKey.D2:
                    SetViewState(new WarehouseMenuState(View));
                    break;

                case ConsoleKey.D3:
                    SetViewState(new OrderMenuState(View));
                    break;

                case ConsoleKey.D4:
                    View.Exit();
                    break;

                default:
                    break;
            }
        }

        public override void PrintMenuOptions()
        {
            View.PrintMenuItems(View.MainMenuOptions, StateTitle);
        }
    }
}