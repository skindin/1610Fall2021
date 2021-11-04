using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigBod;
    Animator animator;
    AudioSource audSrc;
    public ParticleSystem explosionPrtcl;
    public ParticleSystem dirtPrtcl;
    public AudioClip bonk;
    public AudioClip boing;
    public float jumpForce = 100;
    public float gravity = 1;
    bool onGround = true;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audSrc = GetComponent<AudioSource>();
        Physics.gravity *= gravity;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Game.state == gameState.inGame)
            {
                if (onGround)
                {
                    Jump();
                }
            }
            else
            {
                var scene = SceneManager.GetActiveScene();
                SceneManager.SetActiveScene(scene);
            }
        }
    }

    void Jump()
    {
        rigBod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        onGround = false;
        animator.SetTrigger("Jump_trig");
        dirtPrtcl.Stop();
        audSrc.PlayOneShot(boing);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            onGround = true;
            dirtPrtcl.Play();
        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            //Time.timeScale = 0;
            Game.SetState(gameState.endGame);
            animator.SetBool("Death_b", true);
            audSrc.PlayOneShot(bonk);
            explosionPrtcl.Play();
            dirtPrtcl.Stop();
        }
    }
}
