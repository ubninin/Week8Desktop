using UnityEngine;

public class ShovelAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Transform shovelPivot;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private string enemyTag = "Enemy";  // 적 태그 지정

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float attackDuration = 0.25f;
    private float maxAngle = -90f;
    private bool hitRegistered = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !isAttacking)
        {
            Debug.Log("삽 공격 시작");
            isAttacking = true;
            attackTimer = 0f;
            hitRegistered = false;
        }

        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            float t = attackTimer / attackDuration;

            int direction = playerTransform.localScale.x > 0 ? 1 : -1;
            float angle = Mathf.Lerp(0f, maxAngle * direction, t);
            shovelPivot.localRotation = Quaternion.Euler(0f, 0f, angle);

            if (!hitRegistered && t >= 0.5f)
            {
                hitRegistered = true;
                TryHitObstacle();
            }

            if (t >= 1f)
            {
                isAttacking = false;
                shovelPivot.localRotation = Quaternion.identity;
                Debug.Log("삽 공격 종료");
            }
        }
    }

    void TryHitObstacle()
    {
        Collider2D hit = Physics2D.OverlapCircle(shovelPivot.position, attackRange, obstacleLayer);
        if (hit != null)
        {
            Debug.Log("타격 대상 발견: " + hit.name);

            if (hit.CompareTag(enemyTag))
            {
                EnemyHP enemyHP = hit.GetComponent<EnemyHP>();
                if (enemyHP != null)
                {
                    enemyHP.TakeDamage(damage);
                    Debug.Log("적에게 데미지 줌");
                }
                else
                {
                    Debug.LogWarning("EnemyHP 컴포넌트 없음");
                }
            }
            else
            {
                Destroy(hit.gameObject);
                Debug.Log("적이 아님 → 파괴");
            }
        }
        else
        {
            Debug.Log("타격 대상 없음");
        }
    }
}