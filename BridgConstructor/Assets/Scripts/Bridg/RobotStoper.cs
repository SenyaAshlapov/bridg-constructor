using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStoper : MonoBehaviour
{
    public delegate void StoperEvent();
    public static StoperEvent StopRobot;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("trigger");
        if(otherCollider.gameObject.GetComponent<Robot>())
        {
            Debug.Log("its robot");
            StopRobot?.Invoke();
        }
    }
}
