using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // 적 프리팹
    [SerializeField] private GameObject enemyHPSliderPrefab;
    [SerializeField] private Transform canvasTransform;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;

    [SerializeField]
    private Transform[] wayPoints; // 현재 스테이지의 이동 경로
    [SerializeField] private PlayerHP playerHP;
    [SerializeField] private PlayerGogi playerGogi;
    [SerializeField] private PlayerPb playerPb;

    [SerializeField] private PlayerPlanks playerPlanks;

    [SerializeField] private PlayerBattery playerBattery;
    [SerializeField] private PlayerTape playerTape;
    [SerializeField] private PlayerMt playerMt;
    [SerializeField] private InventoryUI inventoryUI;
    private List<Enemy> enemyList;
    public List<Enemy> EnemyList => enemyList;
    private void Awake()
    {
        enemyList = new List<Enemy>();
        // 적 생성 코루틴 함수 호출
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); // 적 오브젝트 생성
            Enemy enemy = clone.GetComponent<Enemy>(); // 방금 생성된 적의 Enemy 컴포넌트
            enemy.Setup(this,wayPoints); // wayPoint 정보를 매개변수로 Setup() 호출
            enemyList.Add(enemy);
            SpawnEnemyHPSlider(clone);

            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));

        }
    }
    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy,int gogi, int planks, int pb, int battery, int tape, int mt)
    {
        if (type == EnemyDestroyType.PlayerCollision)
        {
            playerHP.TakeDamage(1);
        }
        else if (type == EnemyDestroyType.Kill)
        {
            float chance = Random.value; // 0.0f ~ 1.0f 사이의 랜덤값

            if (chance < 0.16f) //아이템 지급
            {
                if (playerPlanks != null)
                {
                    playerPlanks.CurrentPlanks += 1;
                   

                    inventoryUI.AddItem(InventoryItemType.Planks);
                }
                else
                    Debug.LogWarning("playerPlanks is null!");
            }
            else if (chance < 0.32f)//
            {
                if (playerPb != null)
                {
                    playerPb.CurrentPb += 1;
                    Debug.Log("pb get");
                    inventoryUI.AddItem(InventoryItemType.Pb);
                }

                else
                    Debug.LogWarning("playerPb is null!");
            }
            else if (chance < 0.48f)//
            {
                if (playerBattery != null)
                {
                    playerBattery.CurrentBattery += 1;
                  

                    inventoryUI.AddItem(InventoryItemType.Battery);
                }

                else
                    Debug.LogWarning("playerBattery is null!");
            }
            else if (chance < 0.64f)//
            {
                if (playerTape != null)
                {
                    playerTape.CurrentTape += 1;
                    Debug.Log("Tape get");
                    inventoryUI.AddItem(InventoryItemType.Tape);
                }

                else
                    Debug.LogWarning("playerTape is null!");
            }
            else if (chance < 0.80f)//
            {
                if (playerMt != null)
                {
                    playerMt.CurrentMt += 1;
                    Debug.Log("Mt get");
                    inventoryUI.AddItem(InventoryItemType.Mt);
                }

                else
                    Debug.LogWarning("playerMt is null!");
            }
            else 
            {
                if (playerGogi != null)
                {
                    playerGogi.CurrentGogi += 1;
                    

                    inventoryUI.AddItem(InventoryItemType.Gogi);
                }

                else
                    Debug.LogWarning("playerGogi is null!");
            }
        }


        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }
    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        // 적 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        // Slider UI 오브젝트를 parent("Canvas" 오브젝트)의 자식으로 설정
        // Tip. UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다
        sliderClone.transform.SetParent(canvasTransform);

        // 계층 설정으로 바뀐 크기를 다시 (1, 1, 1)로 설정
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.transform.SetSiblingIndex(0); // << 이 줄 추가
        // Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);

        // Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
