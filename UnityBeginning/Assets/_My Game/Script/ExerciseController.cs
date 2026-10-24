using UnityEngine;
using System.Linq;

public class ExerciseController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private int clampWall = 3;
    private void Update()
    {
        Vector2 movementVector = GetWASDInput();// Gold standard for WASD input
        movementVector = movementVector.normalized;
        Vector3 moveDir = new Vector3(movementVector.x, 0f, movementVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        if(moveDir != Vector3.zero) //Only rotate when movedir is not zero
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime*rotationSpeed);
        }
        //Sprinting mechanic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            float currentSpeed = moveSpeed * 2; //because supplanting moveSpeed *2 to the equation directly would stack it with the earlier transform.position
            transform.position += moveDir * currentSpeed * Time.deltaTime;
        }
        //Arena boundary, using Clamp.
        //clamp each x,y,z
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampWall, clampWall),transform.position.y, Mathf.Clamp(transform.position.z, -clampWall, clampWall));
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
