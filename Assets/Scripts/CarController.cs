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

    private void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        //movement = -Input.GetAxisRaw("Vertical") * speed;
        Move(-Input.GetAxisRaw("Vertical"));
        //rotation = -Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Rotation(-Input.GetAxisRaw("Horizontal"));
#endif
    }

    private void FixedUpdate()
    {
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
    
