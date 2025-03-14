using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挂载到可操控角色上，
/// 不提供静态，
/// 有一个静态结构体Arr记录装备信息
/// </summary>
public class EqiupmentManager : MonoBehaviour
{

    private EquipmentInfoStruct[] equipmentArr;
    public int currentEquipNum;
    private int currentEquipCapcity;
    // Start is called before the first frame update
    void Start()
    {
        equipmentArr = new EquipmentInfoStruct[Constants.MAX_EQUIPMENT_CAP];
        currentEquipNum = 0;
        currentEquipCapcity = 0;
    }

    // Update is called once per frame
    void Update()
    {
     /*   DetectEquipmentUse();
        DetectEquipmentChoose();*/
    }

    /// <summary>
    /// 检测装备碰撞
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentEquipCapcity + 1 < Constants.MAX_EQUIPMENT_CAP)
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
        IEquipment equipment = collidedObject.GetComponent<IEquipment>();
        if (equipment != null)
        {
      
           //给第一个非空元素赋值
          for(int i = 0; i < Constants.MAX_EQUIPMENT_CAP; i++)
            {             
                if (equipmentArr[i].prebPath == null)
                {
                    equipmentArr[i] = equipment.GetStruct();
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
    /// 检测装备使用
    /// 若使用，实例化装备对象，使用use（）
    /// 更新currentEquipmentCap和UIManager
    /// </summary>
    private void DetectEquipmentUse()
    {
        if (Input.GetAxis("Fire1") > 0.3)
        {
            //Debug.Log("getDown");
            if(equipmentArr[currentEquipNum].prebPath!=null )
            {
                //根据结构体加载预制体
                GameObject equip = Instantiate(Resources.Load<GameObject>(equipmentArr[currentEquipNum].prebPath));
                //得到预制体脚本
                var equipImpl = equip.GetComponent<IEquipmentPerb>();
                if(equipImpl == null)
                {
                    Debug.LogError("no script on preb");
                    return;
                }
                StartCoroutine(equipImpl.Use(transform));
                equipmentArr[currentEquipNum].prebPath = null;
                currentEquipCapcity--;

                //更新UI
                EquipmentUIController.instance.SetEquipments(equipmentArr);
                EquipmentUIController.instance.RemoveEquipment(currentEquipNum);
            }
                  
           
        }

    }

    /// <summary>
    /// 检测目前选中装备
    /// </summary>
    private void DetectEquipmentChoose()
    {
        int num = currentEquipNum;
        if(Input.GetAxis("Equipment1") > 0.3)
        {
            currentEquipNum = 0;
        }
        else if(Input.GetAxis("Equipment2") > 0.3)
        {
            currentEquipNum = 1;
        }
        else if (Input.GetAxis("Equipment3") > 0.3)
        {
            currentEquipNum = 2;
        }
        else if (Input.GetAxis("Equipment4") > 0.3)
        {
            currentEquipNum = 3;
        }

        if(currentEquipNum >= Constants.MAX_EQUIPMENT_CAP)
        {
            currentEquipNum = num;
        }

        EquipmentUIController.instance.Highlight(currentEquipNum);
    }
}
