using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public CharacterController controller;

    [Header("Movement properties")]
    public float maxSpeed = 10.0f;
    public float gravity = -30.0f;
    public float jumpHeight = 3.0f;
    public Vector3 velocity;


    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask groundMask;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
       
        Vector3 pos= new Vector3(-4.94999981f, 1.21800005f, -0.589999974f);
        if (TransitionToLockPicking.easyLoaded || TransitionToLockPicking.mediumLoaded || TransitionToLockPicking.hardLoaded)
        {
            Debug.Log(PlayerPrefs.GetFloat("PlayerPosX"));
            if (PlayerPrefs.HasKey("PlayerPosX"))
                pos.x = PlayerPrefs.GetFloat("PlayerPosX");
            if (PlayerPrefs.HasKey("PlayerPosY"))
                pos.y = PlayerPrefs.GetFloat("PlayerPosY");
            if (PlayerPrefs.HasKey("PlayerPosZ"))
                pos.z = PlayerPrefs.GetFloat("PlayerPosZ");
            TransitionToLockPicking.easyChestIsOpen = true;
            GetComponent<CharacterController>().enabled = false;
            this.gameObject.transform.position = pos;
            GetComponent<CharacterController>().enabled = true;
        }
      
        controller = GetComponent<CharacterController>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (x != 0 || z!=0)
        {
           
            if (GetComponent<AudioSource>().isPlaying == false)
            {
               
                GetComponent<AudioSource>().Play();
            }
        }
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * maxSpeed * Time.deltaTime);
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);

        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}