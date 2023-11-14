using UnityEngine;


public class Die : MonoBehaviour
{
    [SerializeField]
    private int faces;
    [SerializeField]
    private Animator animator;
    public int result;
    public int cachedLastResult = 1;
    public GameBoard board;

    public bool isRolling = false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public int GetRandomNumber()
    {
        return Random.Range(1, faces + 1);
    }

    public void Roll()
    {
        isRolling = true;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        result = GetRandomNumber();
        animator.Play("Roll_" + result);
        if (cachedLastResult == result)
        {
            OnRollFinished();
        }
    }

    public void OnRollFinished()
    {
        isRolling = false;
        cachedLastResult = result;
        board.TriggerPlayerMovement();
    }
}
