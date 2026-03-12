using UnityEngine;
using System.Collections;

public class Bone : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.BoneSecondsOnScreen;
        base.Start();
    }
}
