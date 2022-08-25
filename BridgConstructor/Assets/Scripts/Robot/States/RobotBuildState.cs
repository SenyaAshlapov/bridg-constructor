using UnityEngine;

public class RobotBuildState : IState
{
    public delegate void RobotEvent();

    public static RobotEvent StartBuid;
    public static RobotEvent StopBuild;

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

        _playerInput.Player.BridgBuilding.started += context => startBuildBridg();
        _playerInput.Player.BridgBuilding.canceled += context => stopBuildBridg();

        Debug.Log("build init");
    }

    public void StartState()
    {
        _playerInput.Enable();
        _playerAnimator.CrossFade("Idle", 0.2f, 0);

        Debug.Log("build start");
    }

    public void StateLoop()
    {
        
    }

    private void startBuildBridg() => StartBuid?.Invoke();


    private void stopBuildBridg() => StopBuild?.Invoke();


}
