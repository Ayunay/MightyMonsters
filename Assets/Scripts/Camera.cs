using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform character;

    [SerializeField][Range(0f, 1f)] private float smoothing;

    private Vector3 camVel;

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
