
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rbody;
    private bool isGrounded = true;
    private bool iswind = false;
    private bool inWindArea = false;
    private Vector2 velocity;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 8.0f;
    public float jumpForce = 14.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rbody.linearVelocity;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = moveSpeed;
            spriteRenderer.flipX = false; // 右向き
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -moveSpeed;
            spriteRenderer.flipX = true;  // 左向き
        }
        else
        {
            velocity.x = 0;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = jumpForce;
            isGrounded = false;
        }
        //if (iswind && Input.GetKeyDown(KeyCode.A))
        //{    
        //  wind();
        //}
        //風の能力
        if (iswind)
        {
            if (inWindArea)
            {
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow))
                {
                    velocity.x = moveSpeed + 10;
                }
                if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow))
                {
                    velocity.x = -moveSpeed + 5;
                }
            }
        }


        rbody.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        //風のアイテムをとった時
        if (collision.gameObject.tag == "WindItem")
        {
            iswind = true;
            Destroy(collision.gameObject);
        }
        //リスポーンについて
        if (collision.gameObject.tag == "DeathZone")
        {
            transform.position = new Vector3(-10.0f, 0.5f, 0.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wind")
        {
            inWindArea = true;
            Debug.Log("風のエリアに入りました");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Wind"))
        {
            inWindArea = false;
            Debug.Log("風のエリアを出ました");
        }
    }

    /*private void wind()
    {
        Debug.Log("アイテムをとりiswindになりました");
    }*/

}


/*private void HitEnemy(GameObject enemy)
{
    float HalfScaleY = transform.lossyScale.y / 2.0f;
    float enemyHalfScaleY = enemy.transform.lossyScale.y / 2.0f;
    if (transform.position.y - (enemyHalfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfScaleY - 0.1f))
    {
        Destroy(enemy);
    }
}*/

//}
