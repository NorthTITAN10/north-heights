using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class part4 : MonoBehaviour
{
    public Text dialouge;
    public GameObject dialougeBox;
    public GameObject happyWater;
    public GameObject note;
    public AudioClip computersound;
    public AudioClip notesound;


    private bool everythingDone = false;
    private bool happyDone = false;
    private bool noteDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //puts menus down and does boolean checks
        if (dialougeBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dialougeBox.SetActive(false);
        }
        if (happyDone && noteDone)
        {
            everythingDone = true;
        }
        if (happyWater.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            happyWater.SetActive(false);
        }
        if (note.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            note.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //triggers for the progression
        if (other.gameObject.tag == "HappyWater" && !happyDone)
        {
            happyWater.SetActive(true);
            dialougeBox.SetActive(true);
            dialouge.text = "Reinstated? I should probably notify Catalina about this. I’ll go to her desk.";
            happyDone = true;
            AudioSource.PlayClipAtPoint(computersound, transform.position);
        }
        if (other.gameObject.tag == "Note" && !noteDone && happyDone)
        {
            note.SetActive(true);
            dialougeBox.SetActive(true);
            dialouge.text = "I guess Im clocking out then? Off to the elevators!";
            noteDone = true;
            AudioSource.PlayClipAtPoint(notesound, transform.position);
        }
        if (other.gameObject.tag == "DoorTrig" && everythingDone)
        {
            //after everything done go dippy
            SceneManager.LoadScene(4);
        }
    }
}
