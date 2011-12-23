using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
