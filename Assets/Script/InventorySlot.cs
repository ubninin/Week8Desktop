using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    public void SetItem(Sprite itemSprite)
    {
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;
    }

    public void Clear()
    {
        itemImage.sprite = null;
        itemImage.enabled = false;
    }
}
