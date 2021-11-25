using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public Text scoreText;
    public int score;

    private void Start()
    {
        if (main == null)
        {
            main = this;
        }
    }

    public void ProjectileHit (Projectile prjctl)
    {
        var type = prjctl.type;

        switch (type)
        {
            case projectileType.good:
                score++;
                break;

            case projectileType.bad:
                GameOver();
                break;
        }

        Destroy(prjctl.gameObject);
    }

    public void Play (int mode)
    {
        MenuManager.main.Play();
        Time.timeScale = 1;

        StartCoroutine(Spawner.main.SpawnNew(mode));
    }

    void GameOver ()
    {
        MenuManager.main.GameOver();
        Spawner.main.spawnObjects = false;
    }

    public void Restart ()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
