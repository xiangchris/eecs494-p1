using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour
{
    private Camera mainCamera;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door")
        {
            rb.velocity = Vector2.zero;
            Vector3 camPos = mainCamera.transform.position;
            Vector3 linkPos = transform.position;
            CameraController.room_transition = true;
            ArrowKeyMovement.playerControl = false;
            switch (ArrowKeyMovement.getDirection())
            {
                case Utility.Facing.North:
                    CameraController.transform_direction = new Vector3(camPos.x, camPos.y + 10.7f, -10);
                    transform.position = new Vector3(linkPos.x, linkPos.y + 5f, 0);
                    break;
                case Utility.Facing.South:
                    CameraController.transform_direction = new Vector3(camPos.x, camPos.y - 10.7f, -10);
                    transform.position = new Vector3(linkPos.x, linkPos.y - 5f, 0);
                    break;
                case Utility.Facing.East:
                    CameraController.transform_direction = new Vector3(camPos.x + 16.4f, camPos.y, -10);
                    transform.position = new Vector3(linkPos.x + 5f, linkPos.y, 0);
                    break;
                case Utility.Facing.West:
                    CameraController.transform_direction = new Vector3(camPos.x - 16.4f, camPos.y, -10);
                    transform.position = new Vector3(linkPos.x - 5f, linkPos.y, 0);
                    break;
            }
        }
    }
}
