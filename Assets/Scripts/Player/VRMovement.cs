using UnityEngine;
using UnityEngine.XR;

public class VRMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;
    private XRNode inputSource = XRNode.LeftHand;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 inputAxis = GetInputAxis();
        Vector3 moveDirection = new Vector3(inputAxis.x, 0, inputAxis.y);

        if (moveDirection != Vector3.zero)
        {
            moveDirection = Quaternion.Euler(0, transform.eulerAngles.y, 0) * moveDirection;
            controller.Move(moveDirection * Time.deltaTime * speed);
        }
    }

    private Vector2 GetInputAxis()
    {
        Vector2 inputAxis = Vector2.zero;

        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.isValid)
        {
            InputFeatureUsage<Vector2> axis = CommonUsages.primary2DAxis;
            if (device.TryGetFeatureValue(axis, out inputAxis))
            {
                return inputAxis;
            }
        }

        return inputAxis;
    }
}




