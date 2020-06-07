using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private AudioManager audioManager;
    public string MenuMusicName;
    public string LevelMusicName;
    public string HoverSound;
    public string ClickSound;
    private void Start()
    {
        
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No no");
        }
        audioManager.StopSound(LevelMusicName);
        audioManager.PlaySound(MenuMusicName);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3);
        audioManager.StopSound(MenuMusicName);
    }
    public void SelectLevel()
    {
        SceneManager.LoadScene(2);
        audioManager.StopSound(MenuMusicName);
    }
    public void Credits()
    {
        SceneManager.LoadScene(1);
        audioManager.StopSound(MenuMusicName);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
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
