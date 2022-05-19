using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    Rigidbody2D rigidbody2D;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    int action = 0;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        speed = 1.0f;
        animator = GetComponent<Animator>();
    }

    void Update() {
        timer -= Time.deltaTime; // decrement timer

        if (timer < 0) {

            /* makes enemy go in a plus motion */
            // if (action == 0 || action == 2) {
            //     direction = -direction; // change direction
            // } if (action == 3) {
            //     vertical = !vertical; // change axis
            // }
            // action = (action + 1) % 4;


            direction = -direction;
            timer = changeTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 pos = rigidbody2D.position;

        if (vertical) {
            pos.y = pos.y + Time.deltaTime * speed * direction;
        } else {
            pos.x = pos.x + Time.deltaTime * speed * direction;
            animator.SetFloat("MoveX", direction);
        }

        rigidbody2D.MovePosition(pos);
    }

    /* damage player on collision */
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("collision");
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
