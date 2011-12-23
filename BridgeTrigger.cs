using UnityEngine;
using System.Collections;

public class BridgeTrigger : MonoBehaviour {
 public Bridge bridge;

    void Start()
    {
        bridge = GameObject.Find("Bridge").GetComponent<Bridge>();
    }
}
