using UnityEngine;
using System.Linq;

public class ExerciseController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    private bool isDashing = false;
    private Vector3 dashDirection = new Vector3(0,0,0);
    [SerializeField] private float dashSpeed = 30;
    [SerializeField]private float dashTimeRemaining = 3.5f;
    [SerializeField] private float dashCooldown = 1.5f;
    private void Update()
    {
        Vector2 movementVector = GetWASDInput();// Gold standard for WASD input
        movementVector = movementVector.normalized;
        Vector3 moveDir = new Vector3(movementVector.x, 0f, movementVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //Cooldown countdown
        dashCooldown = Mathf.Clamp(dashCooldown - 1, 0, 9999);


        //Sprinting mechanic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float currentSpeed = moveSpeed * 2; //because supplanting moveSpeed *2 to the equation directly would stack it with the earlier transform.position
            transform.position += moveDir * currentSpeed * Time.deltaTime;
        }
        //Dash mechanic
        if(Input.GetKeyDown(KeyCode.Mouse1) && isDashing == false && moveDir != Vector3.zero) //GetKeyDown only check 1 click, and mouse1 is right click
        {//Check if Dash key is pressed AND not Dashing AND the player isn't staying at the same place (moveDir != 0)
            dashDirection = moveDir;
            isDashing = true;
            dashTimeRemaining = 3.5f; //Reset dashTimeRemaining so it won't be stuck in 0
            dashCooldown = 1.5f;
        }
        if(isDashing)
        {
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            dashTimeRemaining = Mathf.Clamp(dashTimeRemaining - 10 * Time.deltaTime, 0, 9999);

            Debug.Log(dashTimeRemaining);
            if (dashTimeRemaining == 0)
            {
                isDashing = false;

            }
        }
        if (dashCooldown == 0)
        {
            isDashing = true;
        }


        //# TODO: Finish the Dash mechanic. Push to Github




    }
    private Vector2 GetWASDInput() //the RETURN method. Gold Standard
    {
        Vector2 tempVect = new Vector2(0, 0); //Temporary
        if (Input.GetKey(KeyCode.W))
        {
            tempVect.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tempVect.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tempVect.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tempVect.x = +1;
        }
        return tempVect; //!important
    }
}
