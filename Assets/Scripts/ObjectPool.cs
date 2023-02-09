using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    public int createOnStart;

    private List<GameObject> pooledObjs = new List<GameObject>();

    void Start ()
    {
        for(int x = 0; x < createOnStart; x++)
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject ()
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        pooledObjs.Add(obj);

        return obj;
    }

    public GameObject GetObject ()
    {
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);

        if(obj == null)
        {
            obj = CreateNewObject();
        }

        obj.SetActive(true);

        return obj;
    }
}