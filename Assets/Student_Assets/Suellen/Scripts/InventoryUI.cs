using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private InventoryItem _inventoryItemButton;
    [SerializeField] private Transform _inventoryGrid;
    [SerializeField] private GameObject _selectedItemDetail;

    [Header("Item Detail")]
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemDescription;
    [SerializeField] private Image _itemImage;

    private void OnEnable()
    {
        _playerInventory.OnItemLoaded += PopulateInventory;
        _playerInventory.OnItemSelected += PopulateSelectedItemDetail;
        _playerInventory.OnItemUsed += RemoveItemButton;
    }

    private void OnDisable()
    {
        _playerInventory.OnItemLoaded -= PopulateInventory;
        _playerInventory.OnItemSelected -= PopulateSelectedItemDetail;
        _playerInventory.OnItemUsed -= RemoveItemButton;
    }

    private void PopulateInventory(ItemSO item)
    {
        var newItem = Instantiate(_inventoryItemButton, _inventoryGrid);//
        newItem.DisplayItemData(item);

        Button button = newItem.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            _playerInventory.DisplayItemDetail(item);
            _selectedItemDetail.SetActive(true);
        });
    }

    private void PopulateSelectedItemDetail(ItemSO item)
    {
        _itemName.text = item.name;
        _itemDescription.text = item.description;
        _itemImage.sprite = item.sprite;
    }

    private void RemoveItemButton(ItemSO item)
    {
        Debug.Log($"Removing item button {item.name}");
        _selectedItemDetail.SetActive(false);

        Button[] allButtons = _inventoryGrid.GetComponentsInChildren<Button>(); 

        foreach (Button button in allButtons)
        {
            InventoryItem inventoryItem = button.GetComponent<InventoryItem>();
            if (inventoryItem.itemSO == item)
            {
                Destroy(button.gameObject);
            }
        }
    }
}
