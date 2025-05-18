using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;
    public float heightOffset = 2.0f; // 플레이어 위쪽으로 비추기 위한 높이 오프셋

    private void FixedUpdate()
    {
        // 플레이어와 카메라의 위치 차이를 계산
        Vector3 dir = player.transform.position - this.transform.position;

        // 카메라의 y축 위치를 플레이어의 y축 위치보다 높게 설정
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + heightOffset, this.transform.position.z);

        // 카메라를 부드럽게 이동
        Vector3 moveVector = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        this.transform.position = moveVector;
    }
}
