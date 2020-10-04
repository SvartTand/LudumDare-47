using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float rotForce;

    private float distToground;

    public DistanceJoint2D joint;
    public Rigidbody2D world;

    public float grappleRange;

    public Animator HamsterAnimation;
    public Transform Hamster;

    public LineRenderer LineRenderer;
    public Vector3[] LineList;

    public int maxBoosts = 3;
    private int boosts;
    public float boostTimer = 3;
    private float timer = 0;

    public Text boostText;

    // Start is called before the first frame update
    void Start()
    {
        distToground = gameObject.GetComponent<Collider2D>().bounds.extents.y*2;
        Debug.Log(gameObject.GetComponent<Collider2D>().bounds.extents.y);
        LineList = new Vector3[2];
        LineRenderer.SetPositions(LineList);
        boosts = maxBoosts;
    }

    // Update is called once per frame
    void Update()
    {
        Hamster.transform.position = transform.position;
        //joint.anchor = transform.position;
        if(boosts < maxBoosts)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                boosts++;
                timer = boostTimer;
            }

            boostText.text = "Boosts: \n" + boosts +  "/" + maxBoosts + "\n" + timer.ToString("0.0");

        }
        

        if(Input.GetAxis("Horizontal") > 0)
        {
            HamsterAnimation.Play("HamsterRun");
            Hamster.transform.localScale = new Vector3(-1, 1, 1);

        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            HamsterAnimation.Play("HamsterRun");
            Hamster.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            HamsterAnimation.Play("HamsterIdle");
        }

        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotForce));
            rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * rotForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && boosts > 0)
        {
            boosts--;
            if (Hamster.transform.localScale.x <= 0)
            {
                rb.AddForce(Vector2.right * jumpForce);
            }
            else
            {
                rb.AddForce(Vector2.left * jumpForce);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //Debug.Log(mousePos2D);
            joint.connectedBody = world;
            joint.connectedAnchor = mousePos2D;
            


            LineList[0] = transform.position;

            LineList[1] = new Vector3(joint.connectedAnchor.x, joint.connectedAnchor.y, 0);
            LineRenderer.gameObject.active = true;
            LineRenderer.SetPositions(LineList);

            Debug.Log(joint.connectedAnchor.y + ", " + mousePos2D.y + ", " + LineList[1].y);


        }

        if (Input.GetMouseButton(0))
        {
            LineList[0] = transform.position;
            LineRenderer.SetPositions(LineList);

        }

        if (Input.GetMouseButtonUp(0))
        {
            joint.connectedBody = rb;
            LineRenderer.gameObject.active = false;
        }

        


    }

    private bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distToground);
        

        //Debug.Log(hit.collider.tag);

        return Physics2D.Raycast(transform.position, -Vector2.up, distToground);
    }


    public void UpdateLine()
    {
        

    }
}
