using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public GameObject[] ActiveLockIndicator;
    public GameObject[] Locks;
    public GameObject BorderLine;
    private GameObject ActiveLock;
    public float MargineArea;
    [SerializeField] 
    TextMeshProUGUI percentage;
    [SerializeField]
    private float force;
    private int score;
    private Position playerPos;
    private void Start()
    {
        score = 0;
        playerPos = Position.MOST_RIGHT;
        transform.position = ActiveLockIndicator[(int)playerPos].transform.position;
        ActiveLock = Locks[(int)playerPos];
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;


    }
    private void Update()
    {

        ProcessInput();
        if (Input.GetKey(KeyCode.W))
        {
            if (ActiveLock.tag != "Unlock")
            {
               
                ActiveLock.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,force));
            }
        }
        CheckForLock();
        skillSet();
    }
    private void skillSet()
    {
        force = SkillManager.forceForPins;
    }
    private void CheckForLock()
    {
        Transform clickPoint = ActiveLock.transform.GetChild(0);
            if((playerPos == Position.MOST_RIGHT)|| (playerPos != Position.MOST_RIGHT && Locks[(int)playerPos+1].tag=="Unlock"))
            if (Mathf.Abs(BorderLine.transform.position.y - clickPoint.transform.position.y) < MargineArea)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (ActiveLock.tag != "Unlock")
                    {
                        ActiveLock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                        ActiveLock.tag = "Unlock";
                        score += 25;
                        percentage.text = score.ToString();
                    }
                    

                }


            }


    }
    private void ProcessInput()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPos != Position.MOST_LEFT)
            {
                playerPos--;

            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPos != Position.MOST_RIGHT)
            {
                playerPos++;

            }
        }
        transform.position = ActiveLockIndicator[(int)playerPos].transform.position;
        ActiveLock = Locks[(int)playerPos];
       
    }
}
