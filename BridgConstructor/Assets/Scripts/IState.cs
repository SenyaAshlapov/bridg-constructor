using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface IState
{
    
    void InitState(Robot robot);

    void StartState();

    void StateLoop();
} 


