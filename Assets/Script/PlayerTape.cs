using UnityEngine;

public class PlayerTape : MonoBehaviour
{
    [SerializeField]
    private int Tape = 0;

    public int CurrentTape
    {
        set => Tape = Mathf.Max(0, value);
        get => Tape;
    }
}

