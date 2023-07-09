using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationControl: MonoBehaviour
{
    [SerializeField]
    private Animator OpeningAnimation;
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private TextMeshProUGUI EventText;
    [SerializeField]
    private string[] MessageEnd;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.gameObject.SetActive(false);
        OpeningAnimation.SetTrigger("Opening");
    }

    public void OpeningEnd()
    {
        Canvas.gameObject.SetActive(true);
    }
}
