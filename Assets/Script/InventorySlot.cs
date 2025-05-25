using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private TowerSpawner towerSpawner;
    private PlayerAttack playerAttack;
    private PlayerHP playerHP;  // ??추가

    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    // ??Init 함수 수정
    public void Init(TowerSpawner spawner, PlayerAttack attack, PlayerHP hp)
    {
        towerSpawner = spawner;
        playerAttack = attack;
        playerHP = hp;  // ??할당

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            if (CurrentItemType == InventoryItemType.Planks)
            {
                towerSpawner.ReadyToSpawnTower();
                playerAttack.EquipShovel(false);
            }
            else if (CurrentItemType == InventoryItemType.Shovel)
            {
                playerAttack.EquipShovel(true);
            }
            else if (CurrentItemType == InventoryItemType.Gogi)
            {
                playerAttack.EquipShovel(false);
                playerHP.Heal(1);  // ??고기 클릭 시 체력 1 회복
                Clear();
            }
            else
            {
                playerAttack.EquipShovel(false);
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
