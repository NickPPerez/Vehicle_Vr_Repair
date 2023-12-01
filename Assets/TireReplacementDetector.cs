using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TireReplacementDetector : MonoBehaviour
{
    public GameObject congratsImage; 

    private XRSocketInteractor socketInteractor;

    private void Awake()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();

        if (congratsImage == null)
        {
            return;
        }

        if (socketInteractor == null)
        {
            return;
        }

        socketInteractor.selectExited.AddListener(OnSelectExit);
        socketInteractor.selectEntered.AddListener(OnSelectEnter);
    }

    private void OnDestroy()
    {
  
        if (socketInteractor != null)
        {
            socketInteractor.selectExited.RemoveListener(OnSelectExit);
            socketInteractor.selectEntered.RemoveListener(OnSelectEnter);
        }
    }

    private void OnSelectExit(SelectExitEventArgs arg)
    {
        if (arg.interactable.gameObject.name == "flattire")
        {
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs arg)
    {
        if (arg.interactable.gameObject.name == "replacement")
        {
            congratsImage.SetActive(true);
            Invoke(nameof(HideCongratsImage), 5f);
        }
}


    private void HideCongratsImage()
    {
        congratsImage.SetActive(false);
    }
}