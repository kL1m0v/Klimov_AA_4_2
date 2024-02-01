using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAnimator : MonoBehaviour
{
    CanvasGroup _canvasgroup;

    private void Start()
    {
        _canvasgroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator DisappearanceCanvas()
    {
        _canvasgroup.interactable = false;
        while (_canvasgroup.alpha > 0)
        {
            _canvasgroup.alpha -= Time.deltaTime;
            yield return null;
        }

    }
}
