using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{

    [Range(0,20)]
    [SerializeField]private float _spawnMaxDistance;
    
    [Range(0,20)]
    [SerializeField]private float _spawnMinDistance;



    [SerializeField]private GameObject _islandPrefab;


    private float _totalDistance = 0;

    private void Start()
    {
        spawnNewIsland();
    }
    private void Awake() 
    {
        BridgBuilder.BridgIsBuilded += spawnNewIsland;
    }

    private void OnDestroy() 
    {
        BridgBuilder.BridgIsBuilded -= spawnNewIsland;
    }

    private void spawnNewIsland()
    {
        float distanceToNewIsland = Random.Range(_spawnMinDistance, _spawnMaxDistance);

        _totalDistance += distanceToNewIsland;

        Instantiate(_islandPrefab, transform.position + new Vector3(_totalDistance, 0,0), transform.rotation);
    }
}
