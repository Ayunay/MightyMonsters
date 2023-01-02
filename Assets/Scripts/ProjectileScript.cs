using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float _deleteTimer;
    
    private GameObject _player;                                 //Projektil wird nicht zerstört wenn es den Spieler selbst trifft(beim spawn)
    private bool hit = false;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Hit();
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