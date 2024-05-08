using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSEnemy : MonoBehaviour
{
    public int routine;
    public float timer;
    public Animator animator;
    public int direction;
    public float speed;
    public float speedSprint;
    public GameObject target;
    public bool atacking;



        // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent <Animator>();
        target = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }

    public void Behavior()
    {
        animator.SetBool("run",false);
        timer += 1 * Time.deltaTime;
        if(timer >= 4)
        {
            routine = Random.Range(0, 2);
            timer = 0;
        }

        switch (routine)
        {
            case 0:
                animator.SetBool("walk", false);
                break;

            case 1:
                direction = Random.Range(0, 2);
                break;

            case 2:
                switch (direction)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                        break;

                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector2.right * speed * Time.deltaTime);
                        break;
    
                }
                animator.SetBool("walk", true);
                break;
        }
    }
}
