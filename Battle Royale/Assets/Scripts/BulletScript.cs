using UnityEngine;

public class BulletScript : MonoBehaviour {

    public int damage = 0;
    

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag != "MainPlayer")
        {
            PlayerScript ps = c.gameObject.GetComponent<PlayerScript>();
            if (ps)
            {
                ps.health -= damage;
            }
            Destroy(gameObject);
        }
        
    }

}
