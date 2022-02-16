using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionToLockPicking : MonoBehaviour
{
    public static bool easyLoaded, mediumLoaded, hardLoaded;
    public GameObject easyChestTop,mediumChestTop,hardChestTop;
    public static bool easyChestIsOpen,mediumIsOpen,hardIsOpen;

    private void Update()
    {
        if (easyChestIsOpen && gameObject.CompareTag("Easy"))
        {
            easyChestIsOpen = false;
            easyChestTop.transform.position = new Vector3(easyChestTop.transform.position.x, easyChestTop.transform.position.y + 0.2f, easyChestTop.transform.position.z);
        }
        if (mediumIsOpen && gameObject.CompareTag("Medium"))
        {
            mediumIsOpen = false;
            mediumChestTop.transform.position = new Vector3(mediumChestTop.transform.position.x, mediumChestTop.transform.position.y + 0.2f, mediumChestTop.transform.position.z);
        }
        if (hardIsOpen && gameObject.CompareTag("Hard"))
        {
            hardIsOpen = false;
            hardChestTop.transform.position = new Vector3(hardChestTop.transform.position.x, hardChestTop.transform.position.y + 0.2f, hardChestTop.transform.position.z);
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
    private void OnTriggerExit(Collider collision)
    {
        if (gameObject.CompareTag("Easy"))
            TransitionToLockPicking.easyLoaded = false;
        if (gameObject.CompareTag("Medium"))
            TransitionToLockPicking.mediumLoaded = false;
        if (gameObject.CompareTag("Hard"))
            TransitionToLockPicking.hardLoaded = false;
    }
    public void OnCloseButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }
}
