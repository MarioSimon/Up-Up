using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 1.5f;
    public float limit = 75f;
    public bool axisX = false;
    public bool randomStart = false;
    private float random = 0f;

    private void Awake()
    {
        if (randomStart)
        {
            random = Random.Range(0f, 1f);
        }
    }

    void Update()
    {
        float angle = limit * Mathf.Sin((Time.time + random) * speed);

        if (axisX)
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
