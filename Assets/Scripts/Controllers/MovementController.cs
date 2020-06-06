
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;

    private Vector3 move;

    [SerializeField] private GameObject playerPanel;



    // Start is called before the first frame update
    private void Start()
    {
       

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
  

    }

    private void Update()
    {
        move = Vector3.zero;
        if (playerPanel.activeSelf)
            return;

        PollKeys();
        PollMouse();
      

    }



    private void PollMouse()
    {

    }

    private void PollKeys()
    {



        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move.Normalize();
        UpdateAnimations();
    

    }

    private void UpdateAnimations()
    {
        if (move != Vector3.zero)
        {


            Move();

            anim.SetBool("moving", true);
            anim.SetFloat("moveX", move.x);
            anim.SetFloat("moveY", move.y);
            if (move.x > 0 && !facingRight)
                Flip();
            else if (move.x < 0 && facingRight)
                Flip();


        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scl = transform.localScale;
        scl.x *= -1;
        transform.localScale = scl;

    }
    private void Move()
    {
        rb.MovePosition(transform.position + move * speed * Time.fixedDeltaTime);
  
    }

    
}