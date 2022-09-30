using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private Rigidbody2D _rigidbody;
    private Vector2 movement = Vector2.zero;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = 0f;
        float horizontalInput = 0f;
        
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        movement = new Vector2(horizontalInput, verticalInput);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * (Time.fixedDeltaTime * _speed));
    }
}
