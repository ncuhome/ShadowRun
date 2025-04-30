using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{

    public Transform target;
    public bool y_lock = false;
    [SerializeField] Vector2 offset;
    [SerializeField] float transition = 2f;
    private Transform thisTransform;
    void Awake()
    {
        thisTransform = transform;
    }

    private void LateUpdate()   
    {
        if (target != null)
        {
            Vector2 targetPos;
            if(y_lock)
            {
                targetPos = new Vector3(target.position.x,0) + new Vector3(offset.x,offset.y,0);
            }
            else
            {
                targetPos = target.position + new Vector3(offset.x, offset.y, 0);
            }
            //Debug.Log(y_lock);
            thisTransform.position = Vector3.Lerp(transform.position, targetPos, transition * Time.deltaTime);
        }

    }
}
