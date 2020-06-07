using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    [SerializeField] private int sceneNumber;
    [SerializeField] private GameObject EndMenuUI;
    public string levelCompleteSoundName;
    private AudioManager audioManager;



    private void OnTriggerEnter2D(Collider2D collision)
        
    {
        audioManager = AudioManager.instance;
        if (collision.gameObject.tag == "Player")
        {
            EndMenuUI.SetActive(true);
            audioManager.PlaySound(levelCompleteSoundName);
        }
    }
}
