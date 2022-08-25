using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgUnit : MonoBehaviour
{
    [SerializeField]private bool _isUsed = false;
    [SerializeField]private GameObject _bridgUnit;
    [SerializeField]private Transform _unitSpawnPoint;


    private void Awake() 
    {
        BridgBuilder.BuildBridgUnit += buildNewBridgUnit;
        BridgBuilder.BridgIsBuilded += diactivateUnit;
    }

    private void OnDestroy() 
    {
        BridgBuilder.BuildBridgUnit -= buildNewBridgUnit;
    }

    private void buildNewBridgUnit()
    {
        if(_isUsed == false)
        {       
            Debug.Log("Unit spawned");

            if(_bridgUnit != null)
            {
                var newUnit = Instantiate (_bridgUnit, _unitSpawnPoint.position, _unitSpawnPoint.rotation);
                newUnit.transform.parent = _unitSpawnPoint;
            }

            _isUsed = true;
        }
    }

    private void diactivateUnit() => _isUsed = true;
}
