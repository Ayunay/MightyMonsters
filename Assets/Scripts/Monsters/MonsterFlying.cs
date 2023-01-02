using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class MonsterFlying : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement")]
    private Vector2 targetPosition;
    private Vector2 direction;

    [SerializeField][Range(2f, 3f)] private float smoothing;
    private Vector2 value;

    #region UnityStuff

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Spawn();
        GetTargetPos();
    }

    private void Update()
    {
        Move();
    }

    #endregion

    private void GetTargetPos()
    {

    }

    private void Move()
    {
        direction = Vector2.SmoothDamp(transform.position, targetPosition, ref value, smoothing);
        transform.position = new Vector2(direction.x, direction.y);

        if (rb.velocity.x > smoothing || rb.velocity.y > smoothing)
            rb.velocity = new Vector2(smoothing, smoothing);
    }

    private void Spawn()
    {

    }

    private void Despawn()
    {
        
    }
}
