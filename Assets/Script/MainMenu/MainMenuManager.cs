using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ��
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject tutorialPanel;
    public GameObject exitConfirmPanel;

    [Header("Buttons")]
    public Button startButton;
    public Button tutorialButton;
    public Button tutorialCloseButton;
    public Button exitButton;
    public Button exitYesButton;
    public Button exitNoButton;

    void Start()
    {
        // �ʱ� UI ����
        tutorialPanel.SetActive(false);
        exitConfirmPanel.SetActive(false);

        // ��ư ������ ���
        startButton.onClick.AddListener(OnStartClicked);
        tutorialButton.onClick.AddListener(OnTutorialClicked);
        tutorialCloseButton.onClick.AddListener(OnTutorialCloseClicked);
        exitButton.onClick.AddListener(OnExitClicked);
        exitYesButton.onClick.AddListener(OnExitYesClicked);
        exitNoButton.onClick.AddListener(OnExitNoClicked);
    }

    void OnStartClicked()
    {
        // ���� ���� ������ ��ȯ (�� �̸��� ������Ʈ�� �°� ����)
        SceneManager.LoadScene("GameScene");
    }

    void OnTutorialClicked()
    {
        tutorialPanel.SetActive(true);
        exitConfirmPanel.SetActive(false);
    }

    void OnTutorialCloseClicked()
    {
        tutorialPanel.SetActive(false);
    }

    void OnExitClicked()
    {
        // ���� Ȯ�� �˾� ����
        exitConfirmPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    void OnExitYesClicked()
    {
        // ���� ����
        Application.Quit();

        // �����Ϳ����� ���ᰡ �ȵǴ� �Ʒ� �α׷� Ȯ�� ����
        Debug.Log("���� ����");
    }

    void OnExitNoClicked()
    {
        // ���� Ȯ�� â �ݱ�
        exitConfirmPanel.SetActive(false);
    }
}
