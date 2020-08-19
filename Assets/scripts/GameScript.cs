using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour
{

    public static bool isGameOver;

    // Use this for initialization
    void Start()
    {

        isGameOver = false;

        Invoke("GameOver", 2.0f);

    }

    void GameOver()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}

