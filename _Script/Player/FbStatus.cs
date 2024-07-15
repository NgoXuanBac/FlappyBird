using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbStatus : MonoBehaviour
{
    public FbShape fbShape;
    protected float targetAngle = 0f;
    protected float turnSpeed = 5f;
    private float speedUp = 20f;
    private float speedDown = 2f;

    private void Awake()
    {
        this.fbShape = FbCtrl.GetInstance().fbShape;
    }

    public void FlyUp()
    {
        this.targetAngle = 30f;
        this.turnSpeed = this.speedUp;
        this.RotationFb();
    }

    public void FlyDown()
    {
        this.targetAngle = -90f;
        this.turnSpeed = this.speedDown;
        this.RotationFb();
    }

    public void UnFly()
    {
        this.speedUp = 0;
        this.speedDown = 0;
    }

    private void RotationFb()
    {
        this.fbShape.birdShape.transform.rotation = Quaternion.Slerp(
            this.fbShape.birdShape.transform.rotation,
            Quaternion.Euler(0, 0, this.targetAngle),
            this.turnSpeed * Time.fixedDeltaTime
        );
    }
}
