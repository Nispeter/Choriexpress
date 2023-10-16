public interface IPickupable : IInteractable
{
    bool isPickedUp { get; set; }
    
    bool isPickeable { get; set; }
    void OnPickup();
    void OnDrop();
}