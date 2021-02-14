using System;

namespace Lab1Components
{
  public abstract class MenuState
  {
    protected ShopUserInterface View { get; set; }
    public MenuState(ShopUserInterface userInterface)
    {
      View = userInterface;
    }

    protected void SetViewState(MenuState state)
    {
      View.State = state;
    }
    public abstract void ButtonPressed(int key);
  }
}