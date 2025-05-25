using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private TextMeshProUGUI endingText;

    private bool isGameCleared = false;

    void Update()
    {
        int count = 0;

     
        if (InventorySlot.PbCount > 0) count++;
        if (InventorySlot.BatteryCount > 0) count++;
        if (InventorySlot.TapeCount > 0) count++;
        if (InventorySlot.MtCount > 0) count++;
        if (InventorySlot.PlanksCount > 0) count++;


        float progress = (1 + count) / 6f;  // 시작 단계 포함 (1은 항상 채운 걸로)
        progressSlider.value = progress;

        progressText.text = $"{count+1} / 6 collected";

        if (!isGameCleared && count == 5)
        {
            isGameCleared = true;
            endingText.gameObject.SetActive(true);
        }
    }

}
