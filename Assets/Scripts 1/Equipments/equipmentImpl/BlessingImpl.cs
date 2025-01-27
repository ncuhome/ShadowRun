using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingImpl : MonoBehaviour,IEquipmentPerb
{
    public void Init(Transform transform)
    {
        gameObject.transform.position = transform.position;
        Following following = GetComponent<Following>();
        following.target = transform;
    }

    public IEnumerator Use(Transform transform)
    {
        Debug.Log("use");
        Init(transform);
        yield return new WaitForSeconds(Constants.BLESSING_EXIT_TIME);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
