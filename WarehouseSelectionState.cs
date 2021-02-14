using System;
using System.Collections.Generic;

namespace Lab1Components
{
  public class WarehouseSelectionState : MenuState
  {
    public WarehouseSelectionState(ShopUserInterface userInterface) : base(userInterface)
    { }

    public override void ButtonPressed(int key)
    {
      int selectedIndex = Convert.ToInt32(key);
      View.Controller.SelectWarehouse(selectedIndex);
    }

  }
}

