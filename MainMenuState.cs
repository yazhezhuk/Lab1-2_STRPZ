using System;

namespace Lab1Components
{
  public class MainMenuState : MenuState
  {
    public MainMenuState(ShopUserInterface userInterface) : base(userInterface) { }

    public override void ButtonPressed(int key)
    {
      switch (key)
      {
        case 1:
          View.PrintMenuItems(View.GoodsMenuOptions);
          View.State = new GoodsMenuState(View);
          break;
        case 2:
          View.State = new WarehouseMenuState(View);
          View.PrintMenuItems(View.WarehouseMenuOptions);
          break;
        case 3:
          View.Exit();
          break;
        default:
          break;

      }
    }
  }
}