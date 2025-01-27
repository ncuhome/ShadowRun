using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingImpl : MonoBehaviour,IEquipmentPerb
{
    private float jumpHeight;
    private CharcterAction playerAct;
    private Following following;

    public void Init(Transform playerTransform)
    {
        transform.position = playerTransform.position;
        playerAct = playerTransform.GetComponent<CharcterAction>();
        jumpHeight = playerAct.jumpHeight;

        following = transform.GetComponent<Following>();
        following.target = playerTransform;
    }

    public IEnumerator Use(Transform transform)
    {
        Init(transform);
        playerAct.jumpHeight = Constants.EQUIPMENT_JUMP_HEIGHT;

        yield return new WaitForSeconds(Constants.EQUIPMENT_JUMP_MAX_TIME);

        //»¹Ô­
        playerAct.jumpHeight = jumpHeight;
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
