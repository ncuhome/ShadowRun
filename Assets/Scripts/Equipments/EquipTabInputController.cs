using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_ANDROID || UNITY_IOS
public class EquipTabInputController : MonoBehaviour
{
    [HideInInspector]
    public EquipmentInfoStruct infoStruct;
    private Button button;
    void Awake()
    {
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
       EqiupmentController.instance.SetCurrentEquipNum(infoStruct.equipmentID);
    }
}
#endif