using System;
using System.Collections.Generic;

namespace UI.ViewStates
{
    public class WarehouseSelectionState : MenuState
    {
        public WarehouseSelectionState(ShopConsoleView userInterface) : base(userInterface)
        {
            StateTitle = "Warehouse Selection";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            int selectedIndex = Convert.ToInt32(key - '0' - 1);
            View.Controller.SelectWarehouse(selectedIndex);

            SetViewState(new WarehouseMenuState(View));
        }

        public override void PrintMenuOptions()
        {
            View.PrintMenuItems(new List<string> { "Enter ¹ of warehouse: " }, StateTitle);
        }
    }
}