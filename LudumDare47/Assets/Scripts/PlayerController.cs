using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float jumpForce;
    public float rotForce;

    private float distToground;

    

    // Start is called before the first frame update
    void Start()
    {
        distToground = gameObject.GetComponent<Collider2D>().bounds.extents.y*2;
        Debug.Log(gameObject.GetComponent<Collider2D>().bounds.extents.y);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * rotForce, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotForce));

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
        
    }

    private bool IsGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distToground);
        

        Debug.Log(hit.collider.tag);

        return Physics2D.Raycast(transform.position, -Vector2.up, distToground);
    }
}
