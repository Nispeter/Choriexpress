using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 3.0f;
    public Sprite defaultCrosshair;
    public Sprite interactableCrosshair;

    public Image crosshairImage;
    public UIHintController uiHintController;

    private int _framesBetweenChecks = 20;
    private int _currentFrame = 0;

    private void Update()
    {
        _currentFrame++;
        if (_currentFrame >= _framesBetweenChecks)
        {
            CheckCursorChange();
            _currentFrame = 0;
        }
    }

    void CheckCursorChange()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green, 2.0f);
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                UpdateCrosshair(interactableCrosshair);
                uiHintController.ShowHint(interactable.type);
                return;
            }
        }

        UpdateCrosshair(defaultCrosshair);
        uiHintController.HideHint();
    }

    public void UpdateCrosshair(Sprite crosshairSprite)
    {
        crosshairImage.sprite = crosshairSprite;
    }
}
