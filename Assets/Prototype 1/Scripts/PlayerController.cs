using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator anim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public UIManager gameOverMenu;

    public float jumpForce;
    public float gravityModifier;

    private bool isOnGround = true;
    public bool gameOver = false;
    private bool isCrouched = false;

    public AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    BoxCollider boxCollider;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        gameOverMenu = GameObject.Find("Canvas").GetComponent<UIManager>();
        boxCollider = GetComponent<BoxCollider>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isCrouched)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (Input.GetKey(KeyCode.LeftControl) && isOnGround)
        {
            boxCollider.size = new Vector3(1, 1.5f, 1);
            boxCollider.center = new Vector3(0, 0.8f, 1);
            anim.SetBool("Crouch_b" , true);
            isCrouched = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl) && isCrouched)
        {
            boxCollider.size = new Vector3(1, 3, 1);
            boxCollider.center = new Vector3(0, 1.5f, 1);
            anim.SetBool("Crouch_b", false);
            isCrouched = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("Game Over");
            explosionParticle.Play();
            dirtParticle.Stop();
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOverMenu.deathMenu.SetActive(true);
        }
    }
}
