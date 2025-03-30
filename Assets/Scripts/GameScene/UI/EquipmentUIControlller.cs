using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// 管理装备和血条的UI脚本
/// 提供静态instance
/// </summary>
public class EquipmentUIController : MonoBehaviour
{
    public static EquipmentUIController _instance;
    public static EquipmentUIController instance
    {
        get
        {
            if (!_instance)
            {
                if (!(_instance = FindAnyObjectByType<EquipmentUIController>()))
                {
                    Debug.LogError("no EquipmentUIController in the scene");
                }
            }
            return _instance;
        }
    }
    [Header("装备栏")]
    public Transform equipmentBag;
    [Header("单个装备栏预制体")]
    private GameObject[] equipmentTabs;
    private GameObject[] equipmentTextures;
    public TextMeshProUGUI equipmentText;
    private int currentHiglight;

    // Start is called before the first frame update
    void Awake()
    {
        equipmentTextures = new GameObject[EquipConstantsManager.MAX_EQUIPMENT_CAP];
        Init();
        currentHiglight = 0;

    }

    /// <summary>
    /// 初始化装备UI界面
    /// </summary>
    public void Init()
    {
        equipmentTabs = new GameObject[EquipConstantsManager.MAX_EQUIPMENT_CAP];
        for (int i = 0; i < EquipConstantsManager.MAX_EQUIPMENT_CAP; i++)
        {
            GameObject equipTab = Instantiate(AssetsManager.instance.equipTab);
            if (equipTab.CompareTag("EquipmentUI"))
            {
                equipmentTabs[i] = equipTab;
                equipTab.transform.SetParent(equipmentBag);
                equipTab.transform.localPosition = new Vector2((equipTab.GetComponent<Image>().rectTransform.rect.width) * i +20,0);
                equipTab.GetComponent<Image>().rectTransform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                Debug.LogError("find object no UI tag");
            }
        }
    }

    /// <summary>
    /// 设置装备的图片，显示在装备栏
    /// </summary>
    /// <param name="equipmentIndex">装备下标</param>
    /// <param name="equipemtTex">装备图</param>
    public void SetEquipmentTex(int equipmentIndex, Sprite equipemtTex)
    {
        GameObject equipment = new GameObject(equipmentIndex.ToString());
        Image image = equipment.AddComponent<Image>();
        Transform newEquipemtTransform = equipmentTabs[equipmentIndex].transform;
        if(image != null)
        {
            image.sprite = equipemtTex;
            equipmentTextures[equipmentIndex] = equipment;
            image.rectTransform.sizeDelta = new Vector2(newEquipemtTransform.GetComponent<Image>().rectTransform.rect.width / 2,
                newEquipemtTransform.GetComponent<Image>().rectTransform.rect.height / 2);
            equipment.transform.SetParent(newEquipemtTransform);
            image.rectTransform.localScale = new Vector3(1, 1, 1);
            image.rectTransform.localPosition = new Vector2(0, 0);
        }
        else
        {
            Debug.LogError("instanite equip texure fail");
        }
    }

    /// <summary>
    /// 装备被使用之后销毁装备栏里面的图层
    /// </summary>
    /// <param name="equipmentIndex">这个被删除装备的下标</param>
    public void RemoveEquipment(int equipmentIndex)
    {
        GameObject removeObject = equipmentTextures[equipmentIndex];
        Destroy(removeObject);
        equipmentTextures[equipmentIndex] = null;
    }

    /// <summary>
    /// 高亮装备
    /// </summary>
    /// <param name="highlightIndex">高亮装备栏下标</param>
    public void Highlight(int highlightIndex)
    {
        equipmentTabs[currentHiglight].GetComponent<Image>().color = Color.white;
        equipmentTabs[highlightIndex].GetComponent<Image>().color = Color.red;
        currentHiglight = highlightIndex;
    }
    public void SetEquipments(EquipmentInfoStruct[] list)
    {
        equipmentText.text = list.ToString();
    }
}
