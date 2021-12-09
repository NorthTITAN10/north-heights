using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class part7 : MonoBehaviour
{
    public GameObject dialougeBox;
    public GameObject otherDialouge;
    public GameObject usb;
    public GameObject celldoor;
    public AudioSource celldoorsound;
    public AudioSource usbpickup;
    

    public Text dialouge;

    private bool hasUsb;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = celldoor.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        // on screen dismiss
        if (dialougeBox.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dialougeBox.SetActive(false);
        }

        if (otherDialouge.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            otherDialouge.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // triggers for sequencing
        if (other.gameObject.tag == "Usb" && Input.GetKeyDown(KeyCode.F))
        {
            hasUsb = true;
            Destroy(usb);
            usbpickup.Play();
        }

        if (other.gameObject.tag == "DoorTrig" && Input.GetKeyDown(KeyCode.F) && hasUsb)
        {
            dialougeBox.SetActive(true);
            dialouge.text = "I need to go to my computer and upload this data.";
            Debug.Log("opening");
            anim.Play();
            celldoorsound.Play();
        }
        if (other.gameObject.tag == "Upload" && hasUsb && Input.GetKeyDown(KeyCode.F))
        {
            //add fade here and maybe courtine
            SceneManager.LoadScene(7);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DoorTrig" && hasUsb)
        {
            dialougeBox.SetActive(true);
        }
    }
}
