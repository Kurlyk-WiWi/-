using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour, Controls.IDialogueActions
{
    Controls _inputActions;
    Dialogues _dialogues;

    private void OnEnable()
    {
        _dialogues = FindObjectOfType<Dialogues>();
        if (_inputActions != null)
        {
            return;
        }
        _inputActions = new Controls();
        _inputActions.Dialogue.SetCallbacks(this);
        _inputActions.Dialogue.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Dialogue.Disable();
    }

    public void OnNextPhrase(InputAction.CallbackContext context)
    {
        if (context.started && _dialogues.DialogPlay && !IsPointerOverUIObject())
        {
            _dialogues.ContinueStory(_dialogues._choiceButtonsPanel.activeInHierarchy);
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
