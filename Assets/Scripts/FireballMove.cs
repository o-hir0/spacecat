using UnityEngine;

public class FireballMove : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = speed;

        Invoke("destroy", 3.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag != "Ground")
        {
            Destroy(gameObject);
        }

    }
    private void destroy()
    {
        Destroy(gameObject);
    }
}
