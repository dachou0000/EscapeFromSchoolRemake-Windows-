using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField]
    private string DoorAnswer;
    [SerializeField]
    private TMP_InputField InputField;
    [SerializeField]
    private Animator TextAnimator;
    [SerializeField]
    private Animator DoorAnimator;
    [SerializeField]
    private Animator FalseAnimator;
    [SerializeField]
    private GameObject NextImage;//”’”wŒi

    public void DoorResponse()//FinalAnswer‚ÌŠm”F
    {
        string Response = InputField.text;
        if (Response == DoorAnswer)
        {
            TextAnimator.SetTrigger("EventText");
            DoorAnimator.SetTrigger("Open");
            NextImage.SetActive(true);
        }
        else
        {
            FalseAnimator.SetTrigger("FalseText");
        }
    }
}
