﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Variables")]
    public float jumpForce = 10f;
    public float groundCheckRadius;

    [HideInInspector] public bool gameOver = false;

    [Header("Unity stuff")]
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    private bool isGrounded;

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
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        audioSource.PlayOneShot(jumpSound, 1f);
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