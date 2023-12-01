using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LugnutManager : MonoBehaviour
{
    public XRGrabInteractable flatTireInteractable;
    public XRSocketInteractor[] boltdrops;

    private void Awake()
    {
        // initially disable the XR Grab Interactable on the flat tire
        if (flatTireInteractable != null)
        {
            flatTireInteractable.enabled = false;
        }

        foreach (var boltdrop in boltdrops)
        {
            if (boltdrop != null)
            {

                boltdrop.selectExited.AddListener(OnBoltRemoved);
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var boltdrop in boltdrops)
        {
            if (boltdrop != null)
            {

                boltdrop.selectExited.RemoveListener(OnBoltRemoved);
            }
        }
    }

    private void OnBoltRemoved(SelectExitEventArgs arg)
    {
        // check if all boltdrops are empty
        if (AreAllBoltdropsEmpty())
        {
            // this enables the XR Grab Interactable on the flat tire
            flatTireInteractable.enabled = true;
        }
    }

    private bool AreAllBoltdropsEmpty()
    {
        foreach (var boltdrop in boltdrops)
        {
            if (boltdrop != null && boltdrop.hasSelection)
            {
                // checks if boltdrop still has a bolt in it
                return false;
            }
        }
        // checks if boltdrops are empty
        return true;
    }
}