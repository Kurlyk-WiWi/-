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
        str.text += "y++; //��� ����� \n";
        Debug.Log("y++; //��� �����");
    }
    public void ClickDown ()
    {
        str.text += "y--; //��� ���� \n";
        Debug.Log("y--; //��� ����");
    }
    public void ClickLeft()
    {
        str.text += "x--; //��� ����� \n";
        Debug.Log("x--; //��� �����");
    }
    public void ClickRight()
    {
        str.text += "x++; //��� ������ \n";
        Debug.Log("x++; //��� ������");
    }
    public void ClickReset()
    {
        str.text = "#include <iostream>\r\n\r\nint main()\r\n{\r\n    \r\n\r\n    return 0;\r\n}\r\n";
        Debug.Log("������");
    }
}
