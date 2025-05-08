using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerInput : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput = Vector2.zero;
    public Interactable interactable;
    void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, moveInput.y, 0f);

        transform.position += direction * Time.deltaTime * moveSpeed;

        RemoveObject();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void RemoveObject()
    {
        if (interactable == null)
        {
            return;
        }

        else if (interactable.isInRange && Input.GetKeyDown(KeyCode.E)) 
        {
            Destroy(interactable.gameObject);
        }

    }

}
