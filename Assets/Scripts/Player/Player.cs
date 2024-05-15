using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 2f;

    private Animator animator;
    

    private float xAxis;
    private float yAxis;
    private Rigidbody2D rb2d;
    private bool isJumpPressed;
    private float jumpForce = 150;
    private int groundMask;
    private bool isGrounded;
    private string currentAnimaton;
    private bool isAttackPressed;
    private bool isAttacking;
    private bool isDistanceAttackPressed;


    [SerializeField]
    private float attackDelay = 0.4f;

    //Animation States
   

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");


        // Crear un nuevo Material de Física 2D
        PhysicsMaterial2D noFrictionMaterial = new PhysicsMaterial2D();
        noFrictionMaterial.friction = 0;

        // Aplicar el Material de Física 2D al BoxCollider2D del objeto
        GetComponent<BoxCollider2D>().sharedMaterial = noFrictionMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        //Checking for inputs
        xAxis = Input.GetAxisRaw("Horizontal");
        //space jump key pressed?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
        //space Atatck key pressed?
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttackPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isDistanceAttackPressed = true;
        }
        
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        isAttackPressed = false;
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Attack);

         yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
    private void FixedUpdate()
    {
      
        //check if player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, groundMask);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //-
        //Check update movement based on input
        Vector2 vel = new Vector2(0, rb2d.velocity.y);
        if (xAxis < 0)
        {
            vel.x = -walkSpeed;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (xAxis > 0)
        {
            vel.x = walkSpeed;
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            vel.x = 0;

        }
        if (isAttackPressed && !isAttacking)
        { 
            StartCoroutine(Attack());
        }
        else if (isGrounded && !isAttacking)
        {
            if (xAxis != 0) PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Walk);

            else PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Idle);

        }
        //Check if trying to jump
        if (isJumpPressed && isGrounded)
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Jump);

        }
        //assign the new velocity to the rigidbody
        rb2d.velocity = vel;
        
        
        
        //attack
        /*

        if (isDistanceAttackPressed && !isAttacking)
        {
            isAttacking = true;
            isDistanceAttackPressed = false;

            //ChangeAnimationState(PLAYER_DATTACK);
        }
        if (isAttackPressed && !isAttacking)
        {
            StartCoroutine(Attack());
             isAttacking = true;
             isDistanceAttackPressed = false;
             ChangeAnimationState(PLAYER_ATTACK);
            
        }
        */





        }
    
  
}

