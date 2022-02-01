using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Variables")]
    public float jumpForce = 10f;
    public float doubleJumpForce = 10f;
    public float groundCheckRadius;

    [HideInInspector] public bool isRunning = false;
    [HideInInspector] public bool gameOver = false;

    [Header("Unity stuff")]
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    private bool isGrounded;
    private bool isDoubleJumpUsed = false;

    private Rigidbody rb;
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        CheckInput();
        CheckGround();
        UpdateAnimation();
    }
    private void CheckInput()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded && !gameOver)
        {
            Jump();
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && !isGrounded && !isDoubleJumpUsed && !gameOver)
        {
            DoubleJump();
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.D))
        {
            Run();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.D))
        {
            ResetSpeed();
        }
    }
    private void Run()
    {
        animator.SetFloat("runMultiplier", 2f);
        isRunning = true;
    }
    private void ResetSpeed()
    {
        animator.SetFloat("runMultiplier", 1f);
        isRunning = false;
    }
    private void Jump()
    {
        rb.velocity = Vector3.up * jumpForce;
        animator.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        audioSource.PlayOneShot(jumpSound, 1f);
        isDoubleJumpUsed = false;
    }
    private void DoubleJump()
    {
        rb.velocity = Vector3.up * doubleJumpForce;
        animator.Play("Running_Jump", 3, 0f);
        dirtParticle.Stop();
        audioSource.PlayOneShot(jumpSound, 1f);
        isDoubleJumpUsed = true;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSound, 1f);
        }
    }
    private void UpdateAnimation()
    {
        animator.SetBool("Death_b", gameOver);
        animator.SetInteger("DeathType_int", 1);
    }
    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);
        
        if (!isGrounded && !gameOver)
        {
            dirtParticle.Play();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
