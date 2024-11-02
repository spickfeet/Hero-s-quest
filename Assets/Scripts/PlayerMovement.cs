using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
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
    }
}
