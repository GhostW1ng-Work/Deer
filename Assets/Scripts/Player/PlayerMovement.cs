using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;

    private bool _isLeft = true;

    private float _horizontalMove;
    private Rigidbody2D _rigidBody2D;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));
        _rigidBody2D.velocity = new Vector2(_horizontalMove, _rigidBody2D.velocity.y);

        if(_horizontalMove > 0 && _isLeft)
        {
            Flip();
        }

        else if(_horizontalMove < 0 && !_isLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isLeft = !_isLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
