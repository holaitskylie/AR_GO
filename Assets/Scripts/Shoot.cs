using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{  

    public Camera camera;
    public GameObject prefab1;

    AudioSource audio;
    public AudioClip catchClip;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Fire();
            }
        }
    }

    public void Fire()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))        
        {        
            if (hit.transform.CompareTag("Dragonfly"))            
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(10);
                audio.PlayOneShot(catchClip);
            }

            if (hit.transform.CompareTag("Frog"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(50);
                audio.PlayOneShot(catchClip);
            }

            if(hit.transform.CompareTag("Butterfly"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(100);
                audio.PlayOneShot(catchClip);
            }

            if (hit.transform.CompareTag("Honeybee"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(150);
                audio.PlayOneShot(catchClip);
            }

            if (hit.transform.CompareTag("Grasshopper"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(200);
                audio.PlayOneShot(catchClip);
            }
        }
    }    
}
