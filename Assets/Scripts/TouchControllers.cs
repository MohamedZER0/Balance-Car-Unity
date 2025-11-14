using UnityEngine;

public class TouchControllers : MonoBehaviour {

    private CarController theCar;
    
	// Use this for initialization
	void Start () {
        theCar = FindObjectOfType<CarController>();
        if (theCar == null)
        {
            Debug.LogError("TouchControllers: No CarController found in scene!");
        }
	}

    public void LeftArrow()
    {
        if (theCar != null) theCar.Move(1);
    }
    public void RightArrow()
    {
        if (theCar != null) theCar.Move(-1);
    }
    public void UnpressedArrow()
    {
        if (theCar != null) theCar.Move(0);
    }
    public void RotateRight()
    {
        if (theCar != null) theCar.Rotation(-1);
    }
    public void RotateLeft()
    {
        if (theCar != null) theCar.Rotation(1);
    }
    public void UnRotate()
    {
        if (theCar != null) theCar.Rotation(0);
    }
}
