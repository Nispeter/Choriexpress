using System.Collections;
using TMPro;
using UnityEngine;

public class TMPBlink3D : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro; // Assign your 3D TMP text object here in the inspector.
    public float blinkInterval = 3f; // Time in seconds for each blink cycle (on-off).
    private bool isBlinking = false;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogWarning("TextMeshProUGUI reference not set. Please assign it in the inspector.");
            return;
        }

        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        isBlinking = true;

        while (isBlinking)
        {
            textMeshPro.alpha = 0f; // Hide the text.
            yield return new WaitForSeconds(blinkInterval);

            textMeshPro.alpha = 1f; // Show the text.
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // If you want to stop the blinking at some point, you can call this method.
    public void StopBlinking()
    {
        isBlinking = false;
        textMeshPro.alpha = 1f; // Ensure text is visible after stopping the blink.
    }
}
