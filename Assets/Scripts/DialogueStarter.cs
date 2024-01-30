using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    public float transitionDuration1 = 2.5f;
    public float transitionDuration2 = 2.5f;

    public GameObject cameraObject;
    public Transform target1;
    public Transform target2;
    public bool isCameraSwitch;

    private Dialogue[] dialogueScript;

    public AudioSource audioSource;
    private bool played = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            if (audioSource && !audioSource.isPlaying && !played)
            {
                audioSource.Play();
                played = true;
            }
            if (isCameraSwitch)
            {
                StartCoroutine(Transition1());
            }
            if (GetComponentInParent<Dialogue>().isActiveAndEnabled)
            {
                dialogueScript = GetComponentsInParent<Dialogue>();
                foreach (Dialogue script in dialogueScript)
                {
                    if (script.enabled && Globals.isDialoging == false && Globals.isPaused == false)
                    {

                        script.StartDialogue();

                    }
                }
            }
        }

    }
    IEnumerator Transition1()
    {
        
        cameraObject.GetComponent<ShakeIn2D>().enabled = false;
        float t = 0.0f;
        Vector3 startingPos = cameraObject.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration1);

            cameraObject.transform.position = Vector3.Lerp(startingPos, target2.transform.position, t);
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        if (cameraObject.transform.position == target2.transform.position)
        {

            StartCoroutine(Transition2());

        }
    }
    IEnumerator Transition2()
    {
        float t = 0.0f;
        Vector3 startingPos = cameraObject.transform.position;
        while (t < 1.0f)
        {
            t += Time.deltaTime * (Time.timeScale / transitionDuration2);

            cameraObject.transform.position = Vector3.Lerp(startingPos, target1.transform.position, t);
            yield return 0;
        }
        if (cameraObject.transform.position == target1.transform.position)
        {
            cameraObject.GetComponent<ShakeIn2D>().enabled = true;
            this.gameObject.SetActive(false);
        }
    }
}
