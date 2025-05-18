using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 5.0f;
    public GameObject player;
    public float heightOffset = 2.0f; // �÷��̾� �������� ���߱� ���� ���� ������

    private void FixedUpdate()
    {
        // �÷��̾�� ī�޶��� ��ġ ���̸� ���
        Vector3 dir = player.transform.position - this.transform.position;

        // ī�޶��� y�� ��ġ�� �÷��̾��� y�� ��ġ���� ���� ����
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + heightOffset, this.transform.position.z);

        // ī�޶� �ε巴�� �̵�
        Vector3 moveVector = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);
        this.transform.position = moveVector;
    }
}
