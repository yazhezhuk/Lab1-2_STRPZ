using System;

namespace Lab1Components
{
  public class WarehouseMenuState : MenuState
  {
    public WarehouseMenuState(ShopUserInterface userInterface) : base(userInterface) { }

    public override void ButtonPressed(int key)
    {
      switch (key)
      {
        case 1:
          View.Controller.GetAllGoods()
            .ForEach(View.DisplayGoods);
          break;
        case 2:
          SetViewState(new WarehouseSelectionState(View));
          break;
        case 3:
          SetViewState(new MainMenuState(View));
          break;
        default:
          break;

      }
    }
  }
}