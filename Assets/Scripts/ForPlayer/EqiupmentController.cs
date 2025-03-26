using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 挂载到可操控角色上，
/// 不提供静态，
/// 有一个静态结构体Arr记录装备信息
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
        equipmentArr = new EquipmentInfoStruct[Constants.MAX_EQUIPMENT_CAP];
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
    /// 检测装备碰撞
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentEquipCapcity  < Constants.MAX_EQUIPMENT_CAP)
        {
            if (collision.CompareTag("equip"))
            {
                //Debug.Log("pickup");
                PickUp(collision);
            }
        }
      
    }
    
    /// <summary>
    /// 拾取装备
    /// </summary>
    /// <param name="collision">被碰撞的装备</param>
    private void PickUp(Collider2D collision)
    {
      
        GameObject collidedObject = collision.gameObject;

        // 检查GameObject是否实现了Equipments接口
        IEquipmentTex equipment = collidedObject.GetComponent<IEquipmentTex>();
        if (equipment != null)
        {
      
           //给第一个非空元素赋值
          for(int i = 0; i < Constants.MAX_EQUIPMENT_CAP; i++)
            {             
                if (equipmentArr[i].equipmentPreb == null)
                {
                    equipmentArr[i] = equipment.infoStruct;
                    currentEquipCapcity++;
                    //更新装备栏
                    EquipmentUIController.instance.SetEquipmentTex(i, collidedObject.GetComponent<SpriteRenderer>().sprite);
                    break;
                }
                //Debug.Log(equipmentArr[i].prebPath);
            }
          //更新UI
            EquipmentUIController.instance.SetEquipments(equipmentArr);
            Destroy(collidedObject);
        }
        else
        {
            Debug.LogError("no Script！");
        }


    }


    /// <summary>
    /// 实例化装备对象，使用use（）
    /// 更新currentEquipmentCap和UIManager
    /// </summary>
    private void EquipmentUse()
    {
        //Debug.Log("getDown");
        if (equipmentArr[currentEquipNum].equipmentPreb != null)
        {
            //根据结构体加载预制体
            GameObject equip = Instantiate(equipmentArr[currentEquipNum].equipmentPreb);
            //得到预制体脚本
            var equipImpl = equip.GetComponent<IEquipmentPerb>();
            if (equipImpl == null)
            {
                Debug.LogError("no script on preb");
                return;
            }
            StartCoroutine(equipImpl.Use(transform));
            equipmentArr[currentEquipNum].equipmentPreb = null;
            currentEquipCapcity--;

            //更新UI
            EquipmentUIController.instance.SetEquipments(equipmentArr);
            EquipmentUIController.instance.RemoveEquipment(currentEquipNum);
        }

    }

    public void OnUseEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) EquipmentUse();
    }

    public void OnChoseEquip1(InputAction.CallbackContext context)
    {
        if (1 > Constants.MAX_EQUIPMENT_CAP) return;
        if (context.phase==InputActionPhase.Performed)
        {
            currentEquipNum = 0;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip2(InputAction.CallbackContext context)
    {
        if (2 > Constants.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 1;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip3(InputAction.CallbackContext context)
    {
        if (3 > Constants.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 2;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip4(InputAction.CallbackContext context)
    {
        if (4 > Constants.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 3;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }

    public void OnChoseEquip5(InputAction.CallbackContext context)
    {
        if (5 > Constants.MAX_EQUIPMENT_CAP) return;
        if (context.phase == InputActionPhase.Performed)
        {
            currentEquipNum = 4;
            EquipmentUIController.instance.Highlight(currentEquipNum);
        }
    }
}
