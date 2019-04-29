using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Audio;
public class Player : MonoBehaviour
{
    // variable to hold a reference to our SpriteRenderer component
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public AudioSource sound;
    public AudioClip boing;
    // public CharacterController controller;
    
    public float speed = 40f;
    

    private bool jump = false;
    public float jumpSpeed = 5f;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();

    }

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
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,jumpSpeed);
            jump = true;
            sound.PlayOneShot(boing, PlayerPrefs.GetFloat("SFXVol"));
            
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "grass")
        {
            jump = false;
        }
        else if (collision.gameObject.name == "Snake")
        {
            Destroy(gameObject);
        }
    }
}
