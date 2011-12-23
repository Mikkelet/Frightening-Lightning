using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public Character character;
    public bool use = false;
    public int speed = 50;

    public int ELEVATOR_TOP_POINT = 37;

    void Start()
    {
        character = GameObject.Find("Player").GetComponent<Character>();
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < ELEVATOR_TOP_POINT)
        {
            if (use)
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
                character.move = false;
            }
            
        }else { use = false; transform.Translate(0, 0, 0); character.move = true; }
	}
}
