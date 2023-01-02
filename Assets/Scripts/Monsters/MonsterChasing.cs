using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterChasing : MonoBehaviour
{
    private Rigidbody2D rb;

    private Transform character;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    private Vector2 targetDirection;
    private Vector2 direction;

    [SerializeField][Range(2f, 3f)] private float smoothing;
    private Vector2 value;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        //UpdatePositionRb();
        UpdatePositionTransf();
    }

    private void UpdatePositionRb()
    {
        targetDirection = character.position;

        direction.x = targetDirection.x - gameObject.transform.position.x;
        direction.y = targetDirection.y - gameObject.transform.position.y;
        
        if(Mathf.Abs(rb.velocity.x) > moveSpeed || Mathf.Abs(rb.velocity.y) > moveSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * moveSpeed, Mathf.Sign(rb.velocity.y) * moveSpeed);

        rb.AddForce(new Vector2(direction.x, direction.y) * moveSpeed * Time.deltaTime);
    }

    private void UpdatePositionTransf()
    {
        targetDirection = character.position;

        direction = Vector2.SmoothDamp(transform.position, targetDirection, ref value, smoothing);
        transform.position = new Vector2(direction.x, direction.y);

        if (rb.velocity.x > moveSpeed || rb.velocity.y > moveSpeed)
            rb.velocity = new Vector2(moveSpeed, moveSpeed);
    }
}
