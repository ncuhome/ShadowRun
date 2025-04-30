using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ���ص��ɲٿؽ�ɫ�ϣ�
/// ���ṩ��̬��
/// ��һ����̬�ṹ��Arr��¼װ����Ϣ
/// </summary>
public class EqiupmentController : MonoBehaviour,CharacterInputSystem.IEquipmentPlayActions
{

    private EquipmentInfoStruct[] equipmentArr;
    public int currentEquipNum;
    private int currentEquipCapcity;
    private CharacterInputSystem _inputActions;
    // Start is called before the first frame update
    void Awake()
    {
        _inputActions = new CharacterInputSystem();
        _inputActions.EquipmentPlay.SetCallbacks(this);
        equipmentArr = new EquipmentInfoStruct[EquipConstantsManager.MAX_EQUIPMENT_CAP];
        currentEquipNum = 0;
        currentEquipCapcity = 0;
    }

    private void OnEnable()
    {
        _inputActions.EquipmentPlay.Enable();
    }
    private void OnDisable()
    {
        _inputActions.EquipmentPlay.Disable();
    }
    /// <summary>
    /// ���װ����ײ
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentEquipCapcity  < EquipConstantsManager.MAX_EQUIPMENT_CAP)
        {
            if (collision.CompareTag("equip"))
            {
                //Debug.Log("pickup");
                PickUp(collision);
            }
        }
      
    }
    
    /// <summary>
    /// ʰȡװ��
    /// </summary>
    /// <param name="collision">����ײ��װ��</param>
    private void PickUp(Collider2D collision)
    {
      
        GameObject collidedObject = collision.gameObject;

        // ���GameObject�Ƿ�ʵ����Equipments�ӿ�
        IEquipmentTex equipment = collidedObject.GetComponent<IEquipmentTex>();
        if (equipment != null)
        {
      
           //����һ���ǿ�Ԫ�ظ�ֵ
          for(int i = 0; i < EquipConstantsManager.MAX_EQUIPMENT_CAP; i++)
            {             
                if (equipmentArr[i].equipmentPreb == null)
                {
                    equipmentArr[i] = equipment.infoStruct;
                    currentEquipCapcity++;
                    //����װ����
                    EquipmentUIController.instance.SetEquipmentTex(i, collidedObject.GetComponent<SpriteRenderer>().sprite);
                    break;
                }
                //Debug.Log(equipmentArr[i].prebPath);
            }
          //����UI           
            Destroy(collidedObject);
        }
        else
        {
            Debug.LogError("no Script��");
        }


    }


    /// <summary>
    /// ʵ����װ������ʹ��use����
    /// ����currentEquipmentCap��UIManager
    /// </summary>
    private void EquipmentUse()
    {
        //Debug.Log("getDown");
        if (equipmentArr[currentEquipNum].equipmentPreb != null)
        {
            //���ݽṹ�����Ԥ����
            GameObject equip = Instantiate(equipmentArr[currentEquipNum].equipmentPreb);
            //�õ�Ԥ����ű�
            var equipImpl = equip.GetComponent<IEquipmentPerb>();
            if (equipImpl == null)
            {
                Debug.LogError("no script on preb");
                return;
            }
            StartCoroutine(equipImpl.Use(transform));
            equipmentArr[currentEquipNum].equipmentPreb = null;
            currentEquipCapcity--;

            //����UI
            EquipmentUIController.instance.RemoveEquipment(currentEquipNum);
        }

    }

    public void OnUseEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) EquipmentUse();
    }

    public void OnChoseEquip1(InputAction.CallbackContext context)
    {
        if (1 > EquipConstantsManager.MAX_EQUIPMENT_CAP) return;
        if (context.phase==InputActionPhase.Performed)
        {
            currentEquipNum = 0;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip2(InputAction.CallbackContext context)
    {
        if (2 > EquipConstantsManager.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 1;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip3(InputAction.CallbackContext context)
    {
        if (3 > EquipConstantsManager.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 2;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip4(InputAction.CallbackContext context)
    {
        if (4 > EquipConstantsManager.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 3;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip5(InputAction.CallbackContext context)
    {
        if (5 > EquipConstantsManager.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 4;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }
}
