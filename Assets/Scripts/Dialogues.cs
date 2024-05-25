using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Dialogues : MonoBehaviour
{
    private Story _currentStory;
    private TextAsset _inkJson;

    private GameObject _dialoguePanel;
    private TextMeshProUGUI _dialogueText;
    private TextMeshProUGUI _nameText;

    [HideInInspector] public GameObject _choiceButtonsPanel;
    private GameObject _choiceButton;
    private List<TextMeshProUGUI> _choicesText = new();
    private List<Character> characters = new();
    private List<Locations> locations = new();
    private Audies audies;
    private int currentMusicIndex = -1; // Текущий индекс воспроизводимой музыки
    private float multiplier = 1.1f;
    private Stack<string> _dialogueHistory = new Stack<string>();
    public bool DialogPlay { get; private set; }
    [Inject]
    public void Construct(DialoguesInstaller dialoguesInstaller)
    {
        _inkJson = dialoguesInstaller.inkJson;
        _dialoguePanel = dialoguesInstaller.dialoguePanel;
        _dialogueText = dialoguesInstaller.dialogueText;
        _nameText = dialoguesInstaller.nameText;
        _choiceButtonsPanel = dialoguesInstaller.choiceButtonsPanel;
        _choiceButton = dialoguesInstaller.choiceButton;
    }
    private void Awake()
    {
        _currentStory = new Story(_inkJson.text);
        audies = FindObjectOfType<Audies>();
    }
    void Start()
    {
        foreach (var character in FindObjectsOfType<Character>())
        {
            characters.Add(character);
        }
        foreach (var location in FindObjectsOfType<Locations>())
        {
            locations.Add(location);
        }
        StartDialogue();

    }
    public void StartDialogue()
    {
        DialogPlay = true;
        _dialoguePanel.SetActive(true);
        ContinueStory();
    }
    public void ContinueStory(bool choiceBefore = false)
    {
        if (_currentStory.canContinue)
        {
            ShowDialogue();
            ShowChoiceButtons();
        }
        else if(!choiceBefore)
        {
            ExitDialogue();
        }
    }
    public void GoBackDialogue()
    {
        if (_dialogueHistory.Count > 0)
        {
            _currentStory.state.LoadJson(_dialogueHistory.Pop());
            ShowDialogue();
            ShowChoiceButtons();
        }
        else
        {
            Debug.Log("Нельзя вернуться назад.");
        }
    }
    private void DisableAllCharactersExcept(int index)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (i != index)
            {
                characters[i].SetExpressionState(0);
            }
        }
    }

    private void ShowDialogue()
    {
        string currentDialogueState = _currentStory.state.ToJson();
        _dialogueHistory.Push(currentDialogueState);
        _dialogueText.text = _currentStory.Continue();
        _nameText.text = (string)_currentStory.variablesState["characterName"];

        var index = characters.FindIndex(character => character.characterName.Contains(_nameText.text));
        characters[index].ChangeEmotion((int)_currentStory.variablesState["characterExpression"]);

        // Process tags
        foreach (string tag in _currentStory.currentTags)
        {
            // Check for switchExpression tag
            if (tag.StartsWith("switchExpression:"))
            {
                var parts = tag.Split(':');
                if (parts.Length > 1 && int.TryParse(parts[1], out int switchState))
                {
                    characters[index].SetExpressionState(switchState);
                }
            }

            // Check for other tags if needed
        }
        // Получаем значение переменной "Music" из истории и воспроизводим соответствующий трек
        if (_currentStory.variablesState.Contains("Music"))
        {
            int musicIndex = (int)_currentStory.variablesState["Music"];
            if (audies != null && musicIndex != currentMusicIndex)
            {
                currentMusicIndex = musicIndex;
                audies.PlayAudioByIndex(musicIndex);
            }
            else if (audies == null)
            {
                Debug.LogWarning("Audies компонент не найден.");
            }
        }
        // Получаем значение переменной "Location" из истории
        int locationValue = (int)_currentStory.variablesState["Location"];

        // Применяем значение "Location" к объекту Locations
        foreach (var location in locations)
        {
            location.ChangeLocation(locationValue);
        }
        ChangeCharacterScale(index);
    }
    private void ChangeCharacterScale(int indexCharacter)
    {
        if (indexCharacter>=0)
        {
            foreach (var character in characters)
            {
                if (character!=characters[indexCharacter])
                {
                    character.ResetScale();
                }
                else if(character.DefaultScale == character.transform.localScale)
                {
                    character.ChangeScale(multiplier);
                }
            }
        }
        else
        {
            characters.ForEach(character => character.ResetScale());
        }
    }
    private void ShowChoiceButtons()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;
        _choiceButtonsPanel.SetActive(currentChoices.Count != 0);
        if (currentChoices.Count<=0){return;}
        _choiceButtonsPanel.transform.Cast<Transform>().ToList().ForEach(child => Destroy(child.gameObject));
        _choicesText.Clear();
        for (int i = 0; i < currentChoices.Count; i++)
        {
            GameObject choice = Instantiate(_choiceButton);
            choice.GetComponent<ButtonAction>().index = i;
            choice.transform.SetParent(_choiceButtonsPanel.transform);

            TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = currentChoices[i].text;
            _choicesText.Add(choiceText);
        }
    }
    public void ChoiceButtonAction(int choiceIndex)
    {
        _currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(true);
    }
    private void ExitDialogue()
    {
        DialogPlay = false;
        _dialoguePanel.SetActive(false);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex<=SceneManager.sceneCount)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

}
