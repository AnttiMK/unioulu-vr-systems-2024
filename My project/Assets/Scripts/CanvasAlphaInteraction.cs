using UnityEngine;

public class CanvasAlphaInteraction : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    
        private void Start()
        {
            // Get the CanvasGroup component
            _canvasGroup = GetComponent<CanvasGroup>();
    
            // Ensure the canvas starts with the correct interactability
            UpdateInteractability();
        }
    
        private void Update()
        {
            // Check if the alpha value is 0
            if (_canvasGroup.alpha == 0)
            {
                // If so, set interactability to false
                _canvasGroup.interactable = false;
            }
            else
            {
                // Otherwise, set interactability to true
                _canvasGroup.interactable = true;
            }
        }
    
        private void UpdateInteractability()
        {
            // Check if the alpha value is 0
            if (_canvasGroup.alpha == 0)
            {
                // If so, set interactability to false
                _canvasGroup.interactable = false;
            }
            else
            {
                // Otherwise, set interactability to true
                _canvasGroup.interactable = true;
            }
        }
}
