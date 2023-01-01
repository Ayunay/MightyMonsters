using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveVal;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveVal = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveVal.x * moveSpeed * Time.fixedDeltaTime, _moveVal.y * moveSpeed * Time.fixedDeltaTime);
    }
}