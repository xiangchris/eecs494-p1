using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static public bool room_transition = false;
    static public Vector3 transform_direction;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 960, false);
        StartCoroutine(WaitForPlayerInputToTransition());
    }

    IEnumerator WaitForPlayerInputToTransition()
    {
        while (true)
        {
            if (room_transition)
            {
                Vector3 initial_position = transform.position;

                /* Transition to new "room" */
                yield return StartCoroutine(
                    CoroutineUtilities.MoveObjectOverTime(transform, initial_position, transform_direction, 2.5f)
                );
                room_transition = false;
                ArrowKeyMovement.playerControl = true;
            }

            /* We must yield here to let time pass, or we will hardlock the game (due to infinite while loop) */
            yield return null;
        }
    }
}
