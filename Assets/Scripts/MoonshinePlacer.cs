using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }
    
    public GameObject moonshinePrefab;
    
    public override void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomTopOfScreenLocationScreenSpace(), Quaternion.identity);
    }
    
}
