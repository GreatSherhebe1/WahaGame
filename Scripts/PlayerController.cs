using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] SpriteRenderer GorkSprite;
    public float SpeedX;
    public float JumpForce;
    private float input;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask Ground;
    private Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveX();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
        Jump();
    }

    void MoveX()
    {
        input = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(input * SpeedX, rigidBody.velocity.y);
        if (rigidBody.velocity.x != 0)
            GorkSprite.flipX = rigidBody.velocity.x > 0 ? false : true;
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rigidBody.velocity = Vector2.up * JumpForce;
    }
}
