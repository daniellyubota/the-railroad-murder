using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;
using UnityEngine;

public class ShakeIn2D : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    public Transform targetTransform = null;

    [Range(0.01f, 50f)]
    public float speed = 20f;

    [Range(0.01f, 10f)]
    public float maxMagnitude = 0.3f;

    [Range(0f, 3f)]
    public float noiseMagnitude = 0.3f;

    public Vector2 direction = Vector2.up;

    float fadeOut = 1f;


    void Reset()
    {
        target = transform;
    }
    void OnValidate()
    {
        direction.Normalize();
    }


    void LateUpdate()
    {
        var sin = Mathf.Sin(speed * (targetTransform.position.x + targetTransform.position.y + Time.time));
        var direction = this.direction + GetNoise();
        direction.Normalize();
        var delta = direction * sin;
        target.localPosition = delta * maxMagnitude * fadeOut;
        target.position = new Vector3(targetTransform.position.x, target.position.y, -10);
    }

    private void Start()
    {
        ContinuousShake();
    }
    public void ContinuousShake()
    {
        enabled = true;
        fadeOut = 1f;
    }

    Vector2 GetNoise()
    {
        var time = Time.time;
        return noiseMagnitude
            * new Vector2(
                Mathf.PerlinNoise(targetTransform.position.x, time) - 0.5f,
                Mathf.PerlinNoise(targetTransform.position.y, time) - 0.5f
                );
    }

}
