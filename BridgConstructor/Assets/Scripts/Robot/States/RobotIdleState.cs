using UnityEngine;

public class RobotIdleState : IState
{
    private Transform _playerTransform;
    private Animator _playerAnimator;
    private PlayerInput _playerInput;

    public void InitState(
        Transform transform, 
        Animator animator, 
        PlayerInput input)
    {
        _playerTransform = transform;
        _playerAnimator = animator;
        _playerInput = input;

        Debug.Log("Idle init");
    }

    public void StartState()
    {
        _playerInput.Disable();
        _playerAnimator.CrossFade("Idle", 0.2f, 0);

        Debug.Log("idle start");
    }

    public void StateLoop()
    {
        Debug.Log("idle loop");
    }
}
