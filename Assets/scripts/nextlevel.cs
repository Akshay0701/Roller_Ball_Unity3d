using UnityEngine;
using UnityEngine.SceneManagement;
public class nextlevel : MonoBehaviour
{
    public GameObject player;
    public string level;
    void OnCollisionEnter(Collision col)
    {
        SceneManager.LoadScene(level);
    }
}
