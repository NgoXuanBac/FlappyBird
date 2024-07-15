using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    protected GameObject bgPrefab;
    protected GameObject bgSpawnPos;
    protected GameObject bgCurrent;

    // protected GameObject cameraPos;

    protected float distance = 0;
    protected float repeatDistance = 5.52f;
    protected const int layerLaterObj = -5;
    protected const int layerFrontObj = 0;

    private void Start()
    {
        this.bgPrefab = GameObject.Find("BgPrefab");
        this.bgSpawnPos = GameObject.Find("BgSpawnPos");
        // this.cameraPos = GameObject.Find("Main Camera");
        this.Spawn(transform.position);
        this.bgPrefab.SetActive(false);
    }

    private void Update()
    {
        this.UpdateBg();
    }

    private void UpdateBg()
    {
        this.distance =
            FbCtrl.GetInstance().transform.position.x - this.bgCurrent.transform.position.x;
        if (this.distance >= repeatDistance)
            this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 posBgSpawn = this.bgSpawnPos.transform.position;
        posBgSpawn.y = 0;
        this.Spawn(posBgSpawn);
    }

    protected virtual void Spawn(Vector3 pos)
    {
        if (this.bgCurrent != null)
        {
            Vector3 posCurrent = this.bgCurrent.transform.position;
            posCurrent.z = layerFrontObj;
            this.bgCurrent.transform.position = posCurrent;
            pos.z = layerLaterObj;
        }
        this.bgCurrent = Instantiate(this.bgPrefab, pos, this.bgPrefab.transform.rotation);
        this.bgCurrent.transform.parent = gameObject.transform;
        this.bgCurrent.SetActive(true);
    }
}
