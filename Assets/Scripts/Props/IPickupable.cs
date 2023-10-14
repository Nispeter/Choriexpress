public interface IPickupable : IInteractable
{
    bool isPickedUp { get; set; }
    void OnPickup();
    void OnDrop();
}