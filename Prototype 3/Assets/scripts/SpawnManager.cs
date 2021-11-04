using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objects;
    public float startDelay = 2;
    public float interval = .5f;
    public float duration = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom", startDelay, interval);
    }

    void SpawnRandom ()
    {
        var index = Random.Range(0, objects.Count);
        var newObjPrfb = objects[index];
        var newObj = Instantiate(newObjPrfb, transform.position, newObjPrfb.transform.rotation);
        newObj.AddComponent<Move>();
        Destroy(newObj, duration);
    }

    private void Update()
    {
        if (Game.state == gameState.endGame)
            CancelInvoke("SpawnRandom");
    }
}

public enum gameState
{
    preGame,
    inGame,
    paused,
    endGame
}

public class Game
{
    public static gameState state = gameState.inGame;
    public static void SetState(gameState newState)
    {
        if (state != newState)
        {
            state = newState;
            switch (newState)
            {
                case gameState.endGame:
                    Debug.Log("Game Over");
                    break;
            }
        }
    }
}
