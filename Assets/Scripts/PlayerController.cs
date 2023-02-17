using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Interfaces;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform playertrans;
    private Vector3 dir;
    private Rigidbody rb;

    [Header("Camera Movement")]
    [SerializeField] private float maxy;
    [SerializeField] private float rx;
    [SerializeField] private Transform campiv;
    [SerializeField] private Camera cam;

    [Header("Zoom")]
    [SerializeField] private float zoom_amount;
    [SerializeField] private float normal_fov;
    [SerializeField] private bool is_zooming;
    [SerializeField] private float zoom_smooth = 3;

    [Header("Raycast")]
    public float rayRange = 4;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.Find("CamPivot/Main Camera").GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        zoom_amount = cam.fieldOfView - 40;
        normal_fov = cam.fieldOfView;
    }

    void Update()
    {
        dir = playertrans.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        CameraControl();
        CastRay();  
    }

    private void CameraControl()
    {
        //Camera move
        rx = Mathf.Lerp(rx, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
        maxy = Mathf.Clamp(maxy - (Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30, 30);

        playertrans.Rotate(0, rx, 0, Space.World);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(maxy * 2, playertrans.eulerAngles.y, 0), 100 * Time.deltaTime);

        campiv.position = Vector3.Lerp(campiv.position, playertrans.position, 10 * Time.deltaTime);

        //Camera zoom
        if(Input.GetMouseButtonDown(1))
        {
            is_zooming = !is_zooming;
        }

        if (Input.GetMouseButtonUp(1))
        {
            is_zooming = !is_zooming;
        }

        if (is_zooming)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom_amount, zoom_smooth * Time.deltaTime);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normal_fov, zoom_smooth * Time.deltaTime);
        }

    }
    void CastRay()
    {
        RaycastHit hit_info = new RaycastHit();
        bool hit = Physics.Raycast(cam.transform.position, cam.transform.forward ,out hit_info, rayRange);
        if (hit)
        {
            GameObject hit_obj = hit_info.transform.gameObject;
            if (Input.GetMouseButtonDown(0))
            {
                hit_obj.GetComponent<IInteractable>().Interact();
            }
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * 10 * Time.fixedDeltaTime);
    }
}
