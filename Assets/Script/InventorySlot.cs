using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private TowerSpawner towerSpawner;
    private PlayerAttack playerAttack;
    private ShovelAttack shovelAttack;

    private PlayerHP playerHP;  // ??추가

    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    // ??Init 함수 수정
    public void Init(TowerSpawner spawner, ShovelAttack attack, PlayerHP hp)
    {
        towerSpawner = spawner;
        shovelAttack = attack;
        playerHP = hp;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            if (CurrentItemType == InventoryItemType.Planks)
            {
                towerSpawner.ReadyToSpawnTower();
                shovelAttack.EquipShovel(false);  // 삽 비활성화
            }
            else if (CurrentItemType == InventoryItemType.Shovel)
            {
                Debug.Log("삽 아이템 클릭됨"); // ? 확인용 로그
                shovelAttack.EquipShovel(true);   // 삽 활성화
            }

            else if (CurrentItemType == InventoryItemType.Gogi)
            {
                shovelAttack.EquipShovel(false);
                playerHP.Heal(1);
                Clear();
            }
            else
            {
                shovelAttack.EquipShovel(false);
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
