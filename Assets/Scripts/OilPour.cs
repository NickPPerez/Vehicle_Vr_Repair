using UnityEngine;

public class OilPour : MonoBehaviour
{
    public ParticleSystem oilPourEffect; 
    public float tiltThreshold = 45.0f; 

    private void Update()
    {
        
        float angle = Vector3.Angle(transform.up, Vector3.up);

        if (angle > tiltThreshold && !oilPourEffect.isPlaying)
        {
            oilPourEffect.Play();
        }
        else if (angle <= tiltThreshold && oilPourEffect.isPlaying)
        {
            oilPourEffect.Stop();
        }
    }
}
