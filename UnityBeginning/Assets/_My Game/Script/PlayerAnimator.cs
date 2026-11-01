using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private PlayerController playerController;
    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        animator.SetBool("IsWalking", playerController.IsWalking()); //Reference the IsWalking function in Player Controller
        //STRING IS CASE SENSITIVE DO NOT MISPELL IsWalking !!!!!!!! why Unity why
    }
}
