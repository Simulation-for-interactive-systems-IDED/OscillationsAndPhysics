using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleHarmonicMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 10)]
    float period = 1; // The amount of time it takes for one complete cycle of motion

    [SerializeField]
    [Range(0, 10)]
    private float amplitude = 2; // The distance from the center of motion to either extreme

    void Update()
    {
        // Simple harmonic movement on x component
        float factor = Time.time / period;
        float x = amplitude * Mathf.Sin(2 * Mathf.PI * factor);
        
        // Update the position
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        transform.position.Draw(Color.yellow);
    }
}
