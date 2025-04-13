using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Transform parent;
    public ObjectPool(Transform parent) { this.parent = parent; }
    private Dictionary<string, Queue<T>> pool = 
        new Dictionary<string, Queue<T>>();

    public void PushObj(GameObject gameObject)
    {
        if (!gameObject) Debug.LogError("null prefab");
        string name = gameObject.name.Replace("(Clone)", string.Empty);
        if (!pool.ContainsKey(name)) pool.Add(name, new Queue<T>());
        pool[name].Enqueue(gameObject.GetComponent<T>());
        gameObject.gameObject.SetActive(false);
    }
    public T GetObj(T perfab)
    {
        T res;
        if(!pool.ContainsKey(perfab.name) || pool[perfab.name].Count == 0)
        {           
            res = GameObject.Instantiate(perfab.gameObject).GetComponent<T>();
            //Debug.Log(res);
            PushObj(res.gameObject);
        }
        res = pool[perfab.name].Dequeue();
        res.transform.SetParent(parent);
        res.gameObject.SetActive(true);
        return res;
    }
    public void Clear()
    {
        pool.Clear();
    }
}
