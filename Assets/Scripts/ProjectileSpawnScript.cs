using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _projectiles;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _projectileForce;

    public void Shoot()
    {
        GameObject projectile = Instantiate(_projectiles, _firePoint.position, _firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * _projectileForce, ForceMode2D.Impulse);
    }
}
