using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{

    public void Start()
    {
        int numEnemies = 3;

        for (int i = 0; i < numEnemies; i++)
        {
            Debug.Log(i + " enemies 'bout'a kill ya'");
        }

        int cupsInTheSink = 4;


        while (cupsInTheSink > 0)
        {
            Debug.Log("do the dishes");
            cupsInTheSink--;
        }

        bool shouldContinue = false;

        do
        {
            print("heya");

        } while (shouldContinue == true);

        string[] strings = new string[3];

        strings[0] = "First";
        strings[1] = "Second";
        strings[2] = "Third";

        foreach (string item in strings)
        {
            print(item);
        }
    }

}
