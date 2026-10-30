using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    [SerializeField] private ExerciseController PlayerPosition; //ANYTHING can be a data type including ExerciseController MonoBehaviour class
    //OOP Shitfuckery
    [SerializeField] private Vector3 offset = new Vector3(0, 20, 0); //This is calling a var. Don't think it's a method because it has access modifier
    private void Update()
    {
        //Vector3 cameraOffset = new Vector3(0, 10, 0);
        transform.position = PlayerPosition.transform.position + offset;
        //This set of Offset
    }
}
