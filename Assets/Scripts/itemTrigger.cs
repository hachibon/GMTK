using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class ItemTrigger : MonoBehaviour
{
        [SerializeField] private GameObject instructionUI;
        [SerializeField] private GameObject backgroundObject;
        //[SerializeField] private bool triggerActive = true;
        [SerializeField] GameObject moveUI;
        Animator playerAnimator;
        [SerializeField] private CinemachineVirtualCamera diorama;
        [SerializeField] private GameObject text;
        [SerializeField] private GameObject player;
        PlayerController script;
        //[SerializeField] private TextMeshProUGUI lineContainer;
        //[SerializeField] private GameObject backgroundItem;
        //[SerializeField] private List<AudioClip> audioClips;
        //[SerializeField] private AudioSource audioSource;
        //[SerializeField] private List<System.String> lines;
        //[SerializeField] private GameObject xObject;
        //[SerializeField] private Button x;


        //AudioClip clip;
        //bool firstTime = true;
        //PlayerMovement script;
        //bool buttonPress = false;
        //public GameObject thisItem;
        void OnEnable()
        {
            script = player.GetComponent<PlayerController>();
            player = GameObject.Find("Player");
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerAnimator = player.GetComponent<Animator>();
                //script = player.GetComponent<PlayerMovement>();
                //script.speed = 0;
                playerAnimator.SetBool("playerIdle", false);
                playerAnimator.SetBool("playerActivate", true);
                StartCoroutine(waitForPlayerActivate());
            }
        }
 
        private void Update()
        {
            
            /*
            if (triggerActive && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E)) && firstTime)
            {
                interactUI.SetActive(false);
                phone.SetActive(true);
                if(zoomImage != null)
                {
                    zoomImage.SetActive(true);
                }
                xObject.SetActive(true);
                script.speed = 0;
                firstTime = false;
                PlayLines();
            }
            x.onClick.AddListener(buttonPressed);
            */
            
        }

        IEnumerator waitForPlayerActivate()
        {
            //need to change after receive animation
            text.SetActive(false);
            script.moveSpeed = 0f;
            diorama.Priority = 4;
            yield return new WaitForSeconds(2f);
            instructionUI.SetActive(true);
            backgroundObject.SetActive(true);
            moveUI.SetActive(false);
            gameObject.SetActive(false);
        }

/*
        void buttonPressed()
        {
            StopLines();
            buttonPress=true;
            phone.SetActive(false);
            if(zoomImage != null)
            {
                zoomImage.SetActive(false);
            }
            xObject.SetActive(false);
            script.speed = 3;
            buttonPress = false;
            audioSource.Stop();
            Debug.Log("audio stopped");
            lineContainer.text = "";
            thisItem.SetActive(false);
        }
 
        public void PlayLines()
        {
            StartCoroutine(TimedLines());
        }

        public void StopLines()
        {
            StopCoroutine(TimedLines());
        }

        IEnumerator TimedLines()
        {
            for (int index = 0; index < audioClips.Count; index++)
            {
                if (index > 0)
                {
                    Debug.Log("playing next line");
                }
                clip = audioClips[index];
                audioSource.clip = clip;
                audioSource.Play();
                Debug.Log("audio playing");
                lineContainer.text = lines[index];
                if(buttonPress==true)
                {
                    break;
                }
                yield return new WaitForSeconds(clip.length);
                Debug.Log("waiting");
                audioSource.Stop();
                Debug.Log("audio stopped");
            }
        }
        */
    
}
