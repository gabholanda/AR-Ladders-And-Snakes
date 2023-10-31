using UnityEngine;


public class Die : MonoBehaviour
{
    [SerializeField]
    private int faces;
    [SerializeField]
    private Animator animator;
    private int result;
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
        result = GetRandomNumber();
        animator.Play("Roll_" + result);
    }

    public void OnRollFinished()
    {
        Debug.Log("Walk player towards die result: " + result);
        Debug.Log("Ends turn and give it to another player");
    }
}
