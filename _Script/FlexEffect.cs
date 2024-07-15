using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexEffect : MonoBehaviour
{
    protected float maxScale;
    protected float minScale;
    protected float speed = 1f;
    public bool isTurnOn = true;
    protected Vector3 scale;
    protected bool isZoomIn = true;
    protected bool isZoomOut = false;

    private void Start()
    {
        this.minScale = transform.localScale.x;
        this.maxScale = transform.localScale.x + 0.5f;
        this.scale = transform.localScale;
    }

    private void Update()
    {
        if (isTurnOn == false)
            return;
        this.changeScale();
        transform.localScale = this.scale;
    }

    void changeScale()
    {
        if (this.isZoomIn)
        {
            this.ZoomIn();
            return;
        }
        this.ZoomOut();
    }

    void ZoomIn()
    {
        this.scale.x += Time.deltaTime * this.speed;
        this.scale.y += Time.deltaTime * this.speed;
        if (this.scale.x >= maxScale)
        {
            this.scale.x = maxScale;
            this.scale.y = maxScale;
            this.isZoomIn = false;
            this.isZoomOut = true;
        }
    }

    void ZoomOut()
    {
        this.scale.x -= Time.deltaTime * this.speed;
        this.scale.y -= Time.deltaTime * this.speed;
        if (this.scale.x <= minScale)
        {
            this.scale.x = minScale;
            this.scale.y = minScale;
            this.isZoomOut = false;
            this.isZoomIn = true;
        }
    }
}
