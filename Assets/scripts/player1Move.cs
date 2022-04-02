using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Move : MonoBehaviour
{
    float speed = 0.1f;
    bool isAttack;
    bool isJump;
    float jump=5f;

    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("player1"))
        {

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            bool moveToRight = Input.GetKey(KeyCode.RightArrow);
            bool moveToLeft = Input.GetKey(KeyCode.LeftArrow);
            float horizontal = Input.GetAxis("Horizontal") * speed;
            Animator animator = GetComponent<Animator>();

            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            if (moveToRight)
            {
                GetComponent<Transform>().Translate(new Vector3(speed, 0));
                spriteRenderer.flipX = false;
            }
            if (moveToLeft)
            {
                GetComponent<Transform>().Translate(new Vector3(-1 * speed, 0));
                spriteRenderer.flipX = true;
            }

            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            bool jumping = Input.GetKey(KeyCode.Space);
            if (jumping && isJump == false)
            {
                rigidbody2D.velocity = new Vector3(0, jump);
                animator.SetBool("IsJump", true);
                //GetComponent<Transform>().Translate(new Vector3(0,jump));
                isJump = true;
            }
            if (Mathf.Abs(rigidbody2D.velocity.y) > 0.01f)
            {
                animator.SetBool("IsJump", false);

                isJump = false;
            }

            bool up = Input.GetKey(KeyCode.UpArrow);
            if (up && !isAttack)
            {
                animator.SetBool("IsAttack", true);
                isAttack = true;
            }
            if (!up)
            {
                animator.SetBool("IsAttack", false);
                isAttack = false;
            }

        }
        
    }
}
