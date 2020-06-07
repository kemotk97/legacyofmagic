using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private enum State { idle, running, jumping, falling }
    private State state = State.idle;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private AudioManager audioManager;
    public string jumpSoundName; 
    public string musicName;
    public string failSoundName;


    public Vector3 respawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;

        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.LogError("No no");
        }
        audioManager.PlaySound(musicName);
    }


    private void Update()
    {
        ControlInput();
        AnimationState();
        anim.SetInteger("state", (int)state);
    }

    private void ControlInput()
    {
        float hDirection = Input.GetAxis("Horizontal");

        if (hDirection < 0f)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (hDirection > 0f)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            state = State.jumping;
            audioManager.PlaySound(jumpSoundName);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            audioManager.PlaySound(failSoundName);
        }
        if (other.tag == "Checkpoint")
        {
            
            respawnPoint = other.transform.position;
        }
    }


    private void AnimationState()
    {
        if(state ==State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }

    }
}
