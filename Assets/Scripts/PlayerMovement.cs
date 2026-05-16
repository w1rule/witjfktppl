using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite sideSprite;

    private PlayerControls controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        if (moveInput.x > 0)
        {
            sr.sprite = sideSprite;
            sr.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            sr.sprite = sideSprite;
            sr.flipX = true;
        }
        else if (moveInput.y > 0)
        {
            sr.sprite = backSprite;
        }
        else if (moveInput.y < 0)
        {
            sr.sprite = frontSprite;
        }
    }
}