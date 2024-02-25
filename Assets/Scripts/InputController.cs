using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public FixedJoystick moveJoystick; // Assuming FixedJoystick is the type of your joystick
    public FixedJoystick rotateJoystick; // Add a reference to the rotation joystick
    public float speed = 5f;
    public float rotationSpeed = 180f; // Adjust the rotation speed according to your preference
    public Transform snakeTransform; // Assuming snakeTransform is the Transform of your snake prefab

    // Adjust these values for sensitivity
    public float movementSensitivity = 2f;
    public float rotationSensitivity = 2f;

    void Update()
    {
        MoveSnake();
        RotateSnake();
    }

    void MoveSnake()
    {
        float horizontalInput = moveJoystick.Horizontal * movementSensitivity;
        float verticalInput = moveJoystick.Vertical * movementSensitivity;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        snakeTransform.Translate(movement * speed * Time.deltaTime);
    }

    void RotateSnake()
    {
        float rotateInput = rotateJoystick.Horizontal * rotationSensitivity;

        // Adjust rotation based on the joystick input
        Vector3 rotation = new Vector3(0f, rotateInput, 0f);
        snakeTransform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
