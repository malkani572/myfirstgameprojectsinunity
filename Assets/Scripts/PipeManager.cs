using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{

    public float MovementSpeed;
    public Transform Right;
    public Transform Left;


    void Start()
    {
        StartCoroutine(MovePipe());
    }
    IEnumerator MovePipe()
    {
        Vector3 CurPos = transform.position;
        transform.position = new Vector3(CurPos.x - Time.deltaTime*MovementSpeed, CurPos.y, CurPos.z);
        yield return new WaitForEndOfFrame();
        if(transform.position.x < Left.position.x)
        {
            Vector3 CurPos2 = transform.position;
            CurPos2.x = Right.position.x;
            transform.position = new Vector3(CurPos2.x, CurPos2.y, CurPos2.z);
        }
        StartCoroutine(MovePipe());
    }
}
