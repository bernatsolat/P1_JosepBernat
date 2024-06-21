using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerIn : MonoBehaviour
{
    private List<GameObject> cajas = new List<GameObject>();

    private void Start()
    {
        cajas.Add(GameObject.Find("crate-stack (8)"));
        cajas.Add(GameObject.Find("crate-stack (9)"));
        cajas.Add(GameObject.Find("crate-stack (10)"));
        cajas.Add(GameObject.Find("crate-stack (11)"));
        cajas.Add(GameObject.Find("crate-stack (12)"));
        cajas.Add(GameObject.Find("crate-stack (13)"));

        foreach (GameObject caja in cajas)
        {
            caja.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject caja in cajas)
            {
                caja.SetActive(true);
            }
        }
    }
}
