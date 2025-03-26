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
        // ��� Light2D ���
       
        yield return new WaitForSeconds(EquipConstantsManager.LIGHTING_EXIT_TIME);
        //ʵ����Ԥ����2d����
        GameObject light = AssetsManager.instance.equipmentlightingPreb;
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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
