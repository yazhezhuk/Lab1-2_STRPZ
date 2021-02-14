using System;
using System.Collections.Generic;

namespace Lab1Components
{
  public class GoodsSelectionState : MenuState
  {
    public GoodsSelectionState(ShopUserInterface userInterface) : base(userInterface)
    { }

    public override void ButtonPressed(int key)
    {
      int selectedIndex = Convert.ToInt32(key);
      View.Controller.SelectGoods(selectedIndex);

      SetViewState(new GoodsMenuState(View));
    }

  }
}

