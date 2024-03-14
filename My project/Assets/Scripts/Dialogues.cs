using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Dialogues : MonoBehaviour
{
    private Story _currentStory;
    private TextAsset _inkjson;
    
    private GameObject _dialoguePanel;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _nameText;

    private GameObject _choiceButtonsPanel;
    private GameObject _choiceButton;
    private List<TextMeshProUGUI> _choiceText = new List<TextMeshProUGUI>();

    public bool DialogPlay { get; private set; }
    [Inject]
    public void Costruct(DialoguesInstaller dialogueInstaller)
    {
        _inkjson = dialogueInstaller.inkjson;
        _dialoguePanel = dialogueInstaller.dialoguePanel;
        _dialogueText = dialogueInstaller.dialogueText;
        _nameText = dialogueInstaller.nameText;
        _choiceButtonsPanel = dialogueInstaller.choiceButtonsPanel;
        _choiceButton = dialogueInstaller.choiceButton;
        //Awake();
    }
    private void Awake()
    {
        _currentStory = new Story(_inkjson.text);
    }
    void Start()
    {
        StartDialogue();
    }
    public void StartDialogue()
    {
        DialogPlay = true;
        _dialoguePanel.SetActive(true);
        ContinueStory();
    }
    public void ContinueStory()
    {
        if(_currentStory.canContinue)
        {
            ShowDialogue();
            ShowChoiseButtons();
        }
        else
        {
            ExitDialogue();
        }
    }
    private void ShowDialogue()
    {
        _dialogueText.text = _currentStory.Continue();
        _nameText.text = _currentStory.variablesState["characterName"].ToString();
    }
    private void ShowChoiseButtons()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        _choiceButtonsPanel.SetActive(currentChoices.Count!=0);
        if(currentChoices.Count<=0 ) { return; }
        for(int i=0; i<currentChoices.Count; i++)
        {
            GameObject choice = Instantiate(_choiceButton);
            choice.GetComponent<ButtonAction>().index=i;
            choice.transform.SetParent(_choiceButtonsPanel.transform); 

            TextMeshProUGUI choiseText = choice.GetComponentInChildren<TextMeshProUGUI>();
            choiseText.text = currentChoices[i].text;
            _choiceText.Add(choiseText);
        }
    }
    public void ChoiceButtonAction(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
    private void ExitDialogue()
    {
        DialogPlay = false;
        _dialoguePanel.SetActive(false);
    }
}
