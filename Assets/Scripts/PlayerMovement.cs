using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed;
    
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
    }

    private void Update()
    {
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("attacking", Horizontal != 0.0f);


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
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}