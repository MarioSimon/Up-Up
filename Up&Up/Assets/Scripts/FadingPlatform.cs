using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    bool fading = true;

    [SerializeField] float fadeSpeed = 1f;
    new Renderer renderer;

    private void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    private void Update()
    {
        if (fading && renderer.material.color.a > 0)
        {
            Color color = renderer.material.color;
            float fadeAmount = color.a - fadeSpeed * Time.deltaTime;

            color = new Color(color.r, color.g, color.b, fadeAmount);
            renderer.material.color = color;
        }
        else if (!fading && renderer.material.color.a < 1)
        {
            Color color = renderer.material.color;
            float fadeAmount = color.a + fadeSpeed * Time.deltaTime;

            color = new Color(color.r, color.g, color.b, fadeAmount);
            renderer.material.color = color;
        }

        if (renderer.material.color.a <= 0)
        {
            StartCoroutine(FadeIn());
        }
        else if (renderer.material.color.a >= 1)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(3);

        fading = false;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);

        fading = true;
    }
}
