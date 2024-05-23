using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public List<Sprite> emotions;
    public string characterName;
    private Vector3 defaultScale;
    public Vector3 DefaultScale => defaultScale;
    private void OnEnable()
    {
        defaultScale = transform.localScale;
    }
    public void ChangeEmotion(int currentExpression)
    {
        GetComponent<Image>().sprite = emotions[currentExpression];
    }
    public void ChangeScale(float multiplier)
    {
        transform.localScale *= multiplier;
    }
    public void ResetScale()
    {
        transform.localScale = defaultScale;
    }
    public void SetExpressionState(int state)
    {
        if (state == 1)
        {
            // Включить выражение
            this.gameObject.SetActive(true);
        }
        else
        {
            // Отключить выражение
            this.gameObject.SetActive(false);
        }
    }


}
