using UnityEngine;
using System.Collections;

public class FallingBlockTrigger : MonoBehaviour {
    public FallingBlock fallingBlock; 

    void Start()
    {
        fallingBlock = fallingBlock.GetComponent<FallingBlock>();
    }
}
