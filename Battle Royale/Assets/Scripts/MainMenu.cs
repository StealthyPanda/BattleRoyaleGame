using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject CreditsThing, Main;
   

    public void quit()
    {
        Application.Quit();
    }

    public void start()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void credits()
    {
        CreditsThing.SetActive(true);
        Main.SetActive(false);
    }

    public void back()
    {
        CreditsThing.SetActive(false);
        Main.SetActive(true);
    }
	
}
