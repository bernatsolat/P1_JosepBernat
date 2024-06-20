using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    AudioManager audioManager;
    public int Health = 5;
    private HUD hud;

    [SerializeField]
    private GameObject deadMenu;

    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        UpdateHUD();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    public void PlayerTakeDamage(int damage)
    {
        audioManager.PlaySFX(audioManager.playerDamaged);
        Health -= damage;
        UpdateHUD();
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);
        Invoke("HasTodie", 0.6f);
    }

    private void UpdateHUD()
    {
        for (int i = 0; i < hud.vidas.Length; i++)
        {
            if (i < Health)
            {
                hud.ActivarVida(i);
            }
            else
            {
                hud.DesactivarVida(i);
            }
        }
    }
    
    public void HasTodie()
    {
        if (Health <= 0)
        {
        Camera.main.GetComponent<CameraScript>().enabled = false;
        Destroy(gameObject);
        Time.timeScale = 0;
        deadMenu.SetActive(true);
        
        }
    }

    
}