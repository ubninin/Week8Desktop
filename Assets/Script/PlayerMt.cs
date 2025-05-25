using UnityEngine;

public class PlayerMt : MonoBehaviour
{
    [SerializeField]
    private int Mt = 0;

    public int CurrentMt
    {
        set => Mt = Mathf.Max(0, value);
        get => Mt;
    }
}

