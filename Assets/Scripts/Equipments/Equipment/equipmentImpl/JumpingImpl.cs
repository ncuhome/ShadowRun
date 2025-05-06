using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpingImpl : MonoBehaviour,IEquipmentPerb
{
    private float jumpHeight;
    private CharacterAction_SO playerAct;
    private Following following;

    public void Init(Transform playerTransform)
    {
        transform.position = playerTransform.position;
        playerAct = GameConfigManager.instance.characterAction_SO;
        jumpHeight = playerAct.jumpHeight;

        following = transform.GetComponent<Following>();
        following.target = playerTransform;
    }

    public IEnumerator Use(Transform transform)
    {
        Init(transform);
        playerAct.jumpHeight = EquipConstantsManager.EQUIPMENT_JUMP_HEIGHT;

        yield return new WaitForSeconds(EquipConstantsManager.EQUIPMENT_JUMP_MAX_TIME);

        //��ԭ
        playerAct.jumpHeight = jumpHeight;
        Destroy(gameObject);

    }
}
