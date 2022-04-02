using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Move : MonoBehaviour
{
    float player2Speed = 0.1f;
    private bool playerIsAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerIsAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("player2"))
        {
            SpriteRenderer sR = GetComponent<SpriteRenderer>();
            bool player2MoveToRight = Input.GetKey(KeyCode.D);
            bool player2MoveToLeft = Input.GetKey(KeyCode.A);
            float horizontalAxis = Input.GetAxis("Horizontal") * player2Speed;
            Animator anim = GetComponent<Animator>();

            anim.SetFloat("PlayerSpeed", Mathf.Abs(horizontalAxis));
            if (player2MoveToRight)
            {
                GetComponent<Transform>().Translate(new Vector3(player2Speed, 0));
                sR.flipX = false;
            }
            if (player2MoveToLeft)
            {
                GetComponent<Transform>().Translate(new Vector3(-1 * player2Speed, 0));
                sR.flipX = true;
            }

            bool attack = Input.GetKey(KeyCode.W);
            if (attack && !playerIsAttack)
            {
                anim.SetBool("PlayerIsAttack", true);
                playerIsAttack = true;
            }
            if (!attack)
            {
                anim.SetBool("PlayerIsAttack", false);
                playerIsAttack = false;
            }
        }

        
    }
}
