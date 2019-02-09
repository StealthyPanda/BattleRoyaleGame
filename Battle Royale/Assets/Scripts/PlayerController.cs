using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

   
    public float mousesensitivity = 3f;

    

    void FixedUpdate()
    {
        float xmove = Input.GetAxisRaw("Horizontal");
        float zmove = Input.GetAxisRaw("Vertical");

        Vector3 totalmove = new Vector3(xmove, 0f, zmove).normalized;

        float yrot = Input.GetAxisRaw("Mouse X");
        float xrot = Input.GetAxisRaw("Mouse Y");


        GetComponent<PlayerMotor>().UpdateX(xrot * mousesensitivity);

        GetComponent<PlayerMotor>().UpdateY(yrot * mousesensitivity);


       
        GetComponent<PlayerMotor>().UpdateDirection(totalmove);
       

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<PlayerScript>().Fire();
        }
    }
}
