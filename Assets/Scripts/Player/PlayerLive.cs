using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    private int PlayerHealth = 5;
    private HUD hud;

    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        UpdateHUD();
    }

    public void PlayerTakeDamage(int damage)
    {
        PlayerHealth -= damage;
        UpdateHUD();
        Invoke("AnimationTakeDamage", 0.8f);
    }

    private void UpdateHUD()
    {
        for (int i = 0; i < hud.vidas.Length; i++)
        {
            if (i < PlayerHealth)
            {
                hud.ActivarVida(i);
            }
            else
            {
                hud.DesactivarVida(i);
            }
        }
    }

    public void AnimationTakeDamage()
    {
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);

        if (PlayerHealth <= 0)
        {
            Invoke("Die", 0.8f);
        }
    }

    private void Die()
    {
        
        Destroy(gameObject);
    }
}
