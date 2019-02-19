using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{ 

    public int Back;                //distance from player to camera back
    public int Up;                  //distance from player to camera up
    public int Right;               //distance from player to camera right
    private Transform player;       //player

    // Start is called before the first frame update
    void Start()
    {
        player = playerManager.instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.position.x + Right, player.position.y + Up, player.position.z - Back);
        transform.LookAt(player.position);
    }
}
