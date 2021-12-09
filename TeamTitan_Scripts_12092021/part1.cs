using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class part1 : MonoBehaviour
{
    public AudioSource playerAudio;

    public AudioClip nw1; //intro dialouge podcast
    public AudioClip Dude; //Guy at the door
    public AudioClip Breaking; //dore being broken

    public GameObject dialougeBox;
    public Text dialouge;
    
    private float trackLength;
    private float currentTime;

    private bool complete;

    void Start()
    {
        trackLength = nw1.length;
        playerAudio.clip = nw1;
        playerAudio.Play();
        dialougeBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime>= trackLength && complete == false)
        {
            dialougeBox.SetActive(true);
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "DoorTrig" && currentTime >= trackLength)
        {
            dialougeBox.SetActive(true);
            dialouge.text = "Press [F] to interact with objects.";
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DoorTrig" && currentTime >= trackLength && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(1);
            //myText1.SetActive(false);
            // myText2.SetActive(true);
        }
    }

}
