using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class Player : MonoBehaviour
{
    // variable to hold a reference to our SpriteRenderer component
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    // public CharacterController controller;

    public float speed = 40f;

    private float horizonalMove = 0f;
    private bool jump = false;

    // Update is called once per frame
    void Update()
    {
       
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        
        
       
        
        if (Input.GetKey("right") )
        {
            spriteRenderer.flipX = false;
            animator.SetBool("OnClick", true);
            transform.position += transform.right * Time.deltaTime * 1 * 2;
            Debug.Log(xAxis);
        }
        else if (Input.GetKey("left"))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("OnClick", true);
            transform.position += transform.right * Time.deltaTime * -1 * 2;

        }
        else
        {
            animator.SetBool("OnClick", false);
        }
        


        Vector3 pos = transform.position;
      
       
        

    

        if (Input.GetAxis("Jump") == 1 && !jump )
        {
            transform.position += Vector3.up * 1;
            jump = true;
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Floor")
        {
            jump = false;
        }
        else if (collision.gameObject.name == "Snake")
        {
            Destroy(gameObject);
        }
    }
}
