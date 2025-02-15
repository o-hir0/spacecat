using UnityEngine;

public class AtackShooting : MonoBehaviour
{
    private bool  shooting=true;
    public GameObject AtackLeft;
    public GameObject AtackLeftUp;
    public GameObject AtackLeftDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionLeft = new Vector3(transform.position.x - 8, transform.position.y, transform.position.z);
        Vector3 positionLeftUp = new Vector3(transform.position.x - 8, transform.position.y+5, transform.position.z);
        Vector3 positionLeftDown = new Vector3(transform.position.x - 8, transform.position.y-5, transform.position.z);
        if (shooting)
        {
            Instantiate(AtackLeft, positionLeft, Quaternion.identity);
            Instantiate(AtackLeftUp, positionLeftUp, Quaternion.identity);
            Instantiate(AtackLeftDown, positionLeftDown, Quaternion.identity);
            shooting = false;
            Invoke("ShootingOn",5.0f);
        }
    }
    
    private void ShootingOn()
    {
        shooting=true;
    } 
}
