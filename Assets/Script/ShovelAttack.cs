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
    private Tile tile; // 타워가 위치한 타일 참조
    private bool isShovelEquipped = false;
    public GameObject shovelVisual;
    public void EquipShovel(bool equip)
    {
        Debug.Log("삽 장착됨");
        shovelVisual.SetActive(true);
        isShovelEquipped = equip;
        shovelPivot.gameObject.SetActive(equip);
        if (shovelPivot != null)
        {
            shovelPivot.gameObject.SetActive(equip);  // 삽만 활성화/비활성화
        }
        else
        {
            Debug.LogWarning("shovelPivot이 할당되지 않았습니다!");
        }
    }


    public void SetTile(Tile tile)
    {
        this.tile = tile;
    }
    void Update()
    {
        if (!isShovelEquipped)
        {
            //Debug.Log("장착안됨");
            
            return;  // 삽이 장착되지 않았으면 공격 무시
        }

        if (Input.GetKeyDown(KeyCode.Return) && !isAttacking)
        {
          

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
                // Obstacle이면서 적이 아닌 경우
                Obstacle obstacle = hit.GetComponent<Obstacle>();
                if (obstacle != null && obstacle.tile != null)
                {
                    obstacle.tile.IsBuildTower = false;
                    Debug.Log("타일에 타워 없음으로 설정");
                }

                Destroy(hit.gameObject);
          
            }

        }
        else
        {
            Debug.Log("타격 대상 없음");
        }
    }
}