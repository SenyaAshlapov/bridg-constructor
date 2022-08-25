using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField]private GameObject _leftIslandPart;
    [SerializeField]private GameObject _middleIslandPart;
    [SerializeField]private GameObject _rightIslandPart;

    [SerializeField]private Transform _spawnPoint;
    [SerializeField]private int _maxIslandSize;
    [SerializeField]private float _partsSpawnShift;


    private void Start() 
    {
        GenerateIsland();
    }

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
                var rightIslandPart =  Instantiate(_rightIslandPart, _spawnPoint.position + new Vector3(totalShift, 0, 0), _spawnPoint.rotation);
                rightIslandPart.transform.parent = _spawnPoint;
            }
            else
            {
                var middleIslandPart = Instantiate(_middleIslandPart, _spawnPoint.position + new Vector3(totalShift, 0, 0), _spawnPoint.rotation);
                middleIslandPart.transform.parent = _spawnPoint;

            }
        }
    }
}
