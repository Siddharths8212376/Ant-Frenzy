using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed;
    Vector2 zero = new Vector2(0, 0);
    public float speed_lim = 1.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(RandomVector(-speed_lim,speed_lim)*speed);
        //rb.velocity = RandomVector(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {   
        if(rb.velocity == zero)
        {
            rb.AddForce(RandomVector(-speed_lim, speed_lim) * speed);
        }


        /*
         * // get a random direction to move towards
        if (rb.position.x <= -7 || rb.position.x > 7)
        {
            Vector2 vel = new Vector2(rb.velocity.x, rb.velocity.y);
            vel.x = -vel.x;

            rb.velocity = new Vector2(vel.x, vel.y);
        }
        if (rb.position.y <= -3 || rb.position.y > 3)
        {
            Vector2 vel = new Vector2(rb.velocity.x, rb.velocity.y);
            vel.y = -vel.y;

            rb.velocity = new Vector2(vel.x, vel.y);
        }
        */


    }
    private Vector2 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);

        return new Vector2(x, y);


    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Vector2 vel = new Vector2(rb.velocity.x, rb.velocity.y);
            vel.y = -vel.y;
            vel.x = -vel.x;
            // rb.velocity = new Vector2(vel.x , vel.y);
            rb.velocity = RandomVector(-2f, 2f);
        }
    }*/
}
