using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static PlayerAnimations instance;
    public static PlayerAnimations Instance
    {
        get { 
            if (instance == null)
                instance = FindAnyObjectByType<PlayerAnimations>();
            return instance;
        }
    }

    [SerializeField] private Animator PlayerAnimator;
   // [SerializeField] private Animator EnemyAnimator;
    private string idleName="PlayerIdle";
    private string jumpname = "PlayerJump";
    private string walkName = "PlayerWalk";
    private string shootName = "PlayerShoot";
    private string attackName = "PlayerAttack";
    private string dieName = "PlayerDie";
    private string currentState;

    /*
    private string EnemyWalk = "Walk";
    private string EnemyAttack = "Attack";
    private string EnemyIdle = "Idle";
    private string headstate;
    */

    
    public void ChangeAnimation(PlayerAnim newAnim)
    {

        switch (newAnim) {
            case PlayerAnim.Idle: 
                ChangeAnimationState(idleName); break;

            case PlayerAnim.Jump:
                ChangeAnimationState(jumpname); break;

            case PlayerAnim.Walk:
                ChangeAnimationState(walkName); break;

            case PlayerAnim.Shoot:
                ChangeAnimationState(shootName); break;

            case PlayerAnim.Attack:
                ChangeAnimationState(attackName); break;


            case PlayerAnim.Die:
                ChangeAnimationState(dieName); break;

            default: throw new System.Exception("error"); 
        }
    }
     
        private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        PlayerAnimator.Play(newState);
        currentState = newState;
    }
}
