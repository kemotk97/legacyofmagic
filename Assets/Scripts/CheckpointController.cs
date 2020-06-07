using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    public Sprite checkpointState1;
    public Sprite checkpointState2;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
    public string checkpointSoundName;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = checkpointState2;
            checkpointReached = true;
            audioManager.PlaySound(checkpointSoundName);
        }
    }


}
