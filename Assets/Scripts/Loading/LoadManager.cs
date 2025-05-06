using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager 
{
    private static LoadingPanelController loadingPanelController;
    public static SceneEnum loadSceneEnum;
    public static void LoadingScene(SceneEnum sceneName)
    {
        loadSceneEnum = sceneName;
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
                loadingPanelController.LoadScene(loadSceneEnum.ToString()); 
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
