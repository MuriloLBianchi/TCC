using UnityEngine;
using UnityEngine.InputSystem; // Importa o novo sistema

public class CarController : MonoBehaviour
{
    private Vector2 moveInput;

    public float speed = 5f;
    public float turnSpeed = 100f;

    void Update()
    {
        if (Keyboard.current == null)
            return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal = -1f;
        if (Keyboard.current.dKey.isPressed)
            horizontal = 1f;
        if (Keyboard.current.wKey.isPressed)
            vertical = 1f;
        if (Keyboard.current.sKey.isPressed)
            vertical = -1f;

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
    }
}
