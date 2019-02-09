using System;
using System.Threading;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{

    //Add this script onto the actual grenade thrown
    //public GameObject explosion;
    public int rad = 3, force = 5, damage = 60;
    
    public int delay;

    bool hmm = false;
    void Start()
    {
        Thread t = new Thread(new ThreadStart(Countdown)); t.Start();
    }

    void Update()
    {
        if (hmm)
        {
            explode();
        }
    }

    void Countdown()
    {
        Thread.Sleep(delay * 1000);
        hmm = true;
    }

    void explode()
    {
        //Instantiate(explosion, transform.position, transform.rotation);
        Debug.Log("EXPLOSION!");


        Collider[] colliders = Physics.OverlapSphere(transform.position, rad);

        foreach (Collider c in colliders)
        {
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = c.gameObject.transform.position - transform.position;
            if (rb)
            {
                rb.AddForce((direction).normalized * force, ForceMode.Impulse);
            }
            PlayerScript ps = c.gameObject.GetComponent<PlayerScript>();
            if (ps)
            {
                ps.health -= damage/direction.magnitude;
            }
        }

        
        Destroy(gameObject);
    }



}
