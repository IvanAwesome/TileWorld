using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGame()
    {
        SceneManager.LoadScene("level1");
    }
}
//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);