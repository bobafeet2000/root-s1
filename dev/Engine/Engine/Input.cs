using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;



namespace Engine
{
    public static class Input
    {
        private static KeyboardState keyboardState = Keyboard.GetState();
        private static KeyboardState lastKeyboardState;

        public static void Update()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys input) // test de touche enfoncée
        {
            return keyboardState.IsKeyDown(input);
        }

        public static bool IsKeyUp(Keys input) // test de touche relachée
        {
            return keyboardState.IsKeyUp(input);
        }

        public static bool KeyPressed(Keys input) // test de touche pressée
        {
            if (keyboardState.IsKeyDown(input) == true && lastKeyboardState.IsKeyDown(input) == false)
                return true;
            else
                return false;
        }
      
    }
}
