using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllers : MonoBehaviour {

    private CarController theCar;
    
	// Use this for initialization
	void Start () {
        theCar = FindObjectOfType<CarController>();
	}

    public void LeftArrow()
    {
        theCar.Move(1);
    }
    public void RightArrow()
    {
        theCar.Move(-1);
    }
    public void UnpressedArraow()
    {
        theCar.Move(0);
    }
    public void RotateRight()
    {
        theCar.Rotation(-1);
    }
    public void RotateLeft()
    {
        theCar.Rotation(1);
    }
    public void UnRotate()
    {
        theCar.Rotation(0);
    }
}
