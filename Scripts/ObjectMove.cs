using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public float minX, minY, maxX, maxY, speed;
    Vector2 targetPosition, newTargetOther, newTargetThis, m_dir;
    public Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        minX = transform.position.x - 2f;
        minY = transform.position.y - 2f;
        maxX = transform.position.x + 2f;
        maxY = transform.position.y + 2f;
        targetPosition = GetRandomPosition();
        //rig.velocity = new Vector2(targetPosition.x, targetPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
         if((Vector2)transform.position != targetPosition)
         {
             transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
         }
         else
         {
             targetPosition = GetRandomPosition();
         }
    }

    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }
    float GetRandomSpeed()
    {
        float speed  = Random.Range(0, 0.02f);
        return speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            newTargetOther = GetRandomPosition();
            newTargetThis = GetRandomPosition();
            other.transform.position = Vector2.MoveTowards(other.transform.position, newTargetOther, speed);
            transform.position = Vector2.MoveTowards(transform.position, newTargetThis, speed);
            targetPosition = newTargetOther;
            this.targetPosition = newTargetThis;
            Debug.Log("triggered with other");
        }
           /* Vector2 _obsNormal = other.contacts[0].normal;
            m_dir = Vector2.Reflect(rig.velocity, _obsNormal).normalized;
            rig.velocity = m_dir * speed;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Vector2 _wallNormal = other.contacts[0].normal;
            m_dir = Vector2.Reflect(rig.velocity, _wallNormal).normalized;
            rig.velocity = m_dir * speed;
        }*/
    }

    /*   void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Obstacle"))
       {
           /*newTargetOther = GetRandomPosition();
           newTargetThis = -newTargetOther;
           other.transform.position = Vector2.MoveTowards(other.transform.position, newTargetOther, speed);
           transform.position = Vector2.MoveTowards(transform.position, newTargetThis, speed);
           targetPosition = newTargetThis;

           Debug.Log("triggered with other");
           Vector2 _obsNormal = other.contacts[0].normal;
           m_dir = Vector2.Reflect(rig.velocity, _obsNormal).normalized;
           rig.velocity = m_dir * speed;
       }
       if (other.gameObject.CompareTag("Wall"))
       {
           Vector2 _wallNormal = other.contacts[0].normal;
           m_dir = Vector2.Reflect(rig.velocity, _wallNormal).normalized;
           rig.velocity = m_dir * speed;
       }

   }*/

}