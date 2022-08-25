using UnityEngine;

public class Robot : MonoBehaviour
{
        

    #region Fields

    [SerializeField]private Transform _playerTransform;
    [SerializeField]private Animator _playerAnimator;
    private PlayerInput _playerInput;

    private  IState _currentState;
    private RobotIdleState _idleState;
    private RobotMoveState _moveState;
    private RobotBuildState _buildState;
    private RobotLoseState _loseState;

    #endregion


    #region Unity Functions

    void Awake()
    {
        BridgBuilder.BridgIsBuilded += changeStateToMove;
        RobotStoper.StopRobot += changeStateToBuild;
        Grounder.NotGrounder += changeStateToLose;

        _playerInput = new PlayerInput();
    }

    private void OnDestroy() 
    {
        BridgBuilder.BridgIsBuilded -= changeStateToMove;
        RobotStoper.StopRobot -= changeStateToBuild;
        Grounder.NotGrounder -= changeStateToLose;
    }

    private void Start() 
    {  
        _idleState = new RobotIdleState();
        _moveState = new RobotMoveState();
        _buildState = new RobotBuildState();
        _loseState = new RobotLoseState();


        _idleState.InitState(_playerTransform,_playerAnimator,_playerInput);
        _moveState.InitState(_playerTransform,_playerAnimator,_playerInput);
        _buildState.InitState(_playerTransform,_playerAnimator,_playerInput);
        _loseState.InitState(_playerTransform,_playerAnimator,_playerInput);

        changeState(_moveState);
    }

    void Update()
    {
       _currentState.StateLoop();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable() 
    {
        _playerInput.Disable();
    }
    #endregion

    private void changeStateToMove() => changeState(_moveState);
    private void changeStateToBuild() => changeState(_buildState);
    private void changeStateToLose() => changeState(_loseState);

    private void changeState(IState newState)
    {
        newState.StartState();
        _currentState = newState;
    }

}
