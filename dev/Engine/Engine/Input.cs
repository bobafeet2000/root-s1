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
        private static GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
        private static GamePadState lastGamePadState;

        public static void Update()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            lastGamePadState = gamePadState;
            gamePadState = GamePad.GetState(PlayerIndex.One);

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

        public static bool IsKeyDownGamePad(Buttons input) // test de touche enfoncée
        {
            return gamePadState.IsButtonDown(input);
        }

        public static bool IsKeyUpGamePad(Buttons input) // test de touche relachée
        {
            return gamePadState.IsButtonUp(input);
        }

        public static bool KeyPressedGamePad(Buttons input) // test de touche pressée
        {
            if (gamePadState.IsButtonDown(input) == true && lastGamePadState.IsButtonDown(input) == false)
                return true;
            else
                return false;
        }

    }
}
