using UnityEngine;

public class RobotMoveState : IState
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
    }

    public void StartState()
    {
        _playerInput.Disable();
        _playerAnimator.CrossFade("Move", 0.3f, 0);
    }

    public void StateLoop()
    {
        _playerTransform.Translate(Vector2.right * Time.deltaTime);
    }
}
