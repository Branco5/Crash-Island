using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float speed = 4;
    public Vector3 forward;
    public Vector3 right;
    public Animator anim;
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
        anim = Player.instance.GetComponent<Animator>();
    }

    void Update()
    {
        if(!Player.instance.isInteracting && 
        (Player.instance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle")
        ||  Player.instance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Run")) &&
        (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)))
        {
            Move();
            anim.SetBool("BoolRun", true);
        }
        else{
            anim.SetBool("BoolRun", false);
        }
    }

    void Move(){
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical"));
        Vector3 rightMove = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMove = forward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMove + upMove);
        transform.forward = heading;
        transform.position += rightMove;
        transform.position += upMove;
    }
}
