using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitiontime = 1f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
      //  StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 0));
        
    }
   IEnumerator LoadLevel(int levelindex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds (transitiontime);

       // SceneManager.LoadScene(levelindex);
    }
}
