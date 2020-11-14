using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string baseScene = "BaseScene";
    [SerializeField] private string menuScene = "Menu";
    [SerializeField] private string gameScene = "GameScene";

    private string BaseScene { get { return baseScene; } }
    public string MenuScene { get { return menuScene; } }
    public string GameScene { get { return gameScene; } }

    private string CurrentGameScene { get; set; } = "";

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        ChangeScene(MenuScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName, bool keepGameScene = false, bool isGameScene = false)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName, keepGameScene, isGameScene));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName, bool keepGameScene = false, bool isGameScene = false)
    {
        if (!keepGameScene)
        {
            if (isGameScene)
            {
                CurrentGameScene = sceneName;
            }
            else
            {
                CurrentGameScene = "";
            }
        }

        StartCoroutine(LoadScene(sceneName));
        StartCoroutine(UnloadScenes(sceneName, keepGameScene, isGameScene));

        /*
        if (isGameScene)
        {
            StartCoroutine(LoadScene(overlayScene, false));
        }*/

        yield return null;
    }

    private IEnumerator UnloadScenes(string nextSceneName, bool keepGameScene = false, bool isGameScene = false)
    {
        List<AsyncOperation> operations = new List<AsyncOperation>();

        for (int i = 0; i < SceneManager.sceneCount; ++i)
        {
            if (SceneManager.GetSceneAt(i).name == BaseScene ||
                SceneManager.GetSceneAt(i).name == nextSceneName ||
                (keepGameScene && SceneManager.GetSceneAt(i).name == CurrentGameScene))
            {
                continue;
            }
            else
            {
                operations.Add(SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i)));
            }
        }

        foreach (AsyncOperation operation in operations)
        {
            while (!operation.isDone)
            {
                yield return null;
            }
        }
    }

    private IEnumerator LoadScene(string sceneName, bool setNewSceneActive = true)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            AsyncOperation newSceneLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

            while (!newSceneLoad.isDone)
            {
                yield return null;
            }

            newSceneLoad.allowSceneActivation = true;
        }

        if (setNewSceneActive)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        }
    }

}
