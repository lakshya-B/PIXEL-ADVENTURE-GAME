using UnityEngine;

public class PlayerMmts : MonoBehaviour
{ 
    private Rigidbody2D rd;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float walkVelocity;
    [SerializeField] private LayerMask jumpGround;
    private float dirX;
    private enum movements { idle , run , jump , fall};
    [SerializeField] private AudioSource jumpSoundEffect;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rd.velocity = new Vector2(dirX * walkVelocity, rd.velocity.y);


        updateAnimation();

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rd.velocity = new Vector2(rd.velocity.x,jumpVelocity);
            jumpSoundEffect.Play();
        }
    }

    private void updateAnimation()
    {
        movements state;

        if (dirX > 0f)
        {
            state = movements.run;
            sprite.flipX = false;
        }

        else if (dirX < 0f)
        {
            state = movements.run;
            sprite.flipX = true;
        }

        else
        {
            state = movements.idle;
        }

        if(rd.velocity.y > .1f)
        {
            state = movements.jump;
        }

        else if(rd.velocity.y < -.1f)
        {
            state = movements.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
