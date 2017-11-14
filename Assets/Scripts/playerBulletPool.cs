using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerBulletPool : MonoBehaviour {

    public static playerBulletPool Current;
    public Transform Pool; // empty gameobject
    public GameObject ObjectForPool;
    public int pooledAmount = 200;
    public bool growth = true;

    List<GameObject> ObjectsForPool;

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        ObjectsForPool = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(ObjectForPool) as GameObject;
            obj.SetActive(false);
            obj.transform.SetParent(Pool);
            ObjectsForPool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < ObjectsForPool.Count; i++)
        {
            if (!ObjectsForPool[i].activeInHierarchy)
                return ObjectsForPool[i];
        }
        if (growth)
        {
            GameObject obj = Instantiate(ObjectForPool) as GameObject;
            obj.transform.SetParent(Pool);
            ObjectsForPool.Add(obj);
            return obj;
        }
            return null;
    }
}
