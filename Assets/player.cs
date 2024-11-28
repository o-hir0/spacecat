using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody;

    public float speedx = 10f;
    public float jumpforce = 30f;

    private bool isgrounded = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rbody.linearVelocity;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -speedx;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = speedx;
        }
        else
        {
            velocity.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = jumpforce;
            isgrounded = false;
        }


        rbody.linearVelocity = velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            HitEnemy(collision.gameObject);
        }

    }

    private void HitEnemy(GameObject enemy)
    {
        float HalfScaleY = transform.lossyScale.y / 2.0f;
        float enemyHalfScaleY = enemy.transform.lossyScale.y / 2.0f;
        if (transform.position.y - (enemyHalfScaleY - 0.1f) >= enemy.transform.position.y + (enemyHalfScaleY - 0.1f))
        {
            Destroy(enemy);
        }
    }

}
