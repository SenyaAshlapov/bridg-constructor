using System.Collections;
using UnityEngine;

public class BridgBuilder : MonoBehaviour
{
    public delegate void BridgEvent();
    public static BridgEvent BuildBridgUnit;
    public static BridgEvent BridgIsBuilded;

    #region Fields

    [SerializeField]private BridgUnit _bridgUnit;
    [SerializeField]private Transform _unitSpawnPoint;

    [Space(10)]
    [SerializeField]private float _timeToBuild;
    [SerializeField]private float _putDownSpeed;
    
    private BridgUnit _firtsBridgUnit;
    private bool _isCanBuild = false;

    #endregion

    #region Unity Functions

    private void Awake() 
    {
        RobotBuildState.StartBuid += startBuildBridg;
        RobotBuildState.StopBuild += stopBuildBridg;
    }

    private void OnDestroy() 
    {
        RobotBuildState.StartBuid -= startBuildBridg;
        RobotBuildState.StopBuild -= stopBuildBridg;
    }

    #endregion

    #region BuildBridg Functions

    private void startBuildBridg()
    {
        _isCanBuild = true;

        _firtsBridgUnit = Instantiate(_bridgUnit, _unitSpawnPoint.position, _unitSpawnPoint.rotation);
        StartCoroutine(buildBridg());
    }

    private void stopBuildBridg()
    {
        _isCanBuild = false;

        StopCoroutine(buildBridg());
        StartCoroutine(putDownBridg());
    }   

    private IEnumerator buildBridg()
    {
        if(_isCanBuild == true)
        { 
            while(_isCanBuild == true)
            {
                yield return new WaitForSeconds(_timeToBuild);
                BuildBridgUnit?.Invoke();
                
            }   
            yield return null;
        } 
       
    }

    private IEnumerator putDownBridg()
    {
        BridgIsBuilded?.Invoke();

        Quaternion startQuaternion = Quaternion.Euler(new Vector3(0,0,0));
        Quaternion endQuaternion = Quaternion.Euler(new Vector3(0,0,-90f));

        float putDownProgress = 0;

        while(putDownProgress <=  1)
        {
            _firtsBridgUnit.transform.rotation = Quaternion.Lerp(startQuaternion, endQuaternion, _putDownSpeed * putDownProgress);
            putDownProgress += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    #endregion
}
