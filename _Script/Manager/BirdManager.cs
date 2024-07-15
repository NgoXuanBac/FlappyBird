using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    private static BirdManager instance;

    public static BirdManager GetInstance() => instance;

    protected Dictionary<string, GameObject> objects;

    protected const float distanceWithCamera = 1.5f;

    private void Awake()
    {
        BirdManager.instance = this;
        this.objects = new Dictionary<string, GameObject>();
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

    public virtual GameObject Spawn(string nameObj, Vector3 pos, Quaternion rot, Transform trans)
    {
        GameObject obj = this.GetObject(nameObj);
        if (obj == null)
            return null;
        pos.x -= distanceWithCamera;
        GameObject newObj = Instantiate(obj, pos, rot);
        newObj.name = "FbShape";
        newObj.transform.parent = trans;
        newObj.SetActive(true);
        return newObj;
    }

    protected virtual GameObject GetObject(string nameObj)
    {
        return this.objects[nameObj];
    }
}
