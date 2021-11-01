using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField]
    private float gravity;

    private float radius = 0;
    private float angularAcceleration = 0;
    private float angularVelocity = 0;
    private float angularPosition = 0;

    private bool isGrabbing = false;

    private void Start()
    {
        radius = transform.position.magnitude;
        angularPosition = Mathf.Atan2(transform.position.y, transform.position.x);
    }

    private void Update()
    {
        // If doing grabbing stuff... then disable "physics"
        if (HandleUserGrab()) return;

        // Calculate angular accel, vel and pos
        float restAngle = 3f / 2f * Mathf.PI;
        float theta = restAngle - Mathf.Atan2(transform.position.y, transform.position.x);
        angularAcceleration = gravity * Mathf.Sin(theta) / radius;
        angularVelocity += angularAcceleration * Time.deltaTime;
        angularPosition += angularVelocity * Time.deltaTime;

        // Polar to cartesian and update position
        Vector2 polarCoord = new Vector2(radius, angularPosition);
        transform.position = polarCoord.FromPolarToCartesian();

        // Apply some friction
        angularVelocity *= 0.995f;
    }

    private bool HandleUserGrab() // True if doing some grabbing stuff
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = GetWorldMousePosition(); mousePos.z = 0;
            if ((transform.position - mousePos).magnitude <= transform.localScale.x) // Assuming the sprite is a circle of radius 1
            {
                isGrabbing = true;
                transform.position = mousePos;
                return true;
            }
        }
        else if (isGrabbing && Input.GetMouseButton(0))
        {
            Vector3 mousePos = GetWorldMousePosition(); mousePos.z = 0;
            transform.position = mousePos;
            return true;
        }
        else if (isGrabbing && Input.GetMouseButtonUp(0))
        {
            radius = transform.position.magnitude;
            angularPosition = Mathf.Atan2(transform.position.y, transform.position.x);
            isGrabbing = false;
        }

        return false;
    }

    private Vector3 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
}
