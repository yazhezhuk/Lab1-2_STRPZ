using System;

namespace UI.ViewStates
{
    public class OrderMenuState : MenuState
    {
        public OrderMenuState(ShopConsoleView userInterface) : base(userInterface)
        {
            StateTitle = "Order";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    View.Controller.ProcessOrder();
                    break;

                case ConsoleKey.D2:
                    SetViewState(new MainMenuState(View));
                    break;

                default:
                    break;
            }
        }

        public override void PrintMenuOptions()
        {
            View.PrintMenuItems(View.OrderMenuOptions, StateTitle);
        }
    }
}