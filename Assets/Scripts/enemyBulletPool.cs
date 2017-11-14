using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyBulletPool : MonoBehaviour {

    public static enemyBulletPool Current;
    public Transform Pool; // empty gameobject
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public int pooledAmount = 50;
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
            GameObject obj = Instantiate(red) as GameObject;
            obj.SetActive(false);
            obj.transform.SetParent(Pool);
            ObjectsForPool.Add(obj);

        }
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(green) as GameObject;
            obj.SetActive(false);
            obj.transform.SetParent(Pool);
            ObjectsForPool.Add(obj);
        }
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(blue) as GameObject;
            obj.SetActive(false);
            obj.transform.SetParent(Pool);
            ObjectsForPool.Add(obj);
        }
    }

    public GameObject GetPooledObject(string colour)
    {
        for (int i = 0; i < ObjectsForPool.Count; i++)
        {
            if (!ObjectsForPool[i].activeInHierarchy && ObjectsForPool[i].tag.Equals(colour))
                return ObjectsForPool[i];
        }
        if (growth)
        {
            GameObject obj = new GameObject();
            switch (colour)
            {
                case "red":
                    obj = Instantiate(red) as GameObject;
                    obj.transform.SetParent(Pool);
                    ObjectsForPool.Add(obj);
                    break;
                case "blue":
                    obj = Instantiate(blue) as GameObject;
                    obj.transform.SetParent(Pool);
                    ObjectsForPool.Add(obj);
                    break;
                case "green":
                    obj = Instantiate(green) as GameObject;
                    obj.transform.SetParent(Pool);
                    ObjectsForPool.Add(obj);
                    break;
            }
            return obj;    
        }
        return null;
    }
}
