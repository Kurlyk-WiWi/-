using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    public int index;
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ShowLog) ;
    }
    private void ShowLog()
    {
        Debug.Log("Кнопка нажата");
    }
}
