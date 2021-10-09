using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;

    [SerializeField]
    private int howManyCircles = 50;

    [Header("Wave settings")]
    [Range(0, 5)]
    [SerializeField]
    float amplitude = 2;

    [SerializeField]
    [Range(0, 5)]
    float period = 2;

    [Range(0, 1)]
    [SerializeField]
    float pointSeparation = 0.1f;

    private List<GameObject> circles = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < howManyCircles; i++)
        {
            var circle = Instantiate(circlePrefab, transform);
            circles.Add(circle);
        }
    }

    void Update()
    {
        for (int i = 0; i < howManyCircles; i++)
        {
            var circle = circles[i];
            float x = pointSeparation * i;
            float y = amplitude * Mathf.Sin(2.0f * Mathf.PI * x / period + Time.time);
            circle.transform.localPosition = new Vector3(x, y);
        }
    }
}
