using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PackageSpawner : MonoBehaviour
{
    public GameObject[] packagePrefabs; 
    public Transform spawnPoint;        
    private List<GameObject> spawnedPackages = new List<GameObject>();

    private void Start()
    {
        while (spawnedPackages.Count < 3)
        {
            SpawnPackage();
        }
    }

    private void Update()
    {

        spawnedPackages = spawnedPackages.Where(p => p != null).ToList();
        while (spawnedPackages.Count < 3)
        {
            SpawnPackage();
        }
    }

    void SpawnPackage()
    {
        GameObject packageToSpawn = packagePrefabs[Random.Range(0, packagePrefabs.Length)];
        GameObject spawnedPackage = Instantiate(packageToSpawn, spawnPoint.position, Quaternion.identity);
        spawnedPackages.Add(spawnedPackage);
    }
}
