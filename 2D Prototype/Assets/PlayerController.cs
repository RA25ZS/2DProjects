using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    bool isOnGround;
    PolygonCollider2D playerCollider;
    Animator animator;
    bool isFacingRight = true;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {
    }


    void Update()
    {
        Run();

        if (Input.GetKeyDown(KeyCode.Space) && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb2D.velocity = Vector2.up * jumpSpeed;
        }
    }

    public void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(horizontal, 0) * Time.deltaTime * movementSpeed);
        
        bool playerHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("IsRunning", playerHorizontalSpeed);

        FlipSprite(horizontal);
    }

    void FlipSprite(float horizontal)
    {
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector3 scale = transform.localScale;

            scale.x *= -1;

            transform.localScale = scale;
        }
    }

}
