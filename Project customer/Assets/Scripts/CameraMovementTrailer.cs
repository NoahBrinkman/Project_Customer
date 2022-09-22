using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementTrailer : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        //book = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //cam.transform.LookAt(book.transform);
        if (Input.GetKey(KeyCode.Space))
        {
            cam.fieldOfView -= 0.5f;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            cam.fieldOfView += 0.5f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.eulerAngles += 2 * new Vector3(0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cam.transform.eulerAngles -= 2 * new Vector3(0.5f, 0, 0);
        }

    }
}
