using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChange : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rb;

    [Header("Values")]
    public float transitionSpeed = 1.5f;
    public float camReturnSize = 6f;
    public float magnitudeModifier = 1f;

    void Update()
    {
        if (rb.velocity.magnitude > 0f || rb.velocity.magnitude < 0f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camReturnSize + rb.velocity.magnitude, transitionSpeed * Time.deltaTime);
        }
        else if (rb.velocity.magnitude == 0f)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, camReturnSize, transitionSpeed * Time.deltaTime);
        }
    }
}
