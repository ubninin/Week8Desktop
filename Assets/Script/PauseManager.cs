using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("���� �Ͻ�����");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("���� �簳");
        }
    }

    public bool IsPaused() => isPaused;
}
