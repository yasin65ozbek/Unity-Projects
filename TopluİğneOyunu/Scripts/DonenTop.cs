using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonenTop : MonoBehaviour
{

    public float donmeHizi;

    void Start()
    {
        donmeHizi = 50.0f;
    }

    void Update()
    {
        transform.Rotate(0, 0, donmeHizi * Time.deltaTime);
    }
}
