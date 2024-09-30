using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public Animator transition;   //This is the animator that is assigned to transform and make the transition

    public float transitionTime = 1f;  //This is the time in seconds of the transaction 


    //This method takes a scene by name and takes it to the coroutine to be executed in an allotted time
    public void LoadScene(string sceneName)
    {
        
        StartCoroutine(LoadLevel(sceneName));
    }

    //This coroutine takes an scene and loads it on the screen after waiting the assigned seconds and making the transaction with the animator
    IEnumerator LoadLevel(string sceneName)
    {
        //play animation
        transition.SetTrigger("Start");

        //wait 
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(sceneName);
    }

}
