using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private GameObject shovelObject; // ¾À¿¡ Á¸ÀçÇÏ´Â »ð ¿ÀºêÁ§Æ®

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
            Destroy(hit.gameObject);
            Debug.Log("Àå¾Ö¹° ÆÄ±«µÊ!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
