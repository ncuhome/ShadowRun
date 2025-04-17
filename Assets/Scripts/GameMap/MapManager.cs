using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject mapParent;
    public List<Map> maps;
    public Map firstMap;
    private Map currentMap;
    private Map fomerMap;
    private Map nextMap;
    private bool hasNext = false;
    private new Camera camera;
    ObjectPool<Map> mapPool;

    private void Awake()
    {
        mapPool = new ObjectPool<Map>(mapParent.transform);
        currentMap = firstMap;
        camera = Camera.main;
    }
    private void Start()
    {
        UpdateStaticLights();
    }
    private void Update()
    {
        UpdateMap();
    }
    private void UpdateMap()
    {
        if (currentMap.transform.position.x < camera.transform.position.x && !hasNext) GenerateNextMap();
        if (currentMap.end.position.x < camera.transform.position.x) ChangeCurrentMap();
    }
    private void ChangeCurrentMap()
    {
        fomerMap = currentMap;
        currentMap = nextMap;
        hasNext = false;
        UpdateStaticLights();
    }
    private void GenerateNextMap()
    {
        nextMap = mapPool.GetObj(GetRandomMap());
        nextMap.transform.position = new Vector3(currentMap.end.position.x + (nextMap.transform.position.x - nextMap.begin.position.x),
            currentMap.transform.position.y, currentMap.transform.position.z);
        if(fomerMap)mapPool.PushObj(fomerMap.gameObject);
        hasNext = true;        
    }
    private Map GetRandomMap()
    {
        int randomNum = Random.Range(0, maps.Count);
        return maps[randomNum];
    }
    private void OnDestroy()
    {
        mapPool.Clear();
    }
    private void UpdateStaticLights()
    {
        LightDetect.instance.lightSources = currentMap.lights;
    }
}