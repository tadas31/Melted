using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
