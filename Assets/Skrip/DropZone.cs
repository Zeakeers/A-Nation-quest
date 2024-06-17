using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string correctAnswer;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            if (correctAnswer == eventData.pointerDrag.name)
            {
                gameManager.CheckAnswer(correctAnswer);
                eventData.pointerDrag.transform.SetParent(transform);
            }
            else
            {
                gameManager.CheckAnswer(""); // Memastikan jawaban salah diproses
            }
        }
    }
}
