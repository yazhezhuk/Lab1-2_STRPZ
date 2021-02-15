using System;

namespace Lab1Components
{
    public class OrderMenuState : MenuState
    {
        public OrderMenuState(ShopUserInterface userInterface) : base(userInterface)
        {
            StateTitle = "Order";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
             switch (key)
            {
                case ConsoleKey.D1:
                    View.Controller.GetOrderInfo();
                    break;

                case ConsoleKey.D2:
                    View.Controller.ProcessOrder();
                    break;

                case ConsoleKey.D3:
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