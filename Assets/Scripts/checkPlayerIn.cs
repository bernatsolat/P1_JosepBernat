using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayerIn : MonoBehaviour
{
    private List<GameObject> cajas = new List<GameObject>();
    private GameObject finalBoss;
    private GameObject healthBoss;
    private void Start()
    {
        GameObject Pause = GameObject.Find("Pause");
        Transform healthBossTransform = Pause.transform.Find("HUD/BarraDeVida");
        healthBoss = healthBossTransform.gameObject;
        finalBoss = GameObject.Find("Jefe");
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
        finalBoss.SetActive(false);
        healthBoss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject caja in cajas)
            {
                caja.SetActive(true);
                finalBoss.SetActive(true);
                healthBoss.SetActive(true);

            }
        }
    }
}
