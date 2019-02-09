using UnityEngine;

public class GrenadeInHandScript : MonoBehaviour
{

    public GameObject GrenadeToBeThrown;
    public Camera cam;


    public int ammo = 3, force = 3;

    void Start()
    {
    }

    void Update()
    {
        cam = GetComponentInParent<Camera>();
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (ammo > 0)
            {
                ammo--;
                if (ammo <= 0) Destroy(gameObject);
                GameObject insta = Instantiate(GrenadeToBeThrown, cam.transform.position + (cam.transform.forward * 1), new Quaternion(-90, 0, 0, 0));
                insta.GetComponent<Rigidbody>().AddForce((cam.transform.rotation * Vector3.forward) * force, ForceMode.VelocityChange);
            }
        }

        

    }


}
