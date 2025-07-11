using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// ������Ŀ���ϵĹ��ռ��
/// �ṩ��̬instance
/// </summary>
public class LightDetect : MonoBehaviour
{

    [Header("��̬��������")]
    public Light2D[] lightSources;
    [Header("��̬���ռ�鷶Χ")]
    public float maxDistance = 20.0f;
    private Camera mainCamera;
    private static LightDetect _instance;
    public static LightDetect instance { get { 
            if(!_instance)
            {
                _instance = GameObject.FindAnyObjectByType<LightDetect>();
                if (!_instance) Debug.LogError("no active LightDetect");
            }
            return _instance;
        } }
    private SpriteRenderer targetRenderer;
    private List<Light2D> moveLights;
    [HideInInspector] public static float totalIntensity;

    void Awake()
    {
        targetRenderer = GetComponent<SpriteRenderer>();
        totalIntensity = 0.0f;
        moveLights = new List<Light2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        GetLightingIntense();
    }

    private bool IsWithinViewport(Light2D light, Rect viewportBounds)
    {
        Vector3 lightPosition = light.transform.position;
        return viewportBounds.Contains(lightPosition);
    }

    Rect GetViewportBounds(Camera camera)
    {
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        return new Rect(bottomLeft, topRight - bottomLeft);
    }


    private void GetMoveLightIntense()
    {
        GameObject[] allLightObjects = GameObject.FindGameObjectsWithTag("MoveLightSource");
        moveLights.Clear();
        foreach (GameObject lightObj in allLightObjects)
        {
            Light2D light = lightObj.GetComponent<Light2D>();          
            if (light != null)
            {
                if (IsWithinViewport(light, GetViewportBounds(mainCamera)))
                {
                    moveLights.Add(light);                   
                }
            }
        }


    }

    private void GetLightingIntense()
    {
        //��ԭ
        totalIntensity = 0f;
        GetMoveLightIntense();
        Light2D[] allLight = lightSources.Concat(moveLights.ToArray()).ToArray();
        if (targetRenderer != null && lightSources != null)
        {
            Material material = targetRenderer.material;
            if (material != null)
            {
                Vector3 position = targetRenderer.bounds.center;

                foreach (Light2D light in allLight)
                {
                    if (light != null)
                    {
                        Vector3 lightPosition = light.transform.position;
                        Vector3 directionToLight = lightPosition - position;
                        float distanceToLight = directionToLight.magnitude;
                        if (distanceToLight <= maxDistance)
                        {

                            // 光照衰减
                            float outerRadius;
                            if (light.lightType == Light2D.LightType.Sprite)
                            {
                                outerRadius = light.transform.lossyScale.x;
                                //Debug.Log("outerRadius:" + outerRadius);
                            }
                            else
                            {
                                outerRadius = light.pointLightOuterRadius;
                            }
                            float attenuation = 1.0f - Mathf.Clamp01(distanceToLight / outerRadius);
                            float intensity = light.intensity * attenuation;
                            totalIntensity += intensity;
                            //Debug.Log(light + ":" + totalIntensity.ToString());
                        }
                    }
                }

            }
        }
    }
}
