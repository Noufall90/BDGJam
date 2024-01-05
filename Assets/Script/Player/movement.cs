using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier = 1.4f; // The multiplier for sprint speed (40% faster)
    new public Rigidbody2D rigidbody; // Use the 'new' keyword to hide the inherited member
    private Vector2 moveDirection;
    public Animator anim;

    private bool isSprinting = false; // Keep track of sprinting state
    private bool moving;

    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component from the GameObject if not assigned
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Allow sprinting when the player holds Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;

            // Call CreateDust() to create dust particles when Shift is pressed
            CreateDust();
        }
        else
        {
            isSprinting = false;
        }
    }

    void Move()
    {
        float currentMoveSpeed = moveSpeed;

        // Apply sprinting multiplier if sprinting is allowed
        if (isSprinting)
        {
            currentMoveSpeed *= sprintMultiplier;
        }

        rigidbody.velocity = moveDirection * currentMoveSpeed;
    }

    void CreateDust()
    {
        dust.Play();
    }

    private void Animate()
    {
        float x = moveDirection.x;
        float y = moveDirection.y;

        if (moveDirection.magnitude > 0.1f || moveDirection.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }
}
