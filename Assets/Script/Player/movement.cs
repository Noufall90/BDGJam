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

    private float sprintTime = 10f; // Time duration for sprint in seconds
    private float sprintCooldown = 5f; // Cooldown duration after sprint in seconds
    private float currentSprintTime = 0f; // Timer for sprint duration
    private float currentCooldown = 0f; // Timer for sprint cooldown

    void Start()
    {
        if (rigidbody == null)
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        dustFollowPoint = transform; // Set the dust follow point to the player's transform
    }
    
    void Update()
    {
        ProcessInput();
        Animate();
        UpdateTimers();
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

        if (Input.GetKey(KeyCode.LeftShift) && currentCooldown <= 0f)
        {
            isSprinting = true;
            CreateDust();

            currentSprintTime += Time.deltaTime;
            if (currentSprintTime >= sprintTime)
            {
                currentSprintTime = 0f;
                isSprinting = false;
                currentCooldown = sprintCooldown;
            }
        }
        else
        {
            isSprinting = false;

            if (currentCooldown > 0f)
            {
                currentCooldown -= Time.deltaTime;
            }
        }
    }

    void UpdateTimers()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
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

    var main = dust.main;
    main.simulationSpeed = currentMoveSpeed / moveSpeed; // Adjust particle speed based on player's movement

    dust.transform.position = transform.position;
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
