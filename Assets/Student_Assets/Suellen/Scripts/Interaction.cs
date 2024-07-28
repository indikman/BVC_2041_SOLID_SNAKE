using UnityEngine;

public class Interaction : MonoBehaviour
{
    public RotateDoor rotateDoor { get; private set; }
    public  PlayerInventory playerInventory { get; private set; }

    private IStrategy _interactionStrategy;

    private void Awake()
    {
        playerInventory = GetComponentInParent<PlayerInventory>();
        rotateDoor = FindAnyObjectByType<RotateDoor>();
    }

    private void OnEnable()
    {
        playerInventory.OnItemPicked += ChangeStrategy;
    }

    private void OnDisable()
    {
        playerInventory.OnItemPicked -= ChangeStrategy;
    }

    private void ChangeStrategy(ItemSO item)
    {
        if (item?.name == "Key")
        {
            _interactionStrategy = new OpenLockStrategy(this);
        }

        if (item?.name == "Laundry Detergent")
        {
            _interactionStrategy = new LaundryStrategy(this);
        }
    }

    public void ExecuteInteraction(string objectTag)
    {
            if (
                (objectTag == "Door" && _interactionStrategy is OpenLockStrategy) ||
                (objectTag == "Laundry" && _interactionStrategy is LaundryStrategy)
            )
            {
                _interactionStrategy?.Execute(); // Interacts
                playerInventory.RemoveItem();
        }
    }
}
