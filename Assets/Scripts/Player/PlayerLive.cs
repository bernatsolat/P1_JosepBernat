using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{
    
    
    public int Health = 5;

    public void TakeDamage(int damage)
    {
        PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);
        Health -= damage;
        if (Health <= 0)
        {

            PlayerAnimations.Instance.ChangeAnimation(PlayerAnim.Die);
            Invoke("Die", 0.8f);

        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
