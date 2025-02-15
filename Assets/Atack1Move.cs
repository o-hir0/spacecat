using UnityEngine;

public class Atack1Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedX = -2.0f;
    public float speedY = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(speedX,speedY);
        Invoke("destroy", 3.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void destroy()
    {
        Destroy(gameObject);
    }
}
