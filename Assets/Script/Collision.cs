using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // 적 오브젝트와 충돌한 경우
            collision.GetComponent<Enemy>().OnDie();
            Destroy(gameObject); // 자신의 오브젝트 삭제
        }
    }
}
