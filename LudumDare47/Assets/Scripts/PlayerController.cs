using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float rotForce;

    private float distToground;

    public SpringJoint2D joint;
    public Rigidbody2D world;

    public float grappleRange;

    public Animator HamsterAnimation;
    public Transform Hamster;

    public LineRenderer LineRenderer;
    public Vector3[] LineList;

    // Start is called before the first frame update
    void Start()
    {
        distToground = gameObject.GetComponent<Collider2D>().bounds.extents.y*2;
        Debug.Log(gameObject.GetComponent<Collider2D>().bounds.extents.y);
        LineList = new Vector3[2];
        LineRenderer.SetPositions(LineList);
    }

    // Update is called once per frame
    void Update()
    {
        Hamster.transform.position = transform.position;
        //joint.anchor = transform.position;

        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * rotForce, 0));

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
        rb.AddForce(new Vector2(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotForce));
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            //Debug.Log(mousePos2D);

            joint.connectedAnchor = mousePos2D;
            joint.connectedBody = world;


            LineList[0] = transform.position;

            LineList[1] = new Vector3(joint.connectedAnchor.x, joint.connectedAnchor.y, 0);
            LineRenderer.gameObject.active = true;
            LineRenderer.SetPositions(LineList);


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
