using System.Threading;
using UnityEngine;

public class Funcs : MonoBehaviour {

    //public static GameObject Sniper, AR, SMG, Grenade;

    public static void Wait(int secs)
    {
        Thread.Sleep(secs * 1000);
    }



}

public enum Items
{
    Sniper = 0, AR = 1, SMG = 2, Grenade = 3, Nothing = 4
}
