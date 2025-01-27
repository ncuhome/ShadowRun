using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingImpl : MonoBehaviour,IEquipmentPerb
{
    private Rigidbody2D rb;
   
    /// <summary>
    /// 初始化道具位置和投掷方向
    /// </summary>
    /// <param name="playerTransform">角色坐标</param>
    public void Init(Transform playerTransform)
    {
        transform.position = playerTransform.position;
        Vector3 mousePotion = Input.mousePosition;
        if(mousePotion == null)
        {
            rb.AddForce(new Vector2(1,0) * Constants.EQUIP_THROW_FORCE, ForceMode2D.Impulse);
        }
 
        rb.AddForce(new Vector2(mousePotion.x, mousePotion.y).normalized * Constants.EQUIP_THROW_FORCE, ForceMode2D.Impulse);

    }

    /// <summary>
    /// 道具使用具体实现
    /// </summary>
    /// <param name="playerTransform">角色坐标</param>
    /// <returns>返回道具使用的协程</returns>
    public IEnumerator Use(Transform playerTransform)
    {
        Init(playerTransform);
        Debug.Log("use");
        // 添加 Light2D 组件
       
        yield return new WaitForSeconds(Constants.LIGHTING_EXIT_TIME);
        //实例化预制体2d光照
        GameObject light = Instantiate(Resources.Load<GameObject>(Constants.LightingEquipName));
        if(light == null)
        {
            Debug.LogError("the equipment light preb not found");
        }
        else
        {
            light.transform.position = transform.position;
        }
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
