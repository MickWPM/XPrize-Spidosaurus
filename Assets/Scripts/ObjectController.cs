using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private Transform headTransform;
    private InputAction moveAction, lookAction;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector2 lookValue = lookAction.ReadValue<Vector2>();

        transform.Rotate(transform.up, moveValue.x * Time.deltaTime * rotationSpeed); 
        transform.position += transform.forward * moveValue.y * Time.deltaTime * moveSpeed;

        headTransform.Rotate(headTransform.up, lookValue.x);
    }
}
