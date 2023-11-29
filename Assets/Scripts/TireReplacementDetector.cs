using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireReplacementDetector : MonoBehaviour
{
    public GameObject congratsImage; 

    void Start()
    {
        
        if (congratsImage != null)
        {
            congratsImage.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the replacement tire
        if (other.gameObject.name == "replacement")
        {
            // shows the congrats image
            if (congratsImage != null)
            {
                congratsImage.SetActive(true);
                StartCoroutine(HideImageAfterDelay(5.0f)); // Hide the image after 5 secs
            }
        }
    }

    private System.Collections.IEnumerator HideImageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (congratsImage != null)
        {
            congratsImage.SetActive(false);
        }
    }
}
