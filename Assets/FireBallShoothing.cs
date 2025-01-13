using UnityEngine;

public class FireBallShoothing : MonoBehaviour
{
    public GameObject FireBallRight;
    public GameObject FireBallLeft;
    private bool isFire = false;
    private bool isRight = true;
    private bool isLeft = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionRight = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        Vector3 positionLeft = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
        if (isFire)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isRight = true;
                isLeft = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isLeft = true;
                isRight = false;
            }
            if (isRight)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Instantiate(FireBallRight, positionRight, Quaternion.identity);
                }
            }
            if (isLeft)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Instantiate(FireBallLeft, positionLeft, Quaternion.identity);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireItem")
        {
            isFire = true;
            Destroy(collision.gameObject);
        }
    }
}
