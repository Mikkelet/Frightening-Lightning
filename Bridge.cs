using UnityEngine;
using System.Collections;

public class Bridge : MonoBehaviour
{
    
    public bool use = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z == 0)
        {
            if (use)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 1, transform.rotation.w);

                use = false;
            }
        }
    }

}