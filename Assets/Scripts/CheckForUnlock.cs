using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckForUnlock : MonoBehaviour
{
    [SerializeField]
    private GameObject LastLockBar;
    public GameObject resultText;

    private void Update()
    {
        if(LastLockBar.tag =="Unlock")
        {
            resultText.SetActive(true);
            StartCoroutine(DelayBeforeSceneLoad());
        }
    }
   public IEnumerator DelayBeforeSceneLoad()
    {
        yield return new WaitForSeconds(1.0f);
      
        SceneManager.LoadScene("Main");
    }
}
