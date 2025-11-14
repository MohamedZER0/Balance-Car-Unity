using UnityEngine;

public class CarController : MonoBehaviour
{

    public float speed = 1500;
    public float rotationSpeed = 600f;
    private float movement = 0f;
    private float rotation = 0f;
    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;
    public int maxMotorTorque = 10000;
    public Rigidbody2D rB;

    private void Start()
    {
        if (backWheel == null || frontWheel == null)
        {
            Debug.LogError("CarController: Wheel joints are not assigned!");
        }
        if (rB == null)
        {
            Debug.LogError("CarController: Rigidbody2D is not assigned!");
        }
    }

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        Move(-Input.GetAxisRaw("Vertical"));
        Rotation(-Input.GetAxisRaw("Horizontal"));
#endif
    }

    private void FixedUpdate()
    {
        if (backWheel == null || frontWheel == null || rB == null)
        {
            return;
        }

        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else
        {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = maxMotorTorque };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rB.AddTorque(rotation);
    }

    public void Move(float moveInput)
    {
        movement = speed * moveInput;
    }
    public void Rotation(float rotationValue)
    {
        rotation = rotationValue * rotationSpeed * Time.fixedDeltaTime;
    }
}
