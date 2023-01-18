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
    [SerializeField] private Transform _projectileSpawn;

    private Rigidbody2D _rb;
    private Vector2 _moveVal;
    private Vector2 _mousePosition;
    private Vector2 _aimDirection;
    private float _aimAngle;
    private bool _shootCooldown;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MouseDirection();
        ShootDirection();
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
        _aimDirection = _mousePosition - new Vector2(_projectileSpawn.position.x,_projectileSpawn.position.y);
        _aimAngle = Mathf.Atan2(_aimDirection.y , _aimDirection.x ) * Mathf.Rad2Deg;
        Quaternion currentRotation = _projectileSpawn.rotation;
        currentRotation.eulerAngles = new Vector3(0, 0, _aimAngle);
        _projectileSpawn.rotation = currentRotation;
    }

    private void runCooldown()
    {
        _shootCooldown = false;
    }
}