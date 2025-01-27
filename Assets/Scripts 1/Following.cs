using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{

    public Transform target;
    [SerializeField] Vector2 offset;
    [SerializeField] float transition = 2f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector2 targetPos = target.position + new Vector3(offset.x,offset.y,0);
            transform.position = Vector3.Lerp(transform.position, targetPos, transition * Time.deltaTime);
        }

    }
}
