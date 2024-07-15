using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    protected GameObject obj;
    private void Awake()
    {
        this.obj = GameObject.Find("FlappyBird");
    }
    private void FixedUpdate()
    {
        this.Follow();
    }
    protected void Follow()
    {
        transform.position = new Vector3(this.obj.transform.position.x, 0, transform.position.z);
    }
}
