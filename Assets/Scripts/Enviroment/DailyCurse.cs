// DailyCurse.cs
using UnityEngine;
using System.Collections;

public class DailyCurse : MonoBehaviour
{
    /*public int day = 1;
    private FirstPersonController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<FirstPersonController>();
        if (!playerController)
            Debug.LogError("FirstPersonController not found!");

        ActivateCurse();
    }

    private void ActivateCurse()
    {
        switch(day)
        {
            case 1:
                StartCoroutine(PlayerJumpCurse());
                break;
            case 2:
                StartCoroutine(PackageMoveCurse());
                break;
            case 3:
                StartCoroutine(PlayerJumpCurse());  
                break;
        }
    }

    IEnumerator PlayerJumpCurse()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));  
            playerController.Jump(); 
        }
    }

    IEnumerator PackageMoveCurse()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
            if (packages.Length > 0)
            {
                GameObject randomPackage = packages[Random.Range(0, packages.Length)];
                randomPackage.transform.position += new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }
        }
    }*/
}
