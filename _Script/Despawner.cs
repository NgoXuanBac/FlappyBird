using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    protected float distance = 0;
    const float deleteDistance = 13f;

    private void FixedUpdate()
    {
        this.Despawn();
    }

    private void Despawn()
    {
        this.distance = FbCtrl.GetInstance().transform.position.x - this.transform.position.x;
        if (this.distance > deleteDistance)
            Destroy(gameObject);
    }
}
