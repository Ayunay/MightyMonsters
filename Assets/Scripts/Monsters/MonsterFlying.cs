using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MonsterFlying : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform transf;

    private Transform characterPos;
    private Vector2 spawnPos;

    private float xMultiplier;
    private float yMultiplier;

    [Header("Movement")]
    private Vector2 targetPosition;
    private Vector2 direction;

    [SerializeField][Range(2f, 3f)] private float smoothing;
    private Vector2 value;

    #region UnityStuff

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transf = GetComponent<Transform>();

        characterPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        Spawn();
        targetPosition = new Vector2(spawnPos.x + 60 * xMultiplier , spawnPos.y + 40 * yMultiplier);
    }

    private void Update()
    {
        Move();
    }

    #endregion

    private void Move()
    {
        if (transf.position.x == targetPosition.x && transf.position.x == targetPosition.y)
        {
            targetPosition.x += 12 * xMultiplier;
            targetPosition.y += 8 * yMultiplier;
        }

        direction = Vector2.SmoothDamp(transf.position, targetPosition, ref value, smoothing);
        transf.position = new Vector2(direction.x, direction.y);
        
        if (rb.velocity.x > smoothing || rb.velocity.y > smoothing)
            rb.velocity = new Vector2(smoothing, smoothing);
    }

    private void Spawn()
    {
        int random = Random.Range(1, 5);  // random between 1-4 to choose corner (of camera)

        switch (random)
        {
            case 1:
                spawnPos = new Vector2(-22.5f, 15f);        // top left
                xMultiplier = 1;
                yMultiplier = -1;
                break;

            case 2:
                spawnPos = new Vector2(22.5f, 15f);         // top right
                xMultiplier = -1;
                yMultiplier = -1;
                break;

            case 3:
                spawnPos = new Vector2(22.5f, -15f);        // bottom right
                xMultiplier = -1;
                yMultiplier = 1;
                break;

            case 4:
                spawnPos = new Vector2(-22.5f, -15f);       // bottom left
                xMultiplier = 1;
                yMultiplier = 1;
                break;
        }

        transf.position = spawnPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Destroy when flying out of room
    {
        if (collision.gameObject.CompareTag("Wall"))
            Destroy(gameObject);
    }
}
