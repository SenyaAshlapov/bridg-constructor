using UnityEngine;

public class BridgUnit : MonoBehaviour
{
    #region Fields
    [SerializeField]private GameObject _bridgUnit;
    [SerializeField]private Transform _unitSpawnPoint;
    [SerializeField]private AudioSource _buildSound; 

    private bool _isUsed = false;

    #endregion

    #region Unity Functions

    private void Awake() 
    {
        BridgBuilder.BuildBridgUnit += buildNewBridgUnit;
        BridgBuilder.BridgIsBuilded += diactivateUnit;
    }

    private void OnDestroy() 
    {
        BridgBuilder.BuildBridgUnit -= buildNewBridgUnit;
        BridgBuilder.BridgIsBuilded -= diactivateUnit;
    }

    #endregion

    #region Bulding Functions

    private void diactivateUnit() => _isUsed = true;

    private void buildNewBridgUnit()
    {
        if(_isUsed == false)
        {       
            if(_bridgUnit != null)
            {
                var newUnit = Instantiate (_bridgUnit, _unitSpawnPoint.position, _unitSpawnPoint.rotation);
                newUnit.transform.parent = _unitSpawnPoint;

                playBuildSound();
            }

            _isUsed = true;
        }
    }

    private void playBuildSound()
    {
        float randomPitch = Random.Range(-0.3f, 0.3f);
        _buildSound.pitch += randomPitch;               
        _buildSound.Play();
    }

    #endregion
}
