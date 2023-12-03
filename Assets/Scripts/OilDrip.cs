using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OilLeakTrigger : MonoBehaviour
{
    public ParticleSystem oilLeakEffect; 

    private XRSocketInteractor bottomDrop; 

    private void Awake()
    {
        
        bottomDrop = GameObject.Find("bottomdrop").GetComponent<XRSocketInteractor>();

        if (bottomDrop == null)
        {
            return;
        }

        if (oilLeakEffect == null)
        {
            return;
        }

        
        bottomDrop.selectExited.AddListener(OnBoltRemoved);
    }

    private void OnDestroy()
    {
        
        if (bottomDrop != null)
        {
            bottomDrop.selectExited.RemoveListener(OnBoltRemoved);
        }
    }

    private void OnBoltRemoved(SelectExitEventArgs arg)
    {
        
        if (arg.interactable.gameObject.name == "bottombolt")
        {
            StartCoroutine(StartAndStopOilLeak(4f)); 
        }
    }

    private System.Collections.IEnumerator StartAndStopOilLeak(float duration)
    {
        oilLeakEffect.Play();
        yield return new WaitForSeconds(duration);
        oilLeakEffect.Stop();
    }
}
