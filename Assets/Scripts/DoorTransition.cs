using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door")
        {
            Vector3 camPos = mainCamera.transform.position;
            Vector3 linkPos = transform.position;
            CameraController.room_transition = true;
            ArrowKeyMovement.player_control = false;
            switch (ArrowKeyMovement.facingDirection)
            {
                case ArrowKeyMovement.FacingDirection.North:
                    CameraController.transform_direction = new Vector3(camPos.x, (float)(camPos.y + 10.7), -10);
                    linkPos = new Vector3(linkPos.x, linkPos.y + 1.3f, 0);
                    break;
                case ArrowKeyMovement.FacingDirection.South:
                    CameraController.transform_direction = new Vector3(camPos.x, (float)(camPos.y - 10.7), -10);
                    linkPos = new Vector3(linkPos.x, linkPos.y - 1.5f, 0);
                    break;
                case ArrowKeyMovement.FacingDirection.East:
                    CameraController.transform_direction = new Vector3((float)(camPos.x + 16.4), camPos.y, -10);
                    linkPos = new Vector3(linkPos.x + 3f, linkPos.y, 0);
                    break;
                case ArrowKeyMovement.FacingDirection.West:
                    CameraController.transform_direction = new Vector3((float)(camPos.x - 16.4), camPos.y, -10);
                    linkPos = new Vector3(linkPos.x - 3f, linkPos.y, 0);
                    break;
            }
        }
    }
}
