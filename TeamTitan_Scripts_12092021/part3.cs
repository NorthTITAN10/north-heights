using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class part3 : MonoBehaviour
{
    private int valveCount = 0;

    private bool isTicking = false;
    private bool happyDialougeShown = false;
    private bool hmmDialougeShown = false;
    private bool stupid = false;
    private bool turnedOn = false;

    public GameObject waterfall;
    public GameObject player;

    public AudioSource[] sounds;
    public AudioSource discover;
    public AudioClip valve;
    public AudioSource waterfallsound;

    public GameObject dialougeBox;
    public Text dialouge;

    void Start()
    {
        waterfall.SetActive(false);
        sounds = GetComponents<AudioSource>();
        discover = sounds[1];
        GetComponent<AudioSource>().clip = valve;
        waterfallsound = sounds[2];
    }

    // Update is called once per frame
    void Update()
    {
        //old valve check still works
        if (valveCount >= 1)
        {
            waterfall.SetActive(true);
        }
        //disimissal
        if (Input.GetKeyDown(KeyCode.E) && dialougeBox.activeSelf && !stupid)
        {
            dialougeBox.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F) && stupid)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        //button press enters
        if(collision.gameObject.tag == "Valve")
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                valveCount += 1;
                //change to animation
                //collision.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(1,0,0);
                collision.gameObject.tag = "Turned";
                turnedOn = true;
                //audio
                discover.Play();
                AudioSource.PlayClipAtPoint(valve, transform.position);
                waterfallsound.Play();
                discover.Play();
                //UI
                dialougeBox.SetActive(true);
                dialouge.text = "The tank attached to the pipes looks suspicious. What is it?";
                happyDialougeShown = true;
            }
        }

        if (collision.gameObject.tag == "HappyWater")
        {
            if (happyDialougeShown)
            {
                if (!stupid)
                {
                    dialougeBox.SetActive(true);
                    dialouge.text = "Hmm. I’ve never seen this tank before. Maybe I should look into it." +
                    " Press [F] to investigate at the office";
                    stupid = true;

                    //StartCoroutine(Freeze());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    IEnumerator Freeze()
    {
        isTicking = true;
        yield return new WaitForSeconds(0.1f);
        dialouge.text = "Hmm. I’ve never seen this tank before. Maybe I should look into it." +
            " Press [F] to investigate at the office";
        dialougeBox.SetActive(true);
        hmmDialougeShown = true;
        isTicking = false;
        stupid = true;
    }
}
