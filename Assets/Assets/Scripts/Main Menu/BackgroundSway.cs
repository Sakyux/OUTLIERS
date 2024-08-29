using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSway : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f; 

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float time = Time.time;

        float x = amplitude * Mathf.Tan(frequency * time);
        float y = amplitude * Mathf.Tan(frequency * time);
        float z = initialPosition.z;

        transform.position = initialPosition + new Vector3(x, y, z);
    }
}
