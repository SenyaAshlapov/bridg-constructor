using UnityEngine;

public interface IState
{ 
    void InitState(Transform transform, Animator animator, PlayerInput input);

    void StartState();

    void StateLoop();
} 


