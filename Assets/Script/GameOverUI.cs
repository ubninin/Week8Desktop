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
        // ���� �޴� ������ �̵� (�� �̸��� �°� ����)
        SceneManager.LoadScene("MainMenu");
    }

    private void OnRetryClicked()
    {
        Time.timeScale = 1f; // �� ��ȯ �� ����
        GameManager.isGameCleared = false;
        SceneManager.LoadScene("GameScene");

    }
}
