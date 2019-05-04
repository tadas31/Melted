using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class about : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // int id = Input.GetTouch(0).fingerId;
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            TaskOnExitClick();
           
    }

    public void TaskOnExitClick()
    {
        gameObject.SetActive(false);
    }
}
