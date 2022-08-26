using UnityEngine;

public class RobotLoseState : IState
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
        _playerInput.Enable();
        _playerAnimator.CrossFade("Lose", 0, 0);

    }

    public void StateLoop()
    {
        _playerTransform.Translate(Vector2.down * Time.deltaTime * 4);
    }
}
