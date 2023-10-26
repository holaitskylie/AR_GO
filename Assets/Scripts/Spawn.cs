using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pos;
    public GameObject[] prefab;

    void Start()
    {
        //audio = GetComponent<AudioSource>();  나중에 오디오 추가 시 넣을 예정

        StartCoroutine(WaitAndSpawn());
        
    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            float waitTime = Random.Range(2.0f, 4.0f);
            yield return new WaitForSeconds(waitTime);

            for(int i = 0; i < 3; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);
                int iPos = Random.Range(0, pos.Length);

                GameObject obj = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.identity);

                Destroy(obj, 5f);

                Rigidbody rb = obj.GetComponent<Rigidbody>();

                rb.AddForce(Vector3.up * Random.Range(4.0f, 10.0f), ForceMode.VelocityChange);
            }
            //audio.Play(); 오디오 추가 시 활용 예정
        }
    }

    void Update()
    {
        
    }
}
