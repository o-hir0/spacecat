using UnityEngine;


public class FloorMove : MonoBehaviour
{
    private bool up = true;
    private float reading = 1.0f;
    private Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (reading == 1.0f)
        {
            position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Debug.Log((position.y - 1.5f));
            reading++;
        }

        if ((transform.position.y <= (position.y + 1.5f)) && up == true)
        {
            transform.Translate(0, 3 * Time.deltaTime, 0);
        }
        else if (transform.position.y > (position.y + 1.5f))
        {
            up = false;
        }
        if ((transform.position.y >= (position.y - 1.5f)) && up == false)
        {
            transform.Translate(0, -3 * Time.deltaTime, 0);
        }
        else if (transform.position.y < (position.y - 1.5f))
        {
            up = true;
        }


    }
}
 