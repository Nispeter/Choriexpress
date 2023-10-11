public interface IPickupable
{
    bool isPickedUp { get; set; }
    void OnPickup();
    void OnDrop();
}