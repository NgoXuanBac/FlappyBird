using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    static PipeManager instance;
    protected Dictionary<string, GameObject> objects;
    protected GameObject rectPrefab;

    protected const float distance2PosY = 4.125f;
    protected const float rectPosX = 0.2f;
    protected const float minBottomPipePosY = -5f;
    protected const float maxBottomPipePosY = -2f;

    private void Awake()
    {
        PipeManager.instance = this;
        this.objects = new Dictionary<string, GameObject>();
        this.rectPrefab = GameObject.Find("RectPrefab");
        this.rectPrefab.SetActive(false);
        this.LoadObjects();
    }

    protected virtual void LoadObjects()
    {
        foreach (Transform child in transform)
        {
            this.objects.Add(child.gameObject.name, child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    static public PipeManager GetInstance() => instance;

    protected virtual GameObject GetObject(string nameEffect)
    {
        return this.objects[nameEffect];
    }

    private void spawnRectScore(Vector3 pos, Quaternion rot, Transform trans)
    {
        GameObject rectScore = Instantiate(this.rectPrefab, pos, rot);
        rectScore.transform.parent = trans;
        rectScore.name = "RectScore";
        rectScore.SetActive(true);
    }

    public virtual void Spawn(string nameObj, Vector3 pos, Quaternion rot, Transform trans)
    {
        this.Spawn(this.GetObject(nameObj), pos, rot, trans);
    }

    private void Spawn(GameObject obj, Vector3 pos, Quaternion rot, Transform trans)
    {
        if (obj == null)
            return;
        pos.y = Random.Range(minBottomPipePosY, maxBottomPipePosY);
        GameObject bottomObj = Instantiate(obj, pos, rot);
        pos.y += distance2PosY;
        this.spawnRectScore(pos, rot, trans);
        pos.y += distance2PosY;
        GameObject topObj = Instantiate(obj, pos, rot);
        topObj.transform.localScale = GetScaleFlip(topObj);
        //Manager Object
        topObj.name = "PipeTop";
        bottomObj.name = "PipeBottom";

        topObj.transform.parent = trans;
        bottomObj.transform.parent = trans;
        topObj.SetActive(true);
        bottomObj.SetActive(true);
    }

    private Vector3 GetScaleFlip(GameObject obj)
    {
        return new Vector3(
            obj.transform.localScale.x,
            -1 * obj.transform.localScale.y,
            obj.transform.localScale.z
        );
    }
}
