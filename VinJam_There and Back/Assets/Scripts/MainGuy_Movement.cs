using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGuy_Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpStrength = 1f;
    public float fallMult = 3f;

    public Transform groundCheck, leftCheck, rightCheck;
    public LayerMask checkLayer;
    public float wallCheckRadius = 1f;
    public Vector2 groundCheckSize;

    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
            float h = Input.GetAxis("Horizontal");

        if (IsTouchingLeft())
        {
            h = Mathf.Clamp(h, 0, 1);
        }
        else if(isTouchingRight()) {
            h = Mathf.Clamp(h, -1, 0);
        }
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);
    }


    void Jump() {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMult * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMult * Time.deltaTime;
        }
    }

    bool IsGrounded() {
        bool _isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, checkLayer);
        return _isGrounded;
    }
    bool IsTouchingLeft() {
        bool _isTouchingLeft = Physics2D.OverlapCircle(leftCheck.position, wallCheckRadius, checkLayer);
        return _isTouchingLeft;

    }
    bool isTouchingRight()
    {
        bool _isTouchingRight = Physics2D.OverlapCircle(rightCheck.position, wallCheckRadius, checkLayer);
        return _isTouchingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize); 
        Gizmos.DrawWireSphere(leftCheck.position, wallCheckRadius);
        Gizmos.DrawWireSphere(rightCheck.position, wallCheckRadius);
    }

}
