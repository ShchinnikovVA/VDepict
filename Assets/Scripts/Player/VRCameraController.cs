using UnityEngine;
using UnityEngine.XR;

public class VRCameraController : MonoBehaviour
{
    private XRNode inputSource = XRNode.Head;
    private Vector2 sensitivity = new Vector2(2, 2);
    private float minimumX = -90f;
    private float maximumX = 90f;
    private float rotationX = 0f;

    void Update()
    {
        UpdateCameraRotation();
    }

    private void UpdateCameraRotation()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.isValid)
        {
            Vector2 rotationValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceRotation, out Quaternion deviceRotation))
            {
                deviceRotation.ToAngleAxis(out float angle, out Vector3 axis);
                if (angle > 180)
                {
                    angle -= 360;
                }

                rotationValue = new Vector2(
                    axis.x * angle * sensitivity.x,
                    axis.y * angle * sensitivity.y
                );

                rotationX += rotationValue.y;
                rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

                transform.localEulerAngles = new Vector3(-rotationX, transform.localEulerAngles.y + rotationValue.x, 0);
            }
        }
    }
}


