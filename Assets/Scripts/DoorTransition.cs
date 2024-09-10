using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject link = GameObject.FindGameObjectWithTag("Player");
        CameraController.room_transition = true;
        ArrowKeyMovement.player_control = false;
        SpriteRenderer link_sprite =  other.GetComponent<SpriteRenderer>();
        if(link_sprite.sprite.name == "link_sprites_0" || link_sprite.sprite.name == "link_sprites_12")
        {
            CameraController.transform_direction = new Vector3(camera.transform.position.x, (float)(camera.transform.position.y - 10.7), -10);
            link.transform.position = (new Vector3(link.transform.position.x, link.transform.position.y - .8f, 0));
        }
        else if(link_sprite.sprite.name == "link_sprites_1" || link_sprite.sprite.name == "link_sprites_13")
        {
            CameraController.transform_direction = new Vector3((float)(camera.transform.position.x - 16.6), camera.transform.position.y, -10);
            link.transform.position = (new Vector3(link.transform.position.x - 1.3f, link.transform.position.y, 0));
        }
        else if (link_sprite.sprite.name == "link_sprites_2" || link_sprite.sprite.name == "link_sprites_14")
        {
            CameraController.transform_direction = new Vector3(camera.transform.position.x, (float)(camera.transform.position.y + 10.7), -10);
            link.transform.position =  (new Vector3(link.transform.position.x, link.transform.position.y + 1.3f, 0));
        }
        else if (link_sprite.sprite.name == "link_sprites_3" || link_sprite.sprite.name == "link_sprites_15")
        {
            CameraController.transform_direction = new Vector3((float)(camera.transform.position.x + 16.4), camera.transform.position.y, -10);
            link.transform.position = (new Vector3(link.transform.position.x + 2f, link.transform.position.y, 0));
        }



    }
}
