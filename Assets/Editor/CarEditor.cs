using Features.Cars;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    private void OnSceneGUI()
    {
        Car car = target as Car;
        Handles.color = Color.red;
        Handles.DrawLine(car.transform.position, car.transform.position + car.transform.forward * 2, 10);
    }
}