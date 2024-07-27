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
        //_playerInventory.OnItemUsed += RemoveItemButton;
        //_playerInventory.OnItemPicked += RemoveItemButton; //strategy
    }

    private void OnDisable()
    {
        _playerInventory.OnItemLoaded -= PopulateInventory;
        _playerInventory.OnItemSelected -= PopulateSelectedItemDetail;
        //_playerInventory.OnItemUsed -= RemoveItemButton;
        //_playerInventory.OnItemPicked -= RemoveItemButton; //strategy
    }

    private void PopulateInventory(ItemSO item)
    {
        var newItem = Instantiate(_inventoryItemButton, _inventoryGrid);//
        newItem.DisplayItemData(item);

        Button button = newItem.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            Debug.Log("Button Pressed!");
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

    //private void RemoveItemButton(ItemSO item)
    //{
    //    Debug.Log($"Removing item button {item.name}");
    //    Destroy(button.gameObject);
    //    _selectedItemDetail.SetActive(false);
    //    _playerInventory.RemoveItem(item); //wrong use event
    //}
}
