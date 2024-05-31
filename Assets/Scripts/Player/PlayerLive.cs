using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    public int Health = 5;
    private HUD hud;

    private void Start()
    {
        hud = FindObjectOfType<HUD>();
        UpdateHUD();
    }

    public void PlayerTakeDamage(int damage)
    {
        Health -= damage;
        UpdateHUD();
        Invoke("AnimationTakeDamage", 0.8f);
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

    public void AnimationTakeDamage()
    {
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);

        if (Health <= 0)
        {
            Invoke("Die", 0.8f);
        }
    }

    private void Die()
    {
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);
        Destroy(gameObject);
    }
}