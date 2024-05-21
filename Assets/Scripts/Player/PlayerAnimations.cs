using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private static PlayerAnimations instance;
    public static PlayerAnimations Instance
    {
        get
        {
            if (instance == null)
                instance = FindAnyObjectByType<PlayerAnimations>();
            return instance;
        }
    }

    [SerializeField] private Animator PlayerAnimator;
    private string idleName = "PlayerIdle";
    private string jumpName = "PlayerJump";
    private string walkName = "PlayerWalk";
    private string attackName = "PlayerAttack";
    private string dieName = "PlayerDie";
    private string currentState;

    public void ChangeAnimation(PlayerAnim newAnim)
    {
        string newState = GetAnimationName(newAnim);
        if (currentState == newState) return;

        PlayerAnimator.Play(newState);
        currentState = newState;
    }

    private string GetAnimationName(PlayerAnim anim)
    {
        switch (anim)
        {
            case PlayerAnim.Idle: return idleName;
            case PlayerAnim.Jump: return jumpName;
            case PlayerAnim.Walk: return walkName;
            case PlayerAnim.Attack: return attackName;
            case PlayerAnim.Die: return dieName;
            default: throw new System.Exception("Unknown animation");
        }
    }
}
