using UnityEngine;

public class ExerciseAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private ExerciseController controller; 
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        animator.SetBool("IsMoving", controller.IsMoving());
    }
}
