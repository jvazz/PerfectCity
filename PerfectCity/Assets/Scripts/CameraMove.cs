using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 5f;
    float sensitivityY = 5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.5f;
    float smoothCoefy = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
            float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

            smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
            smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

            rotationX += smoothRotx;
            rotationY += smoothRoty;

            rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

            characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
