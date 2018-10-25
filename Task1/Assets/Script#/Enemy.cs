using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    private float dist;
    public GameObject bulletTarget;
    public GameObject player;

    public Animator enemy_anim;
    public bool bullet_hit;
    public GameObject target;
    float offset;

    public Text mDebugText;
    void Start()
    {


        offset = 5.0f;

        player = GameObject.FindWithTag("Player");
        StartCoroutine("hitBullet");




    }



    void Update()
    {


        if (!PlayerControl.Instance.GameOver)
        {

            dist = 0f;
            Vector3 trgPost = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
            enemy_anim.SetBool("isAttack", false);
            enemy_anim.SetBool("isRUN", false);
            dist = Vector3.Distance(transform.position, player.transform.position);
            mDebugText.text = " Distance" + dist;
            if (dist <= 11f && (PlayerControl.Instance.isGrounded))
            {


                transform.LookAt(trgPost);
                Debug.Log("Enter in range..  = " + "Distance = " + dist);


                if (dist > 5f)
                {
                    enemy_anim.SetBool("isAttack", false);
                    enemy_anim.SetBool("isRUN", true);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x - offset, player.transform.position.y, player.transform.position.z), Time.deltaTime);

                }
                else
                {

                    enemy_anim.SetBool("isRUN", false);
                    enemy_anim.SetBool("isAttack", true);

                }









            }

        }


    }
    public void SendMessageTest()
    {

        //	Debug.Log ("Sendmessage Test");

    }


    IEnumerator hitBullet()
    {
        yield return new WaitForSeconds(2);


        if (dist <= 8f)
        {
            GameObject targetSpawn = Instantiate(target, bulletTarget.transform.position, this.transform.rotation) as GameObject;




        }
        StartCoroutine("hitBullet");



    }
}
