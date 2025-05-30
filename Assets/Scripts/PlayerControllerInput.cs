using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerInput : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput = Vector2.zero;
    [SerializeField] private Animator animator;
    public Interactable interactable = null;
    public bool canDestroy;
    public GameObject leafMiniGame;
    public LevelLoader levelLoader;
    public SpriteRenderer spriteRenderer;
    public Death death;
    public int eggCounter;

    private void Start()
    {
        eggCounter = 0;
        animator.SetBool("Idle", true);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Horizontal", false);
        death = FindAnyObjectByType<Death>();
    }
    void Update()
    {
        //if (death.isDead) 
        //{
         //   return;
        //} 

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
        if (moveInput.x > 0.1f) 
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Horizontal", true);

            spriteRenderer.flipX = true;
        }

        else if (moveInput.x < -0.1f) 
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Horizontal", true);

            spriteRenderer.flipX = false;
        }

        else if (moveInput.y > 0.1f)
        {
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Horizontal", false);

        }
        else if (moveInput.y < -0.1f)
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Horizontal", false);
        }
        else if (moveInput.y == 0 && moveInput.x == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Horizontal", false);
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
            gameObject.SetActive(false);
            eggCounter++;
        }
    }

}
