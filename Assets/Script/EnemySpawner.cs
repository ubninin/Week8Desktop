using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; // �� ������
    [SerializeField] private GameObject enemyHPSliderPrefab;
    [SerializeField] private Transform canvasTransform;

    [SerializeField]
    private float spawnTime; // �� ���� �ֱ�

    [SerializeField]
    private Transform[] wayPoints; // ���� ���������� �̵� ���
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
        // �� ���� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject clone = Instantiate(enemyPrefab); // �� ������Ʈ ����
            Enemy enemy = clone.GetComponent<Enemy>(); // ��� ������ ���� Enemy ������Ʈ
            enemy.Setup(this,wayPoints); // wayPoint ������ �Ű������� Setup() ȣ��
            enemyList.Add(enemy);
            SpawnEnemyHPSlider(clone);
            
            yield return new WaitForSeconds(spawnTime); // spawnTime �ð� ���� ���
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
            float chance = Random.value; // 0.0f ~ 1.0f ������ ������

            if (chance < 0.16f) //������ ����
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
        // �� ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);

        // Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
        // Tip. UI�� ĵ������ �ڽĿ�����Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�
        sliderClone.transform.SetParent(canvasTransform);

        // ���� �������� �ٲ� ũ�⸦ �ٽ� (1, 1, 1)�� ����
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);

        // Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
