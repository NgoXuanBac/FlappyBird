using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    protected GameObject pipePrefab;
    protected GameObject pipeSpawnPos;
    protected GameObject pipeCurrent;

    protected float distance = 0;
    protected float repeatDistance = 5f;

    private void Start()
    {
        this.pipePrefab = GameObject.Find("PipePrefab");
        this.pipeSpawnPos = GameObject.Find("PipeSpawnPos");
        this.pipePrefab.SetActive(false);
        this.Spawn(this.pipeSpawnPos.transform.position);
    }

    private void FixedUpdate()
    {
        this.UpdateBg();
    }

    private void UpdateBg()
    {
        this.distance =
            this.pipeSpawnPos.transform.position.x - this.pipeCurrent.transform.position.x;
        if (this.distance > repeatDistance)
            this.Spawn();
    }

    protected virtual void Spawn()
    {
        Vector3 posBgSpawn = this.pipeSpawnPos.transform.position;
        posBgSpawn.y = 0;
        this.Spawn(posBgSpawn);
    }

    protected virtual void Spawn(Vector3 pos)
    {
        this.pipeCurrent = Instantiate(this.pipePrefab, pos, this.pipePrefab.transform.rotation);
        this.pipeCurrent.transform.parent = gameObject.transform;
        this.pipeCurrent.SetActive(true);
    }
}
