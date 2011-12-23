using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour {

    public bool use = false;

	void Update () {
        if (use)
        {
            gameObject.rigidbody.useGravity = true;
            Physics.gravity = new Vector3(0, -100, 0);
        }
	}
}
