using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button; // ��ư ���� �߰�

    private TowerSpawner towerSpawner;

    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    private PlayerAttack playerAttack; // �߰�

    public void Init(TowerSpawner spawner, PlayerAttack attack)
    {
        towerSpawner = spawner;
        playerAttack = attack;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            if (CurrentItemType == InventoryItemType.Planks)
            {
                towerSpawner.ReadyToSpawnTower();
                playerAttack.EquipShovel(false); // �� ���� ����
            }
            else if (CurrentItemType == InventoryItemType.Shovel)
            {
                playerAttack.EquipShovel(true); // �� ����
            }
            else
            {
                playerAttack.EquipShovel(false); // �� ���� ����
            }
        });
    }


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
