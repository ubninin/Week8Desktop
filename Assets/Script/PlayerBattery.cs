using UnityEngine;

public class PlayerBattery : MonoBehaviour
{
    [SerializeField]
    private int Battery = 0;

    public int CurrentBattery
    {
        set => Battery = Mathf.Max(0, value);
        get => Battery;
    }
}

