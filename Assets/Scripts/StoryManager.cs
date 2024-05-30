using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance { get; private set; }
    public Story CurrentStory { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Чтобы объект не уничтожался при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetStory(Story story)
    {
        CurrentStory = story;
    }

    public void SaveStoryState()
    {
        if (CurrentStory != null)
        {
            PlayerPrefs.SetString("SavedStoryState", CurrentStory.state.ToJson());
            PlayerPrefs.Save();
        }
    }

    public void LoadStoryState()
    {
        string savedStoryState = PlayerPrefs.GetString("SavedStoryState", string.Empty);
        if (!string.IsNullOrEmpty(savedStoryState) && CurrentStory != null)
        {
            CurrentStory.state.LoadJson(savedStoryState);
        }
    }

    public void ResetStoryState()
    {
        if (CurrentStory != null)
        {
            CurrentStory.ResetState();
        }
    }
}
