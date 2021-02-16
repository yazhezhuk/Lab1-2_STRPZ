using System;

namespace Lab1Components
{
    public class WarehouseMenuState : MenuState
    {
        public WarehouseMenuState(ShopConsoleView userInterface) : base(userInterface)
        {
            StateTitle = "Warehouse";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    View.Controller.GetAllWarehouses()
                        .ForEach(View.DisplayWarehouse);
                    break;

                case ConsoleKey.D2:
                    SetViewState(new WarehouseSelectionState(View));
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
            View.PrintMenuItems(View.WarehouseMenuOptions, StateTitle);
        }
    }
}