using UnityEngine;
using System.Collections;

public class LightningStrike : MonoBehaviour {

    int timeStart = 0;
    int timeEnd = 10; //This number is generated to make the standalone version look nicer.

    void Update()
    {
        timeStart++;

        if (timeStart == timeEnd)
        {
            Destroy(gameObject);
        }
        
    }
}
