using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class part5 : MonoBehaviour
{
    private AudioSource playerAudio;
    public AudioSource phoneAudio;

    public AudioClip nw2;
    public AudioClip phoneRing;

    private float trackLength;
    private float currentTime;

    public GameObject phoneScreen;
    public GameObject dialougeBox;

    public Text dialouge;

    private bool complete;
    private bool seenItAll = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HoldOn());
        playerAudio = this.gameObject.GetComponent<AudioSource>();
        trackLength = nw2.length;
        playerAudio.clip = nw2;
        playerAudio.Play();
        //Debug.Log(trackLength);
    }

    // Update is called once per frame
    void Update()
    {
        // on screen dismiss
        if (dialougeBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dialougeBox.SetActive(false);
        }

        if (phoneScreen.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            //dismisal of phone
            phoneScreen.SetActive(false);
            dialougeBox.SetActive(true);
            dialouge.text = "That doesn't sound good, I need to go now.";
            complete = false;
            seenItAll = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //shows phone
        if (other.gameObject.tag == "Phone" && Input.GetKeyDown(KeyCode.F) && complete)
        {
            phoneAudio.Stop();
            phoneScreen.SetActive(true);
            dialougeBox.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //moves scene
        if (other.gameObject.tag == "DoorTrig" && seenItAll)
        {
            SceneManager.LoadScene(5);
        }

    }

    IEnumerator HoldOn()
    {
        //waits for podcast completion
        yield return new WaitForSeconds(31.8f);
        dialougeBox.SetActive(true);
        dialouge.text = "Just got a text. I should check it out.";
        phoneAudio.clip = phoneRing;
        phoneAudio.Play();
        complete = true;
    }
}
