using UnityEngine;

public class Robot : MonoBehaviour
{
    public delegate void RobotAction();
    public static RobotAction FinishLevel;
    public static RobotAction UpdateScore;


    #region Fields
    public static int Score = 0;
    private bool _isFirstIsland = true;
    private bool _isLose = false;

    [SerializeField]private Transform _playerTransform;
    [SerializeField]private Animator _playerAnimator;
    [SerializeField]private float _deadHeight;
    private PlayerInput _playerInput;

    private  IState _currentState;
    private RobotIdleState _idleState;
    private RobotMoveState _moveState;
    private RobotBuildState _buildState;
    private RobotLoseState _loseState;

    [SerializeField]private AudioSource _loseSound;

    
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

       if(transform.position.y <= _deadHeight)
       {
            changeState(_idleState);
            FinishLevel?.Invoke();
       }
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
    
    private void changeStateToBuild() 
    {
        changeState(_buildState);
        
        if(_isFirstIsland == true)
        {
            _isFirstIsland = false;
        }
        else
        {
            ++Score;
            UpdateScore?.Invoke();
        }
    } 

    private void changeStateToLose() 
    {
        if(_isLose == false)
        {
            changeState(_loseState);
            _loseSound.Play();

            _isLose = true;
        }

    } 

    private void changeState(IState newState)
    {
        newState.StartState();
        _currentState = newState;
    }
    

}
