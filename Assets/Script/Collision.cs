using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private Tile tile; // Ÿ���� ��ġ�� Ÿ�� ����

    // Ÿ�� ���� �� ȣ���Ͽ� Ÿ�� ���� ����
    public void SetTile(Tile tile)
    {
        this.tile = tile;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           

            if (tile != null)
            {
                tile.IsBuildTower = false; // Ÿ�Ͽ� Ÿ�� ���� ǥ��
            }

            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                other.GetComponent<EnemyHP>().TakeDamage(damage);
                //enemy.OnDie();
            }

            Destroy(gameObject); // Ÿ�� ����
        }
    }
}
