using System.Threading;
using UnityEngine;

public class ScriptRunnerScript : MonoBehaviour {

    public Thread t;
    public GameObject item;
    public int lx, lz, mx, mz;
    System.Random r = new System.Random();

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        int rand = r.Next(0, 2000);
        //Debug.Log(rand);
        //Funcs.Wait(5);
        if (rand % 559 == 0) Instantiate(item, new Vector3(r.Next(lx, mx + 1), 1.5f, r.Next(lz, mz + 1)), Quaternion.Euler(new Vector3(-90, 0, 0)));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
}
