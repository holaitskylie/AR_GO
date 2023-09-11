using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera camere;
    public GameObject prefab1;

    //AudioSource audio;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void Fire()
    {
        RaycastHit hit;
        Ray ray = camere.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.CompareTag("Animal"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(50);
            }

            if(hit.transform.CompareTag("frog"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(100);
            }

            if(hit.transform.CompareTag("dragonfly"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab1, hit.point, Quaternion.LookRotation(hit.normal));
                GameManager.instance.AddScore(200);
            }
        }
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Fire();
            }
        }
    }
}
