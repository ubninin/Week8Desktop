using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button retryButton;

    void Start()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        retryButton.onClick.AddListener(OnRetryClicked);
    }

    private void OnMainMenuClicked()
    {
        // 메인 메뉴 씬으로 이동 (씬 이름에 맞게 수정)
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRetryClicked()
    {
        Time.timeScale = 1f; // 씬 전환 전 복구
        GameManager.isGameCleared = false;
        SceneManager.LoadScene("GameScene");

    }
}
