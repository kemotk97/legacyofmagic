using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    private AudioManager audioManager;
    public string HoverSound;
    public string ClickSound;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if(isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }
    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        AudioListener.pause = false;
        isPaused = false;
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
