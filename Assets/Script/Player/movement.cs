using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintMultiplier = 1.4f; // The multiplier for sprint speed (40% faster)
    public Rigidbody2D rigidbody; // Use the 'new' keyword to hide the inherited member
    private Vector2 moveDirection;
    public Animator anim;

    private bool isSprinting = false; // Keep track of sprinting state
    private bool moving;

    public ParticleSystem dust;
    private Transform dustFollowPoint; // Transform to follow the player

    // Start is called before the first frame update
    void Start()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        dustFollowPoint = transform; // Set the dust follow point to the player's transform
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
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

        if (isSprinting)
        {
            currentMoveSpeed *= sprintMultiplier;
        }

        rigidbody.velocity = moveDirection * currentMoveSpeed;

        // Update the position of dust to follow the player
        dust.transform.position = dustFollowPoint.position;
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
