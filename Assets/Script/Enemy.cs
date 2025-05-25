using System.Collections;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive, PlayerCollision }

public class Enemy : MonoBehaviour
{
    private Transform[] wayPoints;
    private int wayPointCount;
    private int currentIndex = 0;
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;
    [SerializeField] private int gogi = 10;
    [SerializeField] private int planks = 10;
    [SerializeField] private int pb = 10;
    [SerializeField] private int battery = 10;
    [SerializeField] private int tape = 10;
    [SerializeField] private int mt = 10;

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;
        wayPointCount = wayPoints.Length;
        this.wayPoints = wayPoints;
        transform.position = wayPoints[currentIndex].position;
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        else
        {
            gogi = 0;
            planks = 0;
            pb = 0;
            battery = 0;
            tape = 0;
            mt = 0;
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        if (enemySpawner == null)
        {
          

            return;
        }

        enemySpawner.DestroyEnemy(type, this, gogi, planks, pb, battery,tape,mt);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  // 플레이어 태그 확인
        {
            OnDie(EnemyDestroyType.PlayerCollision);
        }
    }
}
