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
            if (TransitionToLockPicking.easyLoaded)
                TransitionToLockPicking.easyChestIsOpen = true;
            if (TransitionToLockPicking.mediumLoaded)
                TransitionToLockPicking.mediumIsOpen = true;
            if (TransitionToLockPicking.hardLoaded)
                TransitionToLockPicking.hardIsOpen = true;
            StartCoroutine(DelayBeforeSceneLoad());
        }
    }
   public IEnumerator DelayBeforeSceneLoad()
    {
        yield return new WaitForSeconds(1.0f);
        if (TransitionToLockPicking.easyLoaded)
            TransitionToLockPicking.easyChestIsOpen = true;
        if (TransitionToLockPicking.mediumLoaded)
            TransitionToLockPicking.mediumIsOpen = true;
        if (TransitionToLockPicking.hardLoaded)
            TransitionToLockPicking.hardIsOpen = true;
        SceneManager.LoadScene("Main");
    }
}
