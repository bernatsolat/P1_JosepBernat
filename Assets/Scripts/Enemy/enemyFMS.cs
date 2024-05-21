using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFMS : MonoBehaviour
{
    public float speed;
    public GameObject player;
   
    public bool isRight = false;
    public bool CanMove = true; 

    private Vector3 initialScale;
    

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (CanMove)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
     
        Vector3 heading = player.transform.position - transform.position;

        
        if (heading.x < 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
        else
        {
            transform.localScale = initialScale;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
