using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Sprite gogiSprite;
    [SerializeField] private Sprite planksSprite;
    [SerializeField] private Sprite shovelSprite;
    [SerializeField] private PlayerPlanks playerPlanks;
    [SerializeField] private TowerSpawner towerSpawner;

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
            slot.Init(towerSpawner); //  여기서 연결!
            slots.Add(slot);
        }
    }


    private void Start()
    {
        AddItem(InventoryItemType.Shovel); // 삽 추가

        if (playerPlanks != null)
        {
            AddMultipleItems(InventoryItemType.Planks, playerPlanks.CurrentPlanks);
        }
    }

    public bool AddItem(InventoryItemType type)
    {
        Sprite sprite = GetSpriteForItem(type);

        foreach (var slot in slots)
        {
            if (slot.CurrentItemType == InventoryItemType.None)
            {
                slot.SetItem(sprite, type);
                return true;
            }
        }

        Debug.Log("인벤토리가 가득 찼습니다.");
        return false;
    }

    public bool RemoveItem(InventoryItemType type)
    {
        foreach (var slot in slots)
        {
            if (slot.CurrentItemType == type)
            {
                slot.Clear();
                return true;
            }
        }

        Debug.Log("인벤토리에서 아이템 제거 실패: 해당 아이템 없음");
        return false;
    }

    public void AddMultipleItems(InventoryItemType type, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (!AddItem(type))
            {
                Debug.Log("인벤토리가 가득 찼습니다. 일부 아이템이 표시되지 않았습니다.");
                break;
            }
        }
    }

    private Sprite GetSpriteForItem(InventoryItemType type)
    {
        switch (type)
        {
            case InventoryItemType.Gogi: return gogiSprite;
            case InventoryItemType.Planks: return planksSprite;
            case InventoryItemType.Shovel: return shovelSprite;
            default: return null;
        }
    }
}
