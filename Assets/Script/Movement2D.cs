using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed = 1f;
    [SerializeField] private float maxMoveSpeed = 3f;

    [SerializeField] private Vector3 moveDirection = Vector3.zero;

    private float moveSpeed; // 누락된 선언 추가

    private void Awake()
    {
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
