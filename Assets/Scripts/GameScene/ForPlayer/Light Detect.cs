using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 挂载在目标上的光照检测
/// 提供静态instance
/// </summary>
public class LightDetect : MonoBehaviour
{

    [Header("静态光照数组")]
    public Light2D[] lightSources;

    [Header("静态光照检查范围")]
    public float maxDistance = 10.0f;
    private Camera mainCamera;
    //public static LightDetect instance;
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
        //还原
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

                        // 只计算距离角色一定范围内的光源
                        if (distanceToLight <= maxDistance)
                        {

                            // 计算光照衰减
                            float attenuation = 1.0f - Mathf.Clamp01(distanceToLight / light.pointLightOuterRadius);

                            // 获取光照颜色和强度
                            float intensity = light.intensity * attenuation;

                            // 累加光照强度
                            totalIntensity += intensity;
                            //Debug.Log(light + ":" + totalIntensity.ToString());
                        }
                    }
                }

            }
        }
    }
}
