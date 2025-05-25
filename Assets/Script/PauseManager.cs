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
            Debug.Log("게임 일시정지");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("게임 재개");
        }
    }

    public bool IsPaused() => isPaused;
}
