using UnityEngine;

public class PlayerPb : MonoBehaviour
{
    [SerializeField]
    private int Pb = 0;

    public int CurrentPb
    {
        set => Pb = Mathf.Max(0, value);
        get => Pb;
    }
}

