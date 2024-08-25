using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public float minScale = 0.95f;
    public float maxScale = 1.05f;
    public float speed = 1.0f;

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Lerp is extensively used to smooth transitioning over time.
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.Sin(Time.time * speed) * 0.5f + 0.5f);

        transform.localScale = new Vector3(scale, scale, originalScale.z);
    }
}
