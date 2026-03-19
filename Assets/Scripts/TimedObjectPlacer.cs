using UnityEngine;
using System.Collections;
using NUnit.Framework.Constraints;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    private bool isOkToCreate = true;

    void Update()
    {
        if (isOkToCreate)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        yield return new WaitForSeconds(Random.Range(minimumSecondsToWait, maximumSecondsToWait));
        Place();
        isOkToCreate = true;
    }


    public virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
    
    
}