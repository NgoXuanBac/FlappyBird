using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    protected GameObject basePrefab;
    protected GameObject baseSpawnPos;
    protected GameObject baseCurrent;
    protected float distance = 0;
    protected float repeatDistance = 6.72f;

    private void Start()
    {
        this.basePrefab = GameObject.Find("BasePrefab");
        this.baseSpawnPos = GameObject.Find("BaseSpawnPos");
        this.Spawn(transform.position);
        this.basePrefab.SetActive(false);
    }

    private void Update()
    {
        this.UpdateBg();
    }

    private void UpdateBg()
    {
        this.distance =
            FbCtrl.GetInstance().transform.position.x - this.baseCurrent.transform.position.x;
        if (this.distance >= repeatDistance)
            this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 posBgSpawn = this.baseSpawnPos.transform.position;
        this.Spawn(posBgSpawn);
    }

    protected virtual void Spawn(Vector3 pos)
    {
        if (this.baseCurrent != null)
        {
            Vector3 posCurrent = this.baseCurrent.transform.position;
            posCurrent.z = 0;
            this.baseCurrent.transform.position = posCurrent;
            pos.z = -1;
        }
        pos.y = -4.5f;
        this.baseCurrent = Instantiate(this.basePrefab, pos, this.basePrefab.transform.rotation);
        this.baseCurrent.transform.parent = gameObject.transform;
        this.baseCurrent.SetActive(true);
    }
}
