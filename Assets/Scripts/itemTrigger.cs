using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class ItemTrigger : MonoBehaviour
{
        [SerializeField] private GameObject instructionUI;
        [SerializeField] private GameObject backgroundObject;
        [SerializeField] private GameObject destination;
        [SerializeField] private bool triggerActive = true;
        Animator playerAnimator;
        [SerializeField] private CinemachineVirtualCamera diorama;
        //[SerializeField] private TextMeshProUGUI lineContainer;
        //[SerializeField] private GameObject backgroundItem;
        //[SerializeField] private List<AudioClip> audioClips;
        //[SerializeField] private AudioSource audioSource;
        //[SerializeField] private List<System.String> lines;
        [SerializeField] private GameObject player;

        //[SerializeField] private GameObject xObject;
        //[SerializeField] private Button x;


        //AudioClip clip;
        //bool firstTime = true;
        //PlayerMovement script;
        //bool buttonPress = false;
        public GameObject thisItem;


        void OnEnable()
        {
            playerAnimator = player.GetComponent<Animator>();
            //script = player.GetComponent<PlayerMovement>();
        }
 
        private void Update()
        {
            if (triggerActive)
            {
                //script.speed = 0;
                playerAnimator.SetBool("playerIdle", false);
                playerAnimator.SetBool("playerActivate", true);
                StartCoroutine(waitForPlayerActivate());
            }
            
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
            yield return new WaitForSeconds(4f);
            //need to change after receive animation
            diorama.Priority = 4;
            yield return new WaitForSeconds(2f);
            instructionUI.SetActive(true);
            backgroundObject.SetActive(true);
            destination.SetActive(true);
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
