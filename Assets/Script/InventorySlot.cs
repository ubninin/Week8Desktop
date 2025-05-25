using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Button button;

    private TowerSpawner towerSpawner;
    private PlayerAttack playerAttack;
    private ShovelAttack shovelAttack;
    private PlayerHP playerHP;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector2 originalPosition;
    // 기존 static bool → static int로 변경
    public static int PbCount = 0;
    public static int BatteryCount = 0;
    public static int TapeCount = 0;
    public static int MtCount = 0;
    public static int PlanksCount = 0;


    public InventoryItemType CurrentItemType { get; private set; } = InventoryItemType.None;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

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
                shovelAttack.EquipShovel(false);
            }
            else if (CurrentItemType == InventoryItemType.Shovel)
            {
            

                shovelAttack.EquipShovel(true);
            }
            else if (CurrentItemType == InventoryItemType.Gogi)
            {
                shovelAttack.EquipShovel(false);
                playerHP.Heal(1);
                Clear();
            }
            else if (CurrentItemType == InventoryItemType.Pb) //비닐 동작
            {
                shovelAttack.EquipShovel(false);
            }
            else if (CurrentItemType == InventoryItemType.Battery) //비닐 동작
            {
                shovelAttack.EquipShovel(false);
            }
            else if (CurrentItemType == InventoryItemType.Tape) //비닐 동작
            {
                shovelAttack.EquipShovel(false);
            }
            else if (CurrentItemType == InventoryItemType.Mt) //비닐 동작
            {
                shovelAttack.EquipShovel(false);
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

        switch (type)
        {
            case InventoryItemType.Pb:
                PbCount += 1;
                Debug.Log("vinyl");
                break;
            case InventoryItemType.Battery:
                BatteryCount += 1;
                break;
            case InventoryItemType.Tape:
                TapeCount += 1;
                break;
            case InventoryItemType.Mt:
                MtCount += 1;
                break;
            case InventoryItemType.Planks:
                PlanksCount += 1;
                break;
        }
    }



    public void Clear()
    {
        switch (CurrentItemType)
        {
            case InventoryItemType.Pb:
                PbCount -= 1;
                break;
            case InventoryItemType.Battery:
                BatteryCount-= 1;
                break;
            case InventoryItemType.Tape:
                TapeCount -= 1;
                break;
            case InventoryItemType.Mt:
                MtCount -= 1;
                break;
            case InventoryItemType.Planks:
                PlanksCount -= 1;
                break;
        }

        itemImage.sprite = null;
        itemImage.enabled = false;
        CurrentItemType = InventoryItemType.None;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (CurrentItemType == InventoryItemType.None) return;

        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CurrentItemType == InventoryItemType.None) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        // 삽은 버릴 수 없게 처리
        if (CurrentItemType == InventoryItemType.Shovel)
        {
        

            rectTransform.anchoredPosition = originalPosition;
            return;
        }

        Vector2 screenPoint = eventData.position;
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider == null || hit.collider.gameObject.layer != LayerMask.NameToLayer("Tile"))
        {
        
            Clear();
        }

        rectTransform.anchoredPosition = originalPosition;
    }
}
