using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int mainMenuIndex = 0;
    private int newColorScene = 1;
    private int stickerScroll = 2;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void LoadNewColorScene()
    {
        SceneManager.LoadScene(newColorScene);
    }

    public void LoadStickerScroll()
    {
        Debug.Log("Hello");
        SceneManager.LoadScene(stickerScroll);
    }

}
