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
            Debug.Log(" �κ��丮�� ���� á���ϴ�!");
            return false;
        }

        items.Add(new InventoryItem(itemType));
        Debug.Log($" {itemType} �������� �κ��丮�� �߰��߽��ϴ�. ���� ����: {items.Count}");
        return true;
    }

    public void ShowInventory()
    {
        Debug.Log(" ���� �κ��丮 ����:");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($" - ���� {i + 1}: {items[i].itemType}");
        }

        int empty = maxSlots - items.Count;
        for (int i = 0; i < empty; i++)
        {
            Debug.Log($" - ���� {items.Count + i + 1}: (��ĭ)");
        }
    }

    public int CurrentItemCount => items.Count;
    public int MaxSlots => maxSlots;
}
