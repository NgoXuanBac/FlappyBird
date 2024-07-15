using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    public bool isStart = false;
    public AnimationCurve curve;
    public float duration = 1f;

    private void Update()
    {
        if (isStart)
        {
            isStart = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPos = transform.position;

        for (float elapsedTime = 0f; elapsedTime < this.duration; elapsedTime += Time.deltaTime)
        {
            float strenght = this.curve.Evaluate(elapsedTime / this.duration);
            transform.position = startPos + Random.insideUnitSphere;
            yield return null;
        }
    }
}
