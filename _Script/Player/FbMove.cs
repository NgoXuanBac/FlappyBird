using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbMove : MonoBehaviour
{
    protected const float maxForceUp = 7.5f;

    protected float speedForceUp = 14f;

    protected const float maxForceDown = -6.5f;

    protected float speedForceDown = 27f;

    protected const float gravity = 9.8f;

    protected Rigidbody2D rigidbody2;
    protected Vector2 force;
    protected BoxCollider2D colliderFb;

    protected float forceFlyHori = 3f;
    protected float forceFlyVer = 0;
    protected float timer = 0;
    protected float timerDelay = 0;
    protected bool isFlyUp = false;
    public bool isDead = false;
    private bool isHold = false;
    private bool isFirstTouch = true;
    private bool isFirstCollider = true;
    private bool isTouch = false;

    private void Awake()
    {
        this.rigidbody2 = GetComponent<Rigidbody2D>();
        this.colliderFb = GetComponent<BoxCollider2D>();
        this.rigidbody2.gravityScale = gravity;
    }

    private void Update()
    {
        this.CheckTouch();
        if (this.isFirstTouch)
        {
            this.rigidbody2.Sleep();
            return;
        }
        this.UpdateCtrl();
        this.UpdateForce();
    }

    private void FixedUpdate()
    {
        this.UpdateRigid();
    }

    private void UpdateCtrl()
    {
        // ===> when FlyDown
        FbCtrl.GetInstance().fbStatus.FlyDown();
        if (this.isDead)
            FbCtrl.GetInstance().fbShape.birdShape.GetComponent<Animator>().enabled = false;
        else
        {
            //===> when tounch
            if (this.isTouch)
            {
                AudioManager.GetInstance().PlayWing();
                this.isFlyUp = true;
                this.forceFlyVer = maxForceUp;
            }
            //===> when tounch and no tounch & when FlyUp
            if (this.isFlyUp && this.forceFlyVer >= 0)
            {
                FbCtrl.GetInstance().fbStatus.FlyUp();
                // this.forceFlyVer -= speedForceUp * Time.fixedDeltaTime;
                this.forceFlyVer -= speedForceUp * Time.deltaTime;

                return;
            }
        }
        //===> when no tounch & when FlyDown
        // this.forceFlyVer -= speedForceDown * Time.fixedDeltaTime;
        this.forceFlyVer -= speedForceDown * Time.deltaTime;

        if (this.forceFlyVer <= maxForceDown)
            this.forceFlyVer = maxForceDown;
        this.isFlyUp = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if no collision && if collision != scoreRect
        if (other == null || other.gameObject.name == "RectScore")
            return;
        this.isDead = true;

        this.UnForceHori();
        if (this.isFirstCollider)
        {
            GameManager.GetInstance().OnFlickerEf();
            AudioManager.GetInstance().PlayHit();
            AudioManager.GetInstance().PlayDie();
            this.isFirstCollider = false;
        }
        if (other.gameObject.name == "BaseLeft" || other.gameObject.name == "BaseRight")
        {
            this.rigidbody2.gravityScale = 0;
            this.UnForceVer();
            FbCtrl.GetInstance().fbStatus.UnFly();
            GameManager.GetInstance().GameOver();
        }
    }

    private void CheckTouch()
    {
        if (
            (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            && this.isHold == false
            && this.isDead == false
        )
        {
            this.isFirstTouch = false;
            this.isHold = true;
            this.isTouch = true;
            return;
        }
        if ((Input.touchCount == 0 || Input.GetMouseButtonUp(0)) && this.isHold == true)
            this.isHold = false;
        this.isTouch = false;
    }

    protected void UpdateRigid()
    {
        this.rigidbody2.MovePosition(this.rigidbody2.position + this.force * Time.fixedDeltaTime);
    }

    protected void UpdateForce()
    {
        if (this.rigidbody2.IsSleeping())
            this.rigidbody2.WakeUp();
        this.force = new Vector2(this.forceFlyHori, this.forceFlyVer);
    }

    protected void UnForceHori()
    {
        this.forceFlyHori = 0;
    }

    protected void UnForceVer()
    {
        this.forceFlyVer = 0;
        this.speedForceDown = 0;
        this.speedForceUp = 0;
    }
}
