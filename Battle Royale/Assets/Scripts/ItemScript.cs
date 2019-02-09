using UnityEngine;
using System;

public class ItemScript : MonoBehaviour {

    Items item;
    public GameObject Sniper, AR, SMG, Grenade;

    void Start()
    {

        System.Random r = new System.Random();
        int itemthing = r.Next(0, 4);

        switch (itemthing)
        {
            case 0:
                item = Items.Sniper;
                break;
            case 1:
                item = Items.AR;
                break;
            case 2:
                item = Items.SMG;
                break;
            case 3:
                item = Items.Grenade;
                break;
        }

        //Debug.Log(item);

        initmodel();

    }

    void initmodel()
    {

        switch (item)
        {
            case Items.Sniper:
                Instantiate(Sniper,  transform);
                break;
            case Items.AR:
                Instantiate(AR, transform);
                break;
            case Items.SMG:
                Instantiate(SMG, transform);
                break;
            case Items.Grenade:
                Instantiate(Grenade, transform);
                break;
        }

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "MainPlayer")
        {
            Debug.Log(item);
            c.gameObject.GetComponent<PlayerScript>().initgun(item);
            Destroy(gameObject);
        }
    }


}
