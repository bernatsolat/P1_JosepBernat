using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask WhatIsGround;
    
    [SerializeField]
    private Transform GroundCheckPoint;

    [SerializeField]
    private float checkRadius = 0.15f;
    private bool _wasGrounded;

    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded { get { return _isGrounded; } }

    void FixedUpdate()
    {
        CheckGrounded();
    }
   
    private void CheckGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheckPoint.position, checkRadius, WhatIsGround);
        _isGrounded = (colliders.Length > 0);

        if (!_wasGrounded && _isGrounded) SendMessage("OnLanding");
        _wasGrounded = _isGrounded;
    }
}
