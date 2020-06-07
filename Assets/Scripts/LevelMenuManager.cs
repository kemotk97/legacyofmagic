using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuManager : MonoBehaviour
{
    private AudioManager audioManager;
    public string HoverSound;
    public string ClickSound;
    private void Start()
    {

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No no");
        }
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void Level1()
    {
        SceneManager.LoadScene(3);
    }
    public void Level2()
    {
        SceneManager.LoadScene(4);
    }
    public void Level3()
    {
        SceneManager.LoadScene(5);
    }
    public void OnMouseOver()
    {
        audioManager.PlaySound(HoverSound);
    }
    public void OnClick()
    {
        audioManager.PlaySound(ClickSound);
    }
}
