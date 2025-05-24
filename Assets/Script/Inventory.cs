using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int maxSlots = 6;

    private List<InventoryItem> items = new List<InventoryItem>();

    public bool AddItem(InventoryItemType itemType)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log(" 인벤토리가 가득 찼습니다!");
            return false;
        }

        items.Add(new InventoryItem(itemType));
        Debug.Log($" {itemType} 아이템을 인벤토리에 추가했습니다. 현재 개수: {items.Count}");
        return true;
    }

    public void ShowInventory()
    {
        Debug.Log(" 현재 인벤토리 상태:");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($" - 슬롯 {i + 1}: {items[i].itemType}");
        }

        int empty = maxSlots - items.Count;
        for (int i = 0; i < empty; i++)
        {
            Debug.Log($" - 슬롯 {items.Count + i + 1}: (빈칸)");
        }
    }

    public int CurrentItemCount => items.Count;
    public int MaxSlots => maxSlots;
}
