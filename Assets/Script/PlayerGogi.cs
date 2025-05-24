using UnityEngine;

public class PlayerGogi : MonoBehaviour
{
    [SerializeField]
    private int Gogi = 0;

    public int CurrentGogi
    {
        set => Gogi = Mathf.Max(0, value);
        get => Gogi;
    }
}

