using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    private Vector3 mausPosition;
    [SerializeField] private float horizontal = 0;
    [SerializeField] private float vertikal = 0;
    [SerializeField] private float zuvorHorizontal = 0;
    [SerializeField] private float zuvorVertikal = 0;
    [SerializeField] private float sensitivitaet = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
    }


    void FixedUpdate()
    {
        MauszeigerAbfragen();
        KameraBewegung();
    }


    private void MauszeigerAbfragen()
    {
        zuvorHorizontal = horizontal;
        zuvorVertikal = vertikal;
        horizontal = Input.mousePosition.x;
        vertikal = -Input.mousePosition.y;
        vertikal = Mathf.Clamp(vertikal, -5, 20);
    }


    private void KameraBewegung()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, (horizontal) * sensitivitaet);
        //transform.RotateAround(Vector3.zero, Vector3.right, vertikal * sensitivitaet);
    }

}
