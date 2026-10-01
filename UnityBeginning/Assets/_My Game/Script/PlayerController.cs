using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Update()
    {

        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("W is being pressed");
        }
    }
}
