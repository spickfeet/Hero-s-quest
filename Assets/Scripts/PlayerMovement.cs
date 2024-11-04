using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    private Animator _animator;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 nextPos = new Vector2();
        nextPos.x = Input.GetAxis("Horizontal");
        nextPos.y = Input.GetAxis("Vertical");
        nextPos *= _speed;
        _rb.velocity = nextPos;
        if (nextPos.magnitude != 0)
        {
            if (_player.Container != null)
            {
                _animator.Play("PlayerRunAndGrab");
            }
            else
            {
                _animator.Play("PlayerRun");
            }
            return;
        }
        if (_player.Container != null)
        {
            _animator.Play("PlayerIdleAndGrab");
        }
        else
        {
            _animator.Play("PlayerIdle");
        }
    }
}
