using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed;
    public float SprintSpeed;
    public GameObject BulletPrefab;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float LastShoot;
    private int Health = 5;
    

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        PhysicsMaterial2D noFrictionMaterial = new PhysicsMaterial2D();
        noFrictionMaterial.friction = 0;

        // Aplicar el Material de Física 2D al BoxCollider2D del objeto
        GetComponent<BoxCollider2D>().sharedMaterial = noFrictionMaterial;
    }

    private void Update()
    {
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);


        
        

        Animator.SetFloat("Speed", Mathf.Abs(Horizontal));
        

        // Detectar Suelo
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);


        // Disparar
        /*if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }*/
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rigidbody2D.velocity = new Vector4(Horizontal * SprintSpeed, Rigidbody2D.velocity.y);
        }
        else { Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); }
    }

    
    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}