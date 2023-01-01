using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float _projectileForce;
    [SerializeField] private float _deleteTimer;
    [SerializeField] private GameObject _projectileSpawn;

    private GameObject _player;

    private Rigidbody2D _rb;
    private bool hit = false;


    private void Start()
    {
        SpawnPosition();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _projectileSpawn = GameObject.FindGameObjectWithTag("ProjectileSpawn");
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Hit();
    }

    private void SpawnPosition()
    {
        if (_projectileSpawn.transform.position.x <= transform.position.x)
        {
            _rb.AddForce(Vector2.right * _projectileForce, ForceMode2D.Impulse);
        }
        else if (_projectileSpawn.transform.position.x >= transform.position.x)
        {
            _rb.AddForce(Vector2.left * _projectileForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
    }

    private void Hit()
    {
        if (hit == true && !_player)
        {
            DeleteProjectile();
        }
        else
        {
            Invoke("DeleteProjectile", _deleteTimer);
        }
    }

    private void DeleteProjectile()
    {
        Destroy(gameObject);
    }
}