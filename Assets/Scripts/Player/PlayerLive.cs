using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLive : MonoBehaviour
{


    public int Health = 5;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Invoke("AnimationTakeDamage", 0.8f);
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
