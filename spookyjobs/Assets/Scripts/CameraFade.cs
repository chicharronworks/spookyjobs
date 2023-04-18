using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("CameraFade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fade()
    {
        animator.Play("CameraFade");
     
    }
}
