using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class fadeout : MonoBehaviour {
    public GameObject blackscreen;
    public GameObject youwintext;
    public GameObject gameoverui;
    public string level;
    public GameObject NextLevel;

    //object for levellock
    public string nextlevel = "level2";
    public int leveltounlock = 2;
    public int levelreached;
    //for ad showing
    public static bool isGameOver;
    void start()
    {
       levelreached = PlayerPrefs.GetInt("levelreached");
        isGameOver = false;
        blackscreen.SetActive(false);
        youwintext.SetActive(false);
    }
    IEnumerator OnCollisionEnter(Collision col)
    {
        //  NextLevel.SetActive(true);
        isGameOver = true;
        winlevel();
        youwintext.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3);
        blackscreen.SetActive(true);
        yield return new WaitForSeconds(1);

      SceneManager.LoadScene(level);
    }
  
    public void winlevel()
    {
        Debug.Log("winlevel");
        if (levelreached < leveltounlock)
        {
            PlayerPrefs.SetInt("levelreached", leveltounlock);
        }

    }
}
