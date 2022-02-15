using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class KeyController : MonoBehaviour
{
    public static bool KeyIsIn;
    [SerializeField]
    TextMeshProUGUI loseText;
    public int verticalForce,HorizontalForce;
    public GameObject keyStartPos;
    private void Start()
    {
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    private void Update()
    {
        processInput();
    }
    private void processInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
           transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, verticalForce));
           
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-HorizontalForce,0));
         
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y , transform.position.z);
        }

    }  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            GetComponent<PlayerController>().enabled = true;
            GetComponent<KeyController>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            KeyIsIn = true;
            this.gameObject.transform.position = keyStartPos.transform.position;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            loseText.text = "You Broke The Lock!";
            loseText.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
