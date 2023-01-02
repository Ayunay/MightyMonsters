using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _cooldown;
    [SerializeField] private ProjectileSpawnScript projectileSpawn;
    [SerializeField] private Rigidbody2D _spawn;

    private Rigidbody2D _rb;
    private Vector2 _moveVal;
    private Vector2 _mousePosition;
    private Vector2 _aimDirection;
    private float _aimAngel;
    private bool _shootCooldown;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MouseDirection();
    }

    private void FixedUpdate()
    {
        Move();
        ShootDirection();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveVal = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_moveVal.x * _moveSpeed * Time.fixedDeltaTime, _moveVal.y * _moveSpeed * Time.fixedDeltaTime);
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && _shootCooldown == false)
        {
            projectileSpawn.Shoot();
            _shootCooldown = true;
            Invoke("runCooldown", _cooldown);
        }
    }

    private void MouseDirection()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void ShootDirection()
    {
        _aimDirection = _mousePosition - _spawn.position;
        _aimAngel = Mathf.Atan2(_aimDirection.y * Time.fixedDeltaTime, _aimDirection.x * Time.fixedDeltaTime) * Mathf.Rad2Deg;
        _spawn.rotation = _aimAngel;
    }

    private void runCooldown()
    {
        _shootCooldown = false;
    }
}