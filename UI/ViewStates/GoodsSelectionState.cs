using System;
using System.Collections.Generic;

namespace UI.ViewStates
{
    public class GoodsSelectionState : MenuState
    {
        public GoodsSelectionState(ShopConsoleView userInterface) : base(userInterface)
        {
            StateTitle = "Goods Selection";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            var selectedIndex = Convert.ToInt32(key - '0' - 1);
            View.Controller.SelectGoods(selectedIndex);

            SetViewState(new GoodsMenuState(View));
        }

        public override void PrintMenuOptions()
        {
            View.PrintMenuItems(new List<string> { "Enter ¹ of goods: " }, StateTitle);
        }
    }
}