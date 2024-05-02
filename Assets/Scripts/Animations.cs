using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animations : MonoBehaviour
     
{
    public static Animations Instance; // Singleton

    private Animator animator;
    private string currentState;


    //Animation States

    const string PLAYER_IDE="Player_ide";
    const string PLAYER_ATTACK = "Player_attack";
    const string PLAYER_RUN = "Player_run";
    const string PLAYER_JUMP = "Player_jump";

    void Awake()
    {
        Instance = this;
    }


    void Start()
    {       
        animator = GetComponent<Animator>();
    }


    public void ChangeAnimationState(string newState)
    {
        // stop the same animation from interrupting itself
        if (currentState == newState) return;
        //play the animation
        animator.Play(newState);
        //reassign the current state
        currentState = newState;
    }
}
