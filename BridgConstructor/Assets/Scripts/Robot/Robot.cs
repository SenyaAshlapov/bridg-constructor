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

    #endregion


    #region Unity Functions

    void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start() 
    {  
        _idleState = new RobotIdleState();
        _moveState = new RobotMoveState();
        _buildState = new RobotBuildState();


        _idleState.InitState(_playerTransform,_playerAnimator,_playerInput);
        _moveState.InitState(_playerTransform,_playerAnimator,_playerInput);
        _buildState.InitState(_playerTransform,_playerAnimator,_playerInput);

        changeState(_buildState);
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

    private void changeState(IState newState)
    {
        newState.StartState();
        _currentState = newState;
    }

}
