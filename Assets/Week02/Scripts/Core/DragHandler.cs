using R3;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Week02.Scripts.Core
{
    public class DragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public Observable<float> SpeedSubject => _speedSubject;
        
        private Vector2 _mousePosition;
        private readonly Subject<float> _speedSubject = new();
    
        public void OnDrag(PointerEventData eventData)
        {
            
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _mousePosition = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var speed = (eventData.position - _mousePosition).magnitude / 100f;
            _speedSubject.OnNext(speed);
        }
    }
}
