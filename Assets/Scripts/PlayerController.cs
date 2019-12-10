using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed; //determines speed of player
    public float speedMultipler;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public float jumpForce; //determines the jump height for player
    public float airTime;
    private float jumpCounter;
    private bool grounded; //determines if the character is on the ground
    public LayerMask isGround; //determines if the game object the character is on, is the ground
    //private Collider2D myCollider; //for collision detection
    private Rigidbody2D myRigidbody; //physics(gravity)
    private Animator myAnimator; //Animation for running and jumping
    public Transform groundFinder;
    public float groundCheckRadius;
    public GameManagement theGameManager;
    private float runSpeedStorage;
    private float speedMilestoneCountStorage;
    private float speedIncreaseMilestoneStorage;
    //
    public Pause pauseMenu;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    private bool doubleJump;
    //

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        jumpCounter = airTime;
        speedMilestoneCount = speedIncreaseMilestone;
        runSpeedStorage = runSpeed;
        speedMilestoneCountStorage = speedMilestoneCount;
        speedIncreaseMilestoneStorage = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundFinder.position, groundCheckRadius, isGround);        

        myRigidbody.velocity = new Vector2(runSpeed, myRigidbody.velocity.y);

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultipler;

            runSpeed = runSpeed * speedMultipler;
        }
        
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpSound.Play();
            }
            if(!grounded && doubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpCounter = airTime;
                doubleJump = false;
                jumpSound.Play();
            }
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(jumpCounter > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            jumpCounter = 0;
        }
        if (grounded)
        {
            jumpCounter = airTime;
            doubleJump = true;
            
        }
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("isJumping", grounded);
        myAnimator.SetBool("isDoubleJumping", doubleJump);
        // Pause Game
        if (Input.GetKey(KeyCode.Space))
        {
            pauseMenu.PauseGame();
        }
        //
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            
            theGameManager.RestartGame();
            runSpeed = runSpeedStorage;
            speedMilestoneCount = speedMilestoneCountStorage;
            speedIncreaseMilestone = speedIncreaseMilestoneStorage;
            deathSound.Play();
            
        }
    }
}
