using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5, rotationSpeed = 2;
    void Update()
    {
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float CamX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float CamY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        transform.Translate(x, 0, z);
        transform.Rotate(CamY, CamX, 0);
    }
}
