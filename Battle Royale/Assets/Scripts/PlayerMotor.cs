using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    Vector3 direction;
    float xrot, yrot;
    public float speed = 3f;
    Rigidbody rb;
    public Camera cam;

    
    public void UpdateX(float newx)
    {
        xrot = newx;
    }

    public void UpdateY(float newy)
    {
        yrot = newy;
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public void UpdateDirection(Vector3 newdir)
    {
        direction = ((transform.right * newdir.x) + (transform.forward * newdir.z)) * speed;
    }

    

    void Update()
    {

        rb.MovePosition(transform.position + direction * Time.deltaTime);
        gameObject.GetComponent<Rigidbody>().MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, yrot, 0)));
        cam.transform.Rotate(Vector3.right, -xrot);

    }

    

}
