using UnityEngine;
using System.Collections;

public class Beer : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();
    }
}
