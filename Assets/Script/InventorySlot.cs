using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private TowerSpawner towerSpawner;
    private PlayerAttack playerAttack;
    private ShovelAttack shovelAttack;

    private PlayerHP playerHP;  // ??�߰�

    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    // ??Init �Լ� ����
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
                shovelAttack.EquipShovel(false);  // �� ��Ȱ��ȭ
            }
            else if (CurrentItemType == InventoryItemType.Shovel)
            {
                Debug.Log("�� ������ Ŭ����"); // ? Ȯ�ο� �α�
                shovelAttack.EquipShovel(true);   // �� Ȱ��ȭ
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
