using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFMS : MonoBehaviour
{
    public float speed;

    public bool isRight;

    public float timer;
    public float timeToChange = 4f;

    public bool mustChase;
    public Transform objective;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToChange;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (isRight == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);

        }

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = timeToChange;
            isRight = !isRight;
        }

        if(mustChase == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, objective.position, speed * Time.deltaTime);

        }
    }
}
