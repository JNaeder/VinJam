using UnityEngine;
using FMODUnity;

public class MainGuy_Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpStrength = 1f;
    public float fallMult = 3f;

    public Transform groundCheck, leftCheck, rightCheck;
    public LayerMask checkLayer;
    public float wallCheckRadius = 1f;
    public Vector2 groundCheckSize;

    [FMODUnity.EventRef]
    public string jumpSound, collectableSound, unlockSound;

    Rigidbody2D rb;
    Animator anim;
    GameManager gm;

    float h;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        SetAnim();
        
    }

    void Movement()
    {
            h = Input.GetAxis("Horizontal");
            

        if (IsTouchingLeft())
        {
            h = Mathf.Clamp(h, 0, 1);
        }
        else if(isTouchingRight()) {
            h = Mathf.Clamp(h, -1, 0);
        }
            transform.position += new Vector3(h * speed * Time.deltaTime, 0, 0);


        if (h > 0)
        {
            GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(1, 1, 1);

        }
        else if (h < 0) {

            GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    void Jump() {

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMult * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMult * Time.deltaTime;
        }
    }

    public bool IsGrounded() {
        bool _isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f ,checkLayer);
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


    public void PlayCollectableSound() {
        if (gm.totalDiamonds == gm.diamondsInLevel)
        {
            FMODUnity.RuntimeManager.PlayOneShot(unlockSound);
            FMODUnity.RuntimeManager.PlayOneShot(collectableSound);
        }
        else
        {

            FMODUnity.RuntimeManager.PlayOneShot(collectableSound);
        }

    }

    public void SetAnim() {
        anim.SetFloat("h", Mathf.Abs(h));
        anim.SetBool("isGrounded", IsGrounded());

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize); 
        Gizmos.DrawWireSphere(leftCheck.position, wallCheckRadius);
        Gizmos.DrawWireSphere(rightCheck.position, wallCheckRadius);
    }

}
