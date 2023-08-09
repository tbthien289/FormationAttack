using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureFlag : MonoBehaviour
{
    [SerializeField] private Image circleProgress;
    private bool keyCapture = false;

    private void Update()
    {
        if (keyCapture == true)
        {
            circleProgress.fillAmount += 0.01f * Time.fixedDeltaTime * 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D colider) {
        if (colider.gameObject.name == "MainPlayer")
        {
            keyCapture = true;
        }
    }

    private void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.gameObject.name == "MainPlayer")
        {
            keyCapture = false;
            circleProgress.fillAmount = 0;
        }
    }

}
