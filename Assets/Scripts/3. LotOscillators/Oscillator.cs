using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Header("X component")]
    [SerializeField]
    [Range(0, 5)]
    float periodX = 1; // The amount of time it takes for one complete cycle of motion

    [SerializeField]
    [Range(0, 5)]
    private float amplitudeX = 2; // The distance from the center of motion to either extreme

    [Header("Y component")]
    [SerializeField]
    [Range(0, 5)]
    float periodY = 1; // The amount of time it takes for one complete cycle of motion

    [SerializeField]
    [Range(0, 5)]
    private float amplitudeY = 2; // The distance from the center of motion to either extreme

    private void Start()
    {
        // Set initial values for x
        periodX = Random.Range(1, 5);
        amplitudeX = Random.Range(1, 5);

        // Set initial values for y
        periodY = Random.Range(1, 5);
        amplitudeY = Random.Range(1, 5);
    }

    void Update()
    {
        // Simple harmonic movement on x component
        float factorX = Time.time / periodX;
        float x = amplitudeX * Mathf.Sin(2 * Mathf.PI * factorX);

        // Simple harmonic movement on y component
        float factorY = Time.time / periodY;
        float y = amplitudeY * Mathf.Sin(2 * Mathf.PI * factorY);

        // Update the position
        transform.position = new Vector3(x, y, transform.position.z);
        transform.position.Draw(Color.yellow);
    }
}
