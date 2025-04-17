using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private static LoadingPanelController loadingPanelController;
    public static string loadSceneName;
    public static void LoadingScene(string sceneName)
    {
        loadSceneName = sceneName;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Loading");
    }
    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Loading")
        {
            GameObject panel = GameObject.FindWithTag("LoadingPanel");
            if (panel != null)
            {
                loadingPanelController = panel.GetComponent<LoadingPanelController>();
                loadingPanelController.LoadScene(loadSceneName); 
            }
            else
            {
                Debug.LogError("not found LoadingPanel");
            }
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        else
        {
            Debug.Log(scene.name);
        }
    }
}
