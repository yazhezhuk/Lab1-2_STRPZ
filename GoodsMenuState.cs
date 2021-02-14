using System;

namespace Lab1Components
{
  public class GoodsMenuState : MenuState
  {
    private ShopUserInterface view;

    public GoodsMenuState(ShopUserInterface view) : base(view) { }

    public override void ButtonPressed(int key)
    {
      switch (key)
      {
        case 1:
          View.Controller.GetAllGoods()
            .ForEach(View.DisplayGoods);
          break;
        case 2:
          View.State = new GoodsSelectionState(View);
          break;
        case 3:
          View.Controller.GetSelectedGoods()
            .ForEach(View.DisplayGoods);
          break;
        case 4:
          View.State = new MainMenuState(View);
          break;
        default:
          break;

      }
    }
  }
}