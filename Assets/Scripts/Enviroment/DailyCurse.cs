// DailyCurse.cs
using UnityEngine;
using System.Collections;

public class DailyCurse : MonoBehaviour
{
    public int day = 1;
    private FirstPersonMovement playerController;
    private Coroutine currentCurse; // To track the current running curse

    private void Start()
    {
        playerController = FindObjectOfType<FirstPersonMovement>();
        if (!playerController)
            Debug.LogError("FirstPersonController not found!");
    }

    public void ActivateCurse(int day)
    {
        Debug.Log("curse " + day + "activated");
        if (currentCurse != null) // Stop the previous curse if there was one
            StopCoroutine(currentCurse);
        this.day = day;
        switch (day)
        {
            case 1:
                currentCurse = StartCoroutine(PlayerJumpCurse());
                break;
            case 2:
                currentCurse = StartCoroutine(InvertControlsCurse());
                break;
            case 3:
                currentCurse = StartCoroutine(PackageMoveCurse());
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

    IEnumerator InvertControlsCurse()
    {
        playerController.ToggleInvertedControls();
        yield return null;
    }

    IEnumerator PackageMoveCurse()
    {
        float MRF = 10f;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            GameObject[] packages = GameObject.FindGameObjectsWithTag("Package");
            if (packages.Length > 0)
            {
                GameObject randomPackage = packages[Random.Range(0, packages.Length)];
                Rigidbody rb = randomPackage.GetComponent<Rigidbody>();
                if (rb)
                {
                    Vector3 randomForce = new Vector3(Random.Range(-MRF, MRF), Random.Range(-MRF, MRF), Random.Range(-MRF, MRF));
                    rb.AddForce(randomForce, ForceMode.Impulse); // Apply a sudden force, using the Impulse mode
                }
            }
        }
    }

    public void StopCurrentCurse()
    {
        if (day == 2)
        {
            playerController.ResetControls(); // Ensure the controls are reverted if day is 2
        }
        else if (currentCurse != null)
        {
            StopCoroutine(currentCurse);
            currentCurse = null;
            Debug.Log("Curse stopped");
        }
        
    }
}
