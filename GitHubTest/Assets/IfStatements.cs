using UnityEngine;
using System.Collections;

public class IfStatements : MonoBehaviour
{
    float coffeeTemperature = 85.0f;
    float hotLimitTemperature = 70.0f;
    float coldLimitTemperature = 40.0f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TemperatureTest();

        coffeeTemperature -= Time.deltaTime * 5f;
    }


    void TemperatureTest()
    {
        if (coffeeTemperature > hotLimitTemperature)
        {
            // ... do this.
            print("Coffee way to hot");
        }
        else if (coffeeTemperature < coldLimitTemperature)
        {
            // ... do this.
            print("Coffee way s too cold.");
        }
        else
        {
            // ... do this.
            print("It's a good temperature but still bad");
        }
    }
}