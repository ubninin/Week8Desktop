using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private GameObject shovelObject; // 씬에 존재하는 삽 오브젝트
  

    private bool isShovelEquipped = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isShovelEquipped)
        {
            Attack();
        }
    }

    public void EquipShovel(bool equip)
    {
        isShovelEquipped = equip;
        shovelObject.SetActive(equip);
    }

    private void Attack()
    {
        Vector2 attackPos = transform.position;

        Collider2D hit = Physics2D.OverlapCircle(attackPos, attackRange, obstacleLayer);
        if (hit != null)
        {
            //tile.IsBuildTower = false;
            Destroy(hit.gameObject);
         
          
             // 타일에 타워 없음 표시
            
            Debug.Log("장애물 파괴됨!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
