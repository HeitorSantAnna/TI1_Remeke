using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_;

    private Camera cam;

    private Vector2 Force;

    private float speed = 5;

    void Start()
    {
        rb_ = GetComponent<Rigidbody>();

        cam = Camera.main;
    }

    void Update()
    {
        rb_.AddForce((cam.transform.forward * Force.normalized.y * speed) + (cam.transform.right * Force.normalized.x * speed));
    }

    public void Move(InputAction.CallbackContext value)
    {
        Force = value.ReadValue<Vector2>();
    }
}
