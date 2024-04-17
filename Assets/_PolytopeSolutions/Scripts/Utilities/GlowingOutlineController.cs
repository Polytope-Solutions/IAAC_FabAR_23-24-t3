using UnityEngine;
using UnityEngine.UI;  // Required for accessing UI components
using UnityEngine.EventSystems;
public class GlowingOutlineController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject glowingSprite;  // The sprite with the glowing outline

    void Start()
    {
        // Initially disable the glowing effect
        glowingSprite.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        glowingSprite.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        glowingSprite.SetActive(false);
    }
}