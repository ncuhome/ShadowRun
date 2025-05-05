using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingBehavior : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine(LightingExit());
    }
    private IEnumerator LightingExit()
    {
        yield return new WaitForSeconds(EquipConstantsManager.LIGHTING_EQUIP_EXIT_TIME);
        GameObject.Destroy(gameObject);
    }
}
