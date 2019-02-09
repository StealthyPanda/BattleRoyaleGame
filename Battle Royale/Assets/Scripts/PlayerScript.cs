using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {


    public GameObject cam, bullet;
    public GameObject Sniper, AR, SMG, Grenade;
    Items in_hand = Items.Nothing;
    public float health = 100; public int SpeedOfBullet = 20;
    private GameObject inventory;
    private bool hmm = true;

    public List<Behaviour> compstodisable;

    void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (Behaviour c in compstodisable)
            {
                c.enabled = false;
            }
        }

        inventory = null;
    }

    public void initgun(Items item)
    {
        
        if (inventory != null)
        {
            Destroy(inventory);
        }
        in_hand = item;
        switch (item)
        {
            case Items.Sniper:
                inventory = Instantiate(Sniper, cam.transform);
                break;
            case Items.AR:
                inventory = Instantiate(AR, cam.transform);
                break;
            case Items.SMG:
                inventory = Instantiate(SMG, cam.transform);
                break;
            case Items.Grenade:
                inventory = Instantiate(Grenade, cam.transform);
                break;
            default:
                break;
        }
    }

    public void Fire()
    {
        if (in_hand != Items.Nothing && in_hand != Items.Grenade)
        {

            GameObject insta = Instantiate(bullet, transform.position, transform.rotation);
            switch (in_hand)
            {
                case Items.Sniper:

                    if (hmm)
                    {
                        hmm = false;
                        insta.GetComponent<BulletScript>().damage = 45;
                        Thread t = new Thread(new ThreadStart(fired)); t.Start();
                    }

                    break;
                case Items.AR:
                    insta.GetComponent<BulletScript>().damage = 20;
                    break;
                case Items.SMG:
                    insta.GetComponent<BulletScript>().damage = 10;
                    break;
                case Items.Grenade:
                    break;
                default:
                    break;
            }

            Rigidbody rb = insta.GetComponent<Rigidbody>();
            rb.AddForce((cam.transform.rotation * Vector3.forward) * SpeedOfBullet, ForceMode.VelocityChange);

        }
    }


    void fired()
    {
        Thread.Sleep(5000);
        hmm = true;

    }
    
	
}
