using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PackageSpawner : MonoBehaviour
{
    public GameObject[] packagePrefabs; 
    public Transform spawnPoint;        
     public float spawnInterval = 2.0f; 

    public AudioSource BoxHittingGround;

    private void Start()
    {
        // Start spawning packages every spawnInterval seconds
        InvokeRepeating("SpawnPackage", 0f, spawnInterval);
    }

    void SpawnPackage()
    {
        GameObject packageToSpawn = packagePrefabs[Random.Range(0, packagePrefabs.Length)];
        Instantiate(packageToSpawn, spawnPoint.position, Quaternion.identity);
        BoxHittingGround.Play();
    }
}
