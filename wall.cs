using UnityEngine;
using System.Collections;

public class wall : MonoBehaviour {

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision otherObject)
    {          
        if (tag == "wall")
        {
            // Declares a variable and stores the colliding object's rotation in Euler angles.
            Vector3 rotation = otherObject.transform.eulerAngles;
            
            // Changes the above variable's y-value. Multiplying by -1 will reverse the rotation, rotation the object 180 degrees.
            rotation.y = rotation.y * (-1);

            // applies the variable to the colliding object, making it turn around!
            otherObject.transform.rotation = Quaternion.Euler(new Vector3(
                rotation.x,
                rotation.y,
                rotation.z));
        }
        
    }
    
}