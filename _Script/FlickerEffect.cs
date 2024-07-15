using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    private Image img;
    public bool isFlicker = false;
    static FlickerEffect instance;

    public static FlickerEffect GetInstance() => instance;

    private void Awake()
    {
        FlickerEffect.instance = this;
        this.img = GetComponent<Image>();
        img.color = new Color(0, 0, 0, 0);
    }

    private void Update()
    {
        if (isFlicker)
        {
            StartCoroutine(FadeIn(5));
            StartCoroutine(Clear(5));
            isFlicker = false;
        }
    }

    IEnumerator Clear(float speed)
    {
        for (float i = 1; i >= 0; i -= speed * Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }

    IEnumerator FadeIn(float speed)
    {
        for (float i = 0; i <= 1; i += speed * Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
