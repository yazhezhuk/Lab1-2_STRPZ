using System;

namespace Lab1Components
{
    public class GoodsMenuState : MenuState
    {
        private ShopConsoleView view;

        public GoodsMenuState(ShopConsoleView view) : base(view)
        {
            StateTitle = "Goods";
        }

        public override void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    View.Controller.GetAllGoods()
                      .ForEach(View.DisplayGoods);
                    break;

                case ConsoleKey.D2:
                    View.State = new GoodsSelectionState(View);
                    break;

                case ConsoleKey.D3:
                    View.Controller.GetSelectedGoods()
                      .ForEach(View.DisplayGoods);
                    break;

                case ConsoleKey.D4:
                    View.State = new MainMenuState(View);
                    break;

                default:
                    break;
            }
        }

        public override void PrintMenuOptions()
        {
            View.PrintMenuItems(View.GoodsMenuOptions, StateTitle);
        }
    }
}