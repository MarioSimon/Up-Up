using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour
{

    bool falling = false;
    [SerializeField] float fallSpeed = 1;

    bool shaking = false;
    Vector3 startingPos;
    [SerializeField] float shakeValue = 0.25f;
    int shakeIterator = 0;

    void Start()
    {
        startingPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ShakeAndFall());
        }
    }


    void Update()
    {
        if (shaking)
        {
            if (shakeIterator % 2 == 0)
            {
                float shakeX = Random.Range(-shakeValue, shakeValue);
                float shakeZ = Random.Range(-shakeValue, shakeValue);

                transform.position += new Vector3(shakeX, 0, shakeZ);

                shakeIterator += 1;
            }
            else
            {
                transform.position = startingPos;

                shakeIterator += 1;
            }
        }

        if (falling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }

    IEnumerator ShakeAndFall()
    {
        shaking = true;
        yield return new WaitForSeconds(2);

        shaking = false;
        shakeIterator = 0;
        transform.position = startingPos;
        falling = true;
        yield return new WaitForSeconds(5);

        falling = false;
        transform.position = startingPos;
    }
}
