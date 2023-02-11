using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using Michsky.MUIP;





public class TextSwapper : MonoBehaviour
{

    public ButtonManager buttonManager;
    public TMP_Text TextUI;

    public string Text1;
    public string Text2;
    private string currentText;

    public void SwapText()
    {
        if(currentText != Text1)
        {
            currentText = Text1;
        }
        else
        {
            currentText = Text2;
        }

        SetTextNow();
    }

    private void SetTextNow()
    {
        if(buttonManager != null)
            buttonManager.SetText(currentText);
    }
}
