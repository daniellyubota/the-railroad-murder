using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D = null;

    public Animator myAnimator = null;

    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private GameObject canvasGameObject = null;
    [SerializeField]
    private GameObject clickRange = null;
    [SerializeField]
    private GameObject[] bedroomsDoors;
    [SerializeField]
    private GameObject[] toiletsDoors;
    [SerializeField]
    private GameObject bathroomGameObject;




    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
       

    }

    private void Update()
    {
        if (this.gameObject.transform.position.x > 33 && this.gameObject.transform.position.x < 34.5)
        {
            foreach (GameObject bedroomsDoor in bedroomsDoors)
            {
                bedroomsDoor.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject bedroomsDoor in bedroomsDoors)
            {
                bedroomsDoor.SetActive(false);
            }
        }
        if (bathroomGameObject.activeSelf == false)
        {
            if (this.gameObject.transform.position.x > 149.5 && this.gameObject.transform.position.x < 151.50)
            {
                foreach (GameObject toiletsDoor in toiletsDoors)
                {
                    toiletsDoor.SetActive(true);
                }
            }
            else
            {
                foreach (GameObject toiletsDoor in toiletsDoors)
                {
                    toiletsDoor.SetActive(false);
                }
            }
        }
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        myRigidbody2D.velocity = new Vector2(horizontalInput * speed, myRigidbody2D.velocity.y);

        myAnimator.SetFloat("HorizontalSpeed", Mathf.Abs(myRigidbody2D.velocity.x));

        if (horizontalInput < 0f && transform.right.x > 0f)
        {
            Flip();
        }

        if (horizontalInput > 0f && transform.right.x < 0f)
        {
            Flip();
        }


    }

    public void Flip()
    {
        if (clickRange.transform.localPosition.z == 3)
        {
            clickRange.transform.localPosition = new Vector3(clickRange.transform.localPosition.x, clickRange.transform.localPosition.y, -3);
        }
        else if (clickRange.transform.localPosition.z == -3)
        {
            clickRange.transform.localPosition = new Vector3(clickRange.transform.localPosition.x, clickRange.transform.localPosition.y, 3);
        }
        Vector3 myCurrentRotation = transform.localEulerAngles;
        myCurrentRotation.y += 180f;
        transform.localEulerAngles = myCurrentRotation;
        canvasGameObject.transform.rotation = Quaternion.identity;
    }
}
