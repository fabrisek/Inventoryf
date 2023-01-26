using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // vitesse de d�placement du joueur
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Input input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input = new Input();
        input.Game.Enable();
        input.Game.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // r�cup�ration de l'input de d�placements    
    }

    private void Update()
    {
        moveInput = moveInput.normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}