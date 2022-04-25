using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private Rigidbody2D RigidBody;
    [SerializeField] SpriteRenderer GorkSprite;
    [SerializeField] float SpeedX;
    [SerializeField] float SpeedY;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space) && RigidBody.velocity.y < 0)
            Jump();
        MoveHorizontal();
    }

    void MoveHorizontal()
    {
        Vector3 vector = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += vector * SpeedX;
        if (vector.x != 0)
            GorkSprite.flipX = vector.x > 0 ? false : true;
    }

    void Jump()
    {
        RigidBody.AddForce(transform.up * SpeedY, ForceMode2D.Impulse);
    }
}
