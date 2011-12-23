using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
       public int moveAmount = 0;
       public static float speed = 80.0F;
       public bool move = true;

	   

	void Start () {
        Physics.gravity = new Vector3(0,-50,0);
        animation.wrapMode = WrapMode.Loop;
	}
    
	// Update is called once per frame
	void Update () {
        if (move)
        {
            float moveAmount = speed * Time.deltaTime;
            transform.Translate(0, 0, moveAmount);
        }
	}
}
