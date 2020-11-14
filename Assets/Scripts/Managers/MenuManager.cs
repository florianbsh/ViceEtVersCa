using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        GameManager.Instance.ChangeScene(GameManager.Instance.GameScene, false, true);
    }

    public void Quit()
    {
        GameManager.Instance.Quit();
    }
}
