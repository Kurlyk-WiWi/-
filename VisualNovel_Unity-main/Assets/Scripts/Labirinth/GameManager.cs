using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text str;
    // Start is called before the first frame update
    void Start()
    {
        str.text = "#include <iostream>\r\n\r\nint main()\r\n{\r\n    \r\n\r\n    return 0;\r\n}\r\n";
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ClickUp ()
    {
        str.text += "y++; //шаг вверх \n";
        Debug.Log("y++; //шаг вверх");
    }
    public void ClickDown ()
    {
        str.text += "y--; //шаг вниз \n";
        Debug.Log("y--; //шаг вниз");
    }
    public void ClickLeft()
    {
        str.text += "x--; //шаг влево \n";
        Debug.Log("x--; //шаг влево");
    }
    public void ClickRight()
    {
        str.text += "x++; //шаг вправо \n";
        Debug.Log("x++; //шаг вправо");
    }
    public void ClickReset()
    {
        str.text = "#include <iostream>\r\n\r\nint main()\r\n{\r\n    \r\n\r\n    return 0;\r\n}\r\n";
        Debug.Log("заново");
    }
}
