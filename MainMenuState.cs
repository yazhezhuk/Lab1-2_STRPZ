using System;

namespace Lab1Components
{
    public class MainMenuState:IMenuState
    {
        private ShopUserInterface View { get; set; }
        public MainMenuState(ShopUserInterface userInterface)
        {
            View = userInterface;
        }

        public void ButtonPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                    View.


            }
        }
    }
}