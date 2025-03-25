using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

namespace SGSports.UI.Menu
{
    public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        [SerializeField] private EventReference pointerEnterSoundEvent;
        [SerializeField] private EventReference pointerClickSoundEvent;

        public void OnPointerEnter(PointerEventData eventData)
        {
            RuntimeManager.PlayOneShot(pointerEnterSoundEvent);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            RuntimeManager.PlayOneShot(pointerClickSoundEvent);
        }
    }
}