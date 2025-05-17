using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerInput : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput = Vector2.zero;
    [SerializeField] private Animator animator;
    public Interactable interactable = null;
    public bool canDestroy;
    [SerializeField] private GameObject leafMiniGame;
    public LevelLoader levelLoader;

    private void Start()
    {
        animator.SetBool("Idle", true);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
    }
    void Update()
    {
        Vector3 direction = new Vector3(moveInput.x, moveInput.y, 0f);

        transform.position += direction * Time.deltaTime * moveSpeed;

        RemoveObject();
        if (levelLoader != null)
        {
            LeafMinigame();
        }

        BaggyAnims();
        
    }

    private void BaggyAnims()
    {

        if (moveInput.y > 0.1f)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);

        }
        else if (moveInput.y < 0.1f)
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Idle", false);
        }
        else if (moveInput.y == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }

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
            canDestroy = true;
        }

    }
    private void LeafMinigame()
    {

        if (levelLoader.enteredLeafPile)
        {
            leafMiniGame.SetActive(true);
        }
    }

}
