using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageShutter : MonoBehaviour
{
    public float packageSpawnInterval = 1f;
    public int maxPackageSpawnAmount = 10;
    private int _spawnedAmount = 0;
    public GameObject packagePrefab;
    private Transform _spawnerPosition;
    void Start()
    {
        _spawnerPosition = GetComponent<Transform>();
        StartCoroutine(SpawnPackages());
        
    }
    

    IEnumerator SpawnPackages()
    {

        while (_spawnedAmount < maxPackageSpawnAmount)
        {
            yield return new WaitForSeconds(packageSpawnInterval);
            Instantiate(packagePrefab, _spawnerPosition);
            _spawnedAmount++;
        }
    }
}
