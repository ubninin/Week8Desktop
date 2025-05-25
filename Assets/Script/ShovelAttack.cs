using UnityEngine;

public class ShovelAttack : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private Transform shovelPivot;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private string enemyTag = "Enemy";  // �� �±� ����

    private bool isAttacking = false;
    private float attackTimer = 0f;
    private float attackDuration = 0.25f;
    private float maxAngle = -90f;
    private bool hitRegistered = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && !isAttacking)
        {
            Debug.Log("�� ���� ����");
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
                Debug.Log("�� ���� ����");
            }
        }
    }

    void TryHitObstacle()
    {
        Collider2D hit = Physics2D.OverlapCircle(shovelPivot.position, attackRange, obstacleLayer);
        if (hit != null)
        {
            Debug.Log("Ÿ�� ��� �߰�: " + hit.name);

            if (hit.CompareTag(enemyTag))
            {
                EnemyHP enemyHP = hit.GetComponent<EnemyHP>();
                if (enemyHP != null)
                {
                    enemyHP.TakeDamage(damage);
                    Debug.Log("������ ������ ��");
                }
                else
                {
                    Debug.LogWarning("EnemyHP ������Ʈ ����");
                }
            }
            else
            {
                Destroy(hit.gameObject);
                Debug.Log("���� �ƴ� �� �ı�");
            }
        }
        else
        {
            Debug.Log("Ÿ�� ��� ����");
        }
    }
}