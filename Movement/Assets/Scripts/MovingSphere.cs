using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float maxSpeed = 10f;

    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        Vector3 velocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;
    }
}
