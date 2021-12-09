using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class part2 : MonoBehaviour
{
    public GameObject textPanel;

    public Text dialouge;
    public Text buttonText;

    public Button gotIt;
    public AudioClip Manager;
    public AudioClip Card;

    private bool idCardGot = false;
    private bool told;
    

    // Start is called before the first frame update
    void Start()
    {
        told = false;
        //textPanel.SetActive(false);
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Manager;
        GetComponent<AudioSource>().clip = Card;
    }

    // Update is called once per frame
    void Update()
    {
        //panel dismiss
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (textPanel.activeSelf)
            {
                gotIt.onClick.Invoke();
            }
        }
    }

    public void GotIt()
    {
        textPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //on trigger oncecs
        if(collision.gameObject.tag == "Boss" && idCardGot == false)
        {
            textPanel.SetActive(true);
            dialouge.text = "Hey, Leo. It seems that our sewage system has been tampered with and is now backlogged. I'm going to need you to turn on the valve. My ID card to get into the sewers is on the presentation desk near the elevators. Good luck.";
            AudioSource.PlayClipAtPoint(Manager, transform.position);
            told = true;
        }

        if (collision.gameObject.tag == "DoorTrig" && idCardGot)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //on trigger stay for button stuff
        if (other.gameObject.tag == "IDCard" && told)
        {
            if (Input.GetKeyDown(KeyCode.F))            
            {
                AudioSource.PlayClipAtPoint(Card, transform.position);
                textPanel.SetActive(true);
                dialouge.text = "ID found! Im am gonna head to the elevator now";
                buttonText.text = "Go to Sewer";
                other.gameObject.SetActive(false);
                idCardGot = true;
            }
            
        }
    }
}
