using UnityEngine;

public class Island : MonoBehaviour
{
    #region Fields

    [SerializeField]private GameObject _leftIslandPart;
    [SerializeField]private GameObject _middleIslandPart;
    [SerializeField]private GameObject _rightIslandPart;

    [SerializeField]private Transform _spawnPoint;
    [SerializeField]private int _maxIslandSize;
    [SerializeField]private float _partsSpawnShift;

    #endregion

    private void Start() 
    {
        GenerateIsland();
    }

    #region GenerateIsland Fields

    public void GenerateIsland()
    {
        int islandSize = Random.Range(1, _maxIslandSize);
        float totalShift = 0;

        var leftIslandPart = Instantiate(_leftIslandPart, _spawnPoint);

        for(int i = 1; i<= islandSize; i++)
        {
            totalShift += _partsSpawnShift;

            if(i == islandSize)
            {
                generateIslandPart(_rightIslandPart, _spawnPoint,totalShift);
            }
            else
            {
                generateIslandPart(_middleIslandPart, _spawnPoint,totalShift);
            }
        }
    }

    private void generateIslandPart(GameObject part, Transform spawnPoint, float shift)
    {
        var newPart =  Instantiate(part, spawnPoint.position + new Vector3(shift, 0, 0), spawnPoint.rotation);
        newPart.transform.parent = spawnPoint;
    }

    #endregion
}
