using UnityEngine;

public class PlayerPlanks : MonoBehaviour
{
    [SerializeField]
    private int Planks = 0;

    public int CurrentPlanks
    {
        set => Planks = Mathf.Max(0, value);
        get => Planks;
    }
}