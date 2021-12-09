using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class part6 : MonoBehaviour
{
    public GameObject troops;
    public GameObject phoneScreen;
    public GameObject dialougeBox;
    public GameObject otherDialouge;
    public GameObject player;
    public AudioSource discoversound;
    public AudioSource[] sounds;
    public AudioSource gatesound;
    public AudioSource guyshowsup;

    public Text dialouge;

    private bool deadSeen;
    private bool phoneSeen;
    private bool stopDat;

    // Start is called before the first frame update
    void Start()
    {
        gatesound = sounds[1];
        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // on screen dismiss
        if (dialougeBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            //phone off
            dialougeBox.SetActive(false);
        }

        if (phoneScreen.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            //phone dismisal
            gatesound.Play();
            phoneScreen.SetActive(false);
            dialougeBox.SetActive(true);
            dialouge.text = "She's unresponsive...";
            phoneSeen = true;
        }
        if (phoneSeen == true)
        {
            troops.SetActive(true);
        }
        if (otherDialouge.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(6);
        }
        //bool checks for sequencing and player freezing
        if (stopDat)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            //Destroy(player.GetComponent<fi>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //sequencing triggers
        if (other.gameObject.tag == "Dead" && !deadSeen)
        {
            phoneScreen.SetActive(true);
            deadSeen = true;
            discoversound.Play();
        }

        if (other.gameObject.tag == "Mayor")
        {
            troops.SetActive(true);
            otherDialouge.SetActive(true);
            stopDat = true;
            guyshowsup.Play();
        }
    }
}
