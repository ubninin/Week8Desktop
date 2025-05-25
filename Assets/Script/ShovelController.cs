using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public Transform shovelPivot;
    public GameObject shovelVisual;

    public float swingAngle = 90f;
    public float swingSpeed = 360f;
    public LayerMask obstacleLayer;
    public float attackRange = 1.5f;

    private bool isSwinging = false;
    public bool isEquipped = false;
    private float currentAngle = 0f;
    private Quaternion initialRotation;

    private bool hitRegistered = false; // �ѹ��� ���� ����

    void Start()
    {
        initialRotation = shovelPivot.localRotation;
        shovelVisual.SetActive(false);
    }

    void Update()
    {
        if (!isEquipped) return;

        if (Input.GetKeyDown(KeyCode.Return) && !isSwinging)
        {
            isSwinging = true;
            currentAngle = 0f;
            hitRegistered = false;  // ���� ���� ����
            Debug.Log("�ֵѽ���");
        }

        if (isSwinging)
        {
            float deltaAngle = swingSpeed * Time.deltaTime;
            shovelPivot.Rotate(0, 0, -deltaAngle);
            currentAngle += deltaAngle;

            // �ֵθ��� ������ ������ �Ѿ��� �� �� �� ���� ���� ���� ����


            if (currentAngle >= swingAngle)
            {
                isSwinging = false;
                shovelPivot.localRotation = initialRotation;
                Debug.Log("�ֵθ��� �Ϸ�");
            }
        }
    }



    public void EquipShovel()
    {
        isEquipped = true;
        shovelVisual.SetActive(true);
    }

    public void UnequipShovel()
    {
        isEquipped = false;
        shovelVisual.SetActive(false);
        shovelPivot.localRotation = initialRotation;
        isSwinging = false;
    }
}
