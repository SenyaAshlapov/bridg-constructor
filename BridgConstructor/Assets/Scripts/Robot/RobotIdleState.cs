using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotIdleState : MonoBehaviour, IState
{
    public Robot CurrentRobot;

    public void InitState(Robot robot)
    {
        CurrentRobot = robot;
    }

    public void StartState()
    {

    }

    public void StateLoop()
    {

    }
}
