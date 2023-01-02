using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform camera;
    private Transform character;

    [SerializeField][Range(0f, 1f)] private float smoothing;

    private Vector3 camVel;

    private void Awake()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.SmoothDamp(camera.position, character.position, ref camVel, smoothing);
        camera.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
}
