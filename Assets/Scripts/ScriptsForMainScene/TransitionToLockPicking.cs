using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionToLockPicking : MonoBehaviour
{
    public static bool easyLoaded, mediumLoaded, hardLoaded;
    public GameObject chestTop;
    public static bool easyChestIsOpen,mediumIsOpen,hardIsOpen;

    private void Update()
    {
        if (easyChestIsOpen)
        {
            easyChestIsOpen = false;
            chestTop.transform.position = new Vector3(chestTop.transform.position.x, chestTop.transform.position.y + 0.2f, chestTop.transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") )
        {
            PlayerPrefs.SetFloat("PlayerPosX", other.gameObject.transform.position.x);
            PlayerPrefs.SetFloat("PlayerPosY", other.gameObject.transform.position.y);
            PlayerPrefs.SetFloat("PlayerPosZ", other.gameObject.transform.position.z);
            PlayerPrefs.Save();
            if (gameObject.CompareTag("Easy"))
            {
                if (easyLoaded == false)
                {
                    easyLoaded = true;
                    SceneManager.LoadScene("Easy");
                }
            }
            if (gameObject.CompareTag("Medium"))
            {
                if (mediumLoaded == false)
                {
                    mediumLoaded = true;
                    SceneManager.LoadScene("Medium");
                }
            }
            if (gameObject.CompareTag("Hard"))
            {
                if (hardLoaded == false)
                {
                    hardLoaded = true;
                    SceneManager.LoadScene("Hard");
                }
            }
          
        }
    }
    public void OnCloseButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }
}
