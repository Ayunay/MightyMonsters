using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawner;
    [SerializeField] private GameObject projectiles;
    [SerializeField] private float cooldown;

    private bool shootCooldown;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed && shootCooldown == false)
        {
            Shoot();
            shootCooldown = true;
            Invoke("runCooldown", cooldown);
        }
    }

    private void Shoot()
    {
        Instantiate(projectiles, projectileSpawner.position, projectileSpawner.rotation);
    }

    private void runCooldown()
    {
        shootCooldown = false;
    }
}
