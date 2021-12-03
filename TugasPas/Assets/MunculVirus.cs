using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunculVirus : MonoBehaviour
{
    public GameObject virus;
    public float waktumin, waktumax;
    public float tempatmin, tempatmax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MunculinVirus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MunculinVirus()
    {
        Instantiate(virus, transform.position + Vector3.right * Random.Range(tempatmin, tempatmax)
            , Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(waktumin, waktumax));
        StartCoroutine(MunculinVirus());

    }
}
