using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float jumpForce;

    [Header("References")]
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private BoxCollider2D playerBoxCollider;

    private bool isGrounded = true;
    private int lives = 3;
    private bool isInvincable = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //playerRigidBody.linearVelocityY = 10;
            playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            playerAnimator.SetInteger("state", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                playerAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    void KillPlayer()
    {
        playerBoxCollider.enabled = false;
        playerAnimator.enabled = false;
        playerRigidBody.AddForceY(jumpForce, ForceMode2D.Impulse);
    }

    private void Hit()
    {
        lives -= 1;
        if (lives == 0) KillPlayer();
    }
    private void Heal()
    {
        lives = Mathf.Min(3, lives + 1);
    }

    private void StartInvincible()
    {
        isInvincable = true;
        Invoke("StopInvincible", 5f);
    }
    private void StopInvincible()
    {
        isInvincable = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if(!isInvincable) Destroy(collision.gameObject);
            Hit();
        }
        else if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Heal();
        }
        else if (collision.gameObject.tag == "golden")
        {
            Destroy(collision.gameObject);
            StartInvincible();
        }
    }

}
