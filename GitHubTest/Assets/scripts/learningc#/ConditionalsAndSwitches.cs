using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalsAndSwitches : MonoBehaviour
{
    public enum GameState
    {
        preGame, inGame, paused, gameOver
    }

    public GameState state;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ChangeState(GameState.inGame);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            ChangeState(GameState.paused);
        }
    }

    void ChangeState (GameState newState)
    {
        if (state != newState)
        {
            state = newState;

            switch (newState)
            {
                case GameState.preGame:
                    Time.timeScale = 0;
                    break;

                case GameState.inGame:
                    Time.timeScale = 1;
                    break;

                case GameState.paused:
                    Time.timeScale = 0;
                    break;

                case GameState.gameOver:
                    Time.timeScale = 1;
                    break;
            }
        }
    }
}
