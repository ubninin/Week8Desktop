using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    public void SetItem(Sprite itemSprite, InventoryItemType type)
    {
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
        CurrentItemType = type;
    }

    public void Clear()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
        CurrentItemType = InventoryItemType.None;
    }
}
