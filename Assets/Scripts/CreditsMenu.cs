using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
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
    public void OnMouseOver()
    {
        audioManager.PlaySound(HoverSound);
    }
    public void OnClick()
    {
        audioManager.PlaySound(ClickSound);
    }
}
