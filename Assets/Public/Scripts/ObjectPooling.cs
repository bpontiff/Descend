using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                createPooledObj(item.objectToPool);
            }
        }
    }

    public GameObject SafeGetPooledObject(string tag)
    {
        GameObject gameObject = GetPooledObject(tag);

        //If a null is gotten for the game object throw an error
        if (gameObject == null)
            throw new System.Exception("No game object found in pool for tag " + tag);

        return gameObject;
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    return createPooledObj(item.objectToPool);
                }
            }
        }
        Debug.Log("Instance for tag not found: " + tag);
        return null;
        
    }


    private GameObject createPooledObj(GameObject objectToPool)
    {
        GameObject obj = Instantiate(objectToPool);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
