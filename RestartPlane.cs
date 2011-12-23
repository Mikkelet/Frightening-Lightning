using UnityEngine;
using System.Collections;

public class RestartPlane : MonoBehaviour {


    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
