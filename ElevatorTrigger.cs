using UnityEngine;
using System.Collections;

public class ElevatorTrigger : MonoBehaviour {
    public Elevator elevator; 

    void Start()
    {
        elevator = elevator.GetComponent<Elevator>();
    }
}
