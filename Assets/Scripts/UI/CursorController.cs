using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public Camera playerCamera;
    public float interactDistance = 3.0f;
    public Sprite defaultCrosshair;
    public Sprite pickupableCrosshair;

    public Image crosshairImage;
    public UIHintController uiHintController;

    private int _framesBetweenChecks = 5;
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
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            IPickupable pickupable = hit.collider.GetComponent<IPickupable>();
            if (pickupable != null)
            {
                UpdateCrosshair(pickupableCrosshair);
                uiHintController.ShowHint();
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
