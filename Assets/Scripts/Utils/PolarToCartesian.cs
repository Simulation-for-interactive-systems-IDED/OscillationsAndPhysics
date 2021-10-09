using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PolarToCartesian
{
    public static Vector2 FromPolarToCartesian(this Vector2 vector)
    {
        float radius = vector.x, theta = vector.y;
        return new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
    }

    public static Vector3 FromPolarToCartesian(this Vector3 vector)
    {
        float radius = vector.x, theta = vector.y;
        return new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0);
    }

    public static Vector4 FromPolarToCartesian(this Vector4 vector)
    {
        float radius = vector.x, theta = vector.y;
        return new Vector4(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0, 0);
    }
}
