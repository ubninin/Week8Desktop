using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // �� ������Ʈ�� �浹�� ���
            collision.GetComponent<Enemy>().OnDie();
            Destroy(gameObject); // �ڽ��� ������Ʈ ����
        }
    }
}
