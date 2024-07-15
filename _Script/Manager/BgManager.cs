using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    static BgManager instance;
    public const int widthBg = 288;
    public const int heightBg = 512;
    public const float distance2PosX = 5.52f;

    public static BgManager GetInstance() => instance;

    protected Dictionary<string, GameObject> objects;

    private void Awake()
    {
        BgManager.instance = this;
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

    protected virtual GameObject GetObject(string nameEffect)
    {
        return this.objects[nameEffect];
    }

    public virtual void Spawn(string nameObj, Vector3 pos, Quaternion rot, Transform trans)
    {
        this.Spawn(this.GetObject(nameObj), pos, rot, trans);
    }

    private void Spawn(GameObject obj, Vector3 pos, Quaternion rot, Transform trans)
    {
        if (obj == null)
            return;
        GameObject leftObj = Instantiate(obj, pos, rot);
        pos.x += distance2PosX;
        pos.z = leftObj.transform.position.z - 1;
        GameObject rightObj = Instantiate(obj, pos, rot);
        //Manager Object
        leftObj.SetActive(true);
        rightObj.SetActive(true);
        leftObj.name = "BgLeft";
        rightObj.name = "BgRight";
        leftObj.transform.parent = trans;
        rightObj.transform.parent = trans;
    }
}
