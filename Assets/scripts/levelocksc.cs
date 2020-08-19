using UnityEngine;
using UnityEngine.UI;

public class levelocksc : MonoBehaviour {
    public Button[] levelbuttons;
	// Use this for initialization
	void Start () {
        int levelreached = PlayerPrefs.GetInt("levelreached",1);
        for (int i = 10; i < levelbuttons.Length; i++)
        {
            if (i+1 > levelreached)
                levelbuttons[i].interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
