using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameoverState : GameState
    {
        public GameState mainMenuState;
        public LevelController levelController;

        public void Restart()
        {
            levelController.ClearStones();

            Exit();
            mainMenuState.Enter();
        }
    }
}
