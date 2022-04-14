using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    private Rigidbody2D rbody;
    public GameObject player;
    private bool onTheLadder = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onTheLadder)
        {
            transform.rotation = Quaternion.identity;
            float directionX = Input.GetAxis("Horizontal");
            rbody.velocity = new Vector2(directionX * 2f, -2f);

            if (Input.GetKey(KeyCode.W))
            {
                rbody.velocity = new Vector3(directionX * 2f, 2f, 0);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rbody.velocity = new Vector3(directionX * 2f, 0, 0);
                rbody.gravityScale = 0;
                rbody.mass = 0;
            }
            rbody.gravityScale = 1;
            rbody.mass = 2;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        onTheLadder = true;
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        onTheLadder = false;
    }
}
