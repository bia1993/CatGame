using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower;
    public bool isGrounded;
    private bool facingRight = true;
    private float moveX;
    private Animator anim;
    public int health;
    public bool hasDied;

    void Start() {
        hasDied = false;
        anim = gameObject.GetComponent<Animator>();
    }

	void Update() {
        MovePlayer();
        CheckIfDead();
	}

    void OnCollisionEnter2D(Collision2D collider) {
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    void CheckIfDead() {
        if (gameObject.transform.position.y < -5) {
            Debug.Log("Oh no!");
            hasDied = true;
        }
        if (hasDied) {
            // SceneManager.LoadScene("CatScene");
            gameObject.transform.position = new Vector3(-2, -2, gameObject.transform.position.z);
            hasDied = false;
        }

    }

    void MovePlayer() {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }
        if (Input.GetButtonDown("Horizontal")) {
            anim.SetInteger("state", 1);
        }
        if (Input.GetButtonUp("Horizontal")) {
            anim.SetInteger("state", 0);
        }
        if (moveX < 0.0f && facingRight) {
            FlipPlayer();
        }
        else if (moveX > 0.0f && !facingRight) {
            
            FlipPlayer();
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer() {
        facingRight = !facingRight;
        var localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

//https://opengameart.org/content/24x32-characters-with-faces-big-pack
//Svetlana Kushnariova and give my email address, lana-chan@yandex.ru
//http://neoriceisgood.deviantart.com/art/100-furniture-sprites-405058884