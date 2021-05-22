using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float move;
    [SerializeField] public float moveSpeed = 2.5f;

    [SerializeField] private bool jumping;
    [SerializeField] private float jumpSpeed = 4.8f;

    [SerializeField] private float ghostJump;

    [SerializeField] private bool isGrounded;
    public Transform feetPosition;
    public Vector2 sizeCapsule;
    [SerializeField] private float angleCapsule = 120f;
    public LayerMask whatIsGround;

    public static bool blockInput = true;

    AudioSource audioSrc;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animationPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animationPlayer = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();

        sizeCapsule = new Vector2(0.317f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(feetPosition.position, sizeRadius, whatIsGround);

        isGrounded = Physics2D.OverlapCapsule(feetPosition.position, sizeCapsule, CapsuleDirection2D.Horizontal, angleCapsule, whatIsGround);

        Invoke("BlockInput", 12);

        if(blockInput == false)
        {
            move = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.W) && ghostJump > 0)
            {
                jumping = true;
                audioSrc.Play();
            }

            if (move < 0)
            {
                sprite.flipX = true;
            }
            else if (move > 0)
            {
                sprite.flipX = false;
            }

            if (isGrounded)
            {
                ghostJump = 0.05f;

                animationPlayer.SetBool("Jumping", false);
                animationPlayer.SetBool("Falling", false);

                if (move != 0)
                {
                    animationPlayer.SetBool("Walking", true);
                }
                else
                {
                    animationPlayer.SetBool("Walking", false);
                }
            }
            else
            {
                ghostJump -= Time.deltaTime;

                if (ghostJump <= 0)
                {
                    ghostJump = 0;
                }

                if (rb.velocity.x >= 0 || rb.velocity.x <= 0)
                {
                    animationPlayer.SetBool("Walking", false);

                    if (rb.velocity.y > 0)
                    {
                        animationPlayer.SetBool("Jumping", true);
                        animationPlayer.SetBool("Falling", false);
                    }
                    if (rb.velocity.y < 0)
                    {
                        animationPlayer.SetBool("Jumping", false);
                        animationPlayer.SetBool("Falling", true);
                    }
                }



            }
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(feetPosition.position, sizeCapsule);
    }

    void BlockInput()
    {
        blockInput = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (jumping)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            //rb.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);

            jumping = false;
        }
    }

    public void PlayerKilled()
    {
        animationPlayer.SetBool("Dead", true);
        blockInput = true;
        moveSpeed = 0;
        Invoke("DoAllAgain", 3);
    }

    public void DoAllAgain()
    {
        transform.position = FindObjectOfType<Checkpoint>().ReachedPoint;
        animationPlayer.SetBool("Dead", false);
        blockInput = false;
        moveSpeed = 3f;
        FindObjectOfType<EnemyFollow>().isMoving = true;
    }
}
