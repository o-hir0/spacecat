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
        Vector3 positionLeft = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        if (shooting)
        {
            Instantiate(AtackLeft);
            Instantiate(AtackLeftUp);
            Instantiate(AtackLeftDown);
            shooting = false;
            Invoke("ShootingOn",5.0f);
        }
    }
    
    private void ShootingOn()
    {
        shooting=true;
    } 
}
