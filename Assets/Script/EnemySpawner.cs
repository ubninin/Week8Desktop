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
    public void DestroyEnemy(Enemy enemy)
    {
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
