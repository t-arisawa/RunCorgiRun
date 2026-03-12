using UnityEngine;
using System.Collections;

public class Poop : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.PoopSecondsOnScreen;
        base.Start();
    }
    
}
