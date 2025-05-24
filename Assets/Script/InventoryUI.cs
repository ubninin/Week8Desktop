using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Sprite gogiSprite;
    [SerializeField] private Sprite planksSprite;
    [SerializeField] private Transform slotParent;

    private List<InventorySlot> slots = new List<InventorySlot>();
    private int maxSlots = 6;

    private void Awake()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slotObj = Instantiate(slotPrefab, slotParent);
            InventorySlot slot = slotObj.GetComponent<InventorySlot>();
            slot.Clear();
            slots.Add(slot);
        }
    }

    public bool AddItem(InventoryItemType type)
    {
        Sprite sprite = GetSpriteForItem(type);

        foreach (var slot in slots)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite == null)
            {
                slot.SetItem(sprite);
                return true;
            }
        }

        Debug.Log("인벤토리가 가득 찼습니다.");
        return false;
    }

    private Sprite GetSpriteForItem(InventoryItemType type)
    {
        switch (type)
        {
            case InventoryItemType.Gogi:
                return gogiSprite;
            case InventoryItemType.Planks:
                return planksSprite;
            default:
                return null;
        }
    }
}
