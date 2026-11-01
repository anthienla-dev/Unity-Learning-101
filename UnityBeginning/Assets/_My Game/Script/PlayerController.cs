using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    private bool isWalking;
    private void Update()
    {
        Vector2 movementVector = new Vector2(0, 0); //Create a vector and set it at origin

        if(Input.GetKey(KeyCode.W))
        {
            movementVector.y =+1; //movementVect.y = movementVect.y + 1
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementVector.y =-1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementVector.x =-1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementVector.x =+1;
        }
        //this code checks if pressind WASD changes the Vector coord => capsule WONT MOVE!!!!!!!@!!!(@!u()!@##@!)(@#!
        movementVector = movementVector.normalized;
        Vector3 moveDir = new Vector3(movementVector.x, 0f, movementVector.y);
        transform.position += moveDir * Time.deltaTime * moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed); //Easiest rotation

        isWalking = moveDir != Vector3.zero; //If the movement is not 0 then we are walking
    }
    public bool IsWalking()
    {
        return isWalking; //This is for the Animator component to use. Called Getter method
    }
}
