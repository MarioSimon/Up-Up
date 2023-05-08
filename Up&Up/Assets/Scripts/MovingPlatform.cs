using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;

    public float platformSpeed = 5;
    public float waitTime = 1.5f;

    bool from1To2;
    bool stopped;

    void Start()
    {
        platform.transform.position = position1.position;

        from1To2 = true;
    }

    void Update()
    {
        if (from1To2)
        {
            Vector3 newPos = Vector3.MoveTowards(platform.transform.position, position2.position, platformSpeed * Time.deltaTime);
            platform.transform.position = newPos;
        }
        else
        {
            Vector3 newPos = Vector3.MoveTowards(platform.transform.position, position1.position, platformSpeed * Time.deltaTime);
            platform.transform.position = newPos;
        }

        if (platform.transform.position == position1.position && !stopped)
        {
            stopped = true;
            StartCoroutine(WaitAndChangeDestination());
        }
        if (platform.transform.position == position2.position && !stopped)
        {
            stopped = true;
            StartCoroutine(WaitAndChangeDestination());
        }
    }

    IEnumerator WaitAndChangeDestination()
    {
        yield return new WaitForSeconds(waitTime);

        stopped = false;
        from1To2 = !from1To2;
    }


}


