using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class LightingImpl : MonoBehaviour,IEquipmentPerb
{
    private Rigidbody2D rb;
   
    /// <summary>
    /// ��ʼ������λ�ú�Ͷ������
    /// </summary>
    /// <param name="playerTransform">��ɫ����</param>
    public void Init(Transform playerTransform)
    {
        transform.position = playerTransform.position;
        rb.velocity = playerTransform.GetComponent<Rigidbody2D>().velocity;
        Vector3 mousePotion = Mouse.current.position.ReadValue();
        if (mousePotion == null)
        {
            rb.AddForce(new Vector2(1,0) * EquipConstantsManager.EQUIP_THROW_FORCE, ForceMode2D.Impulse);
        }
 
        rb.AddForce(new Vector2(mousePotion.x, mousePotion.y).normalized * EquipConstantsManager.EQUIP_THROW_FORCE, ForceMode2D.Impulse);

    }

    /// <summary>
    /// ����ʹ�þ���ʵ��
    /// </summary>
    /// <param name="playerTransform">��ɫ����</param>
    /// <returns>���ص���ʹ�õ�Э��</returns>
    public IEnumerator Use(Transform playerTransform)
    {
        Init(playerTransform);
        Debug.Log("use");
        // ���� Light2D ���
       
        yield return new WaitForSeconds(EquipConstantsManager.LIGHTING_EXIT_TIME);
        GameObject light;
        AssetsManager.instance.equipLightingPreb1.InstantiateAsync(transform.position,new Quaternion()).Completed += (obj) =>{
            light = obj.Result;
             if(light == null)
            {
                Debug.LogError("the equipment light preb not found");
            }
  
        };     
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
