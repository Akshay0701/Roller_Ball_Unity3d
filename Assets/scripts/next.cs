using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class next : MonoBehaviour {
  

    public void level1()
    {
        wait();
        SceneManager.LoadScene("level1");

    }
    public void level2()
    {
        
        SceneManager.LoadScene("level2");
    }
    public void level3()
    {
        
        SceneManager.LoadScene("level3");
    }

    public void level4()
    {
   
        SceneManager.LoadScene("level4");
    }
    public void menu()
    {
        
        SceneManager.LoadScene("menu");

    }
    public void level5()
    {
        
        SceneManager.LoadScene("level5");
    }
    public void level6()
    {
        
        SceneManager.LoadScene("level6");
    }
    public void level7()
    {
        
        SceneManager.LoadScene("level7");

    }
    public void level8()
    {
        
        SceneManager.LoadScene("level8");

    }
    public void level9()
    {
      
        SceneManager.LoadScene("level9");
    }
    public void exit()
    {
        wait();
        Application.Quit();
    }
    public void level10()
    {

        SceneManager.LoadScene("level10");
    }
    public void start()
    {

        SceneManager.LoadScene("start");
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
    }
}
