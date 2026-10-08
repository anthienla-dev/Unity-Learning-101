using UnityEngine;

public class ExerciseController : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;
    private void Update()
    {
        Vector2 movementVector = GetWASDInput();// Gold standard for WASD input
        movementVector = movementVector.normalized;
        Vector3 moveDir = new Vector3(movementVector.x, 0f, movementVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        //Sprinting mechanic
        if(Input.GetKey(KeyCode.LeftControl))
        {
            int currentSpeed = moveSpeed;
            transform.position += moveDir * moveSpeed * 2 * Time.deltaTime;
        }



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
        return tempVect;
    }
}
