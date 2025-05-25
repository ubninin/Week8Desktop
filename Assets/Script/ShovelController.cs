using UnityEngine;

public class ShovelController : MonoBehaviour
{
    public Transform shovelPivot;
    

    public float swingAngle = 90f;
    public float swingSpeed = 360f;
    public LayerMask obstacleLayer;
    public float attackRange = 1.5f;

    private bool isSwinging = false;
    public bool isEquipped = false;
    private float currentAngle = 0f;
    private Quaternion initialRotation;

    private bool hitRegistered = false; // 한번만 공격 판정

    void Start()
    {
        initialRotation = shovelPivot.localRotation;
        //shovelVisual.SetActive(false);
    }

    void Update()
    {
        if (!isEquipped) return;
        //shovelVisual.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return) && !isSwinging)
        {

            isSwinging = true;
            currentAngle = 0f;
            hitRegistered = false;  // 공격 판정 리셋
            Debug.Log("휘둘시작");
        }

        if (isSwinging)
        {
            float deltaAngle = swingSpeed * Time.deltaTime;
            shovelPivot.Rotate(0, 0, -deltaAngle);
            currentAngle += deltaAngle;

            // 휘두르는 각도가 절반을 넘었을 때 딱 한 번만 공격 판정 실행


            if (currentAngle >= swingAngle)
            {
                isSwinging = false;
                shovelPivot.localRotation = initialRotation;
                Debug.Log("휘두르기 완료");
            }
        }
    }




}
