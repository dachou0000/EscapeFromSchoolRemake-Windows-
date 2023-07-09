using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    [SerializeField]
    private GameObject RightPanel;
    [SerializeField]
    private GameObject LeftPanel;
    [SerializeField]
    private GameObject UnderPanel;
    [SerializeField]
    private Camera[] CameraPosition;
    [SerializeField]
    private GameObject[] UpCameraFront;
    [SerializeField]
    private GameObject[] UpCameraRight;
    [SerializeField]
    private GameObject[] UpCameraLeft;
    [SerializeField]
    private GameObject[] UpCameraBack;
    private GameObject[][] UpCameraControl = new GameObject[4][];
    [SerializeField]
    private Camera CameraActive;
    [SerializeField]
    private TMP_InputField DoorInputField;
    [SerializeField]
    private Image InputFieldImage;

    [SerializeField]
    private EventSystem EventSystem;
    private int CameraControl = 0;

    public ItemControl ItemControl;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < CameraPosition.Length; ++i) { CameraPosition[i].enabled = false; }//正面以外のカメラをOFF
        CameraPosition[CameraControl].enabled = true;//正面のカメラをON
        UnderPanel.SetActive(false);//下のボタンをoff
        RightPanel.SetActive(true); LeftPanel.SetActive(true);//左右のパネルをon
        /*拡大できるボタンが格納された配列を2次元配列に入れていく*/
        UpCameraControl[0] = UpCameraFront;
        UpCameraControl[1] = UpCameraRight;
        UpCameraControl[2] = UpCameraBack;
        UpCameraControl[3] = UpCameraLeft;
        for(int i = 1; i < 4; ++i)
        {
            for(int t = 0; t < UpCameraControl[i].Length; ++t) { UpCameraControl[i][t].SetActive(false); }//正面以外の拡大できるボタンを全てOFF
        }
        DoorInputField.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Item取得のif文
        {
            Ray ray = CameraActive.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 40.0f))
            {
                if (hit.collider.gameObject.tag == "Item") { ItemControl.ItemGet(hit.collider.gameObject); }//"アイテム"タグを付与し、ItemGetを呼び出す
            }
        }
    }

    public void RightTurn()//右のパネルを押すと回転する
    {
        CameraPosition[CameraControl].enabled = false;//今の視点のカメラをOFF
        for(int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(false); }//今の視点の拡大できるボタンを全てOFF
        /*要素番号をずらす*/
        if (CameraControl == CameraPosition.Length - 1) { CameraControl = 0; }
        else { ++CameraControl; }

        CameraPosition[CameraControl].enabled = true;//右に９０度回転後の視点のカメラをON
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(true); }//右に９０度回転後の視点の拡大できるボタンを全てON
    }

    public void LeftTurn()//左のパネルを押すと回転する
    {
        CameraPosition[CameraControl].enabled = false;//今の視点のカメラをOFF
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(false); }//今の視点の拡大できるボタンを全てOFF
        /*要素番号をずらす*/
        if (CameraControl == 0) { CameraControl = CameraPosition.Length - 1; }
        else { --CameraControl; }

        CameraPosition[CameraControl].enabled = true;//左に９０度回転後の視点のカメラをON
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(true); }//左の視点の拡大できるボタンを全てOFF
    }

    public void Under()//ズームアウトする
    {
        CameraActive.enabled = false;
        DoorInputField.enabled = false;
        InputFieldImage.enabled = true;
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i)
        {
            UpCameraControl[CameraControl][i].SetActive(true);//拡大できるボタンを全てON
        }
        UnderPanel.SetActive(false);//下のパネルをOFF
        RightPanel.SetActive(true); LeftPanel.SetActive(true);//左右のパネルをON
    }

    public void UpCamera()//ズームインする
    {
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) 
        {
            UpCameraControl[CameraControl][i].SetActive(false);//拡大できるボタンを全てOFF
        }
        GameObject UpCameraGet = EventSystem.currentSelectedGameObject;//押されたボタンのオブジェクトを取得
        GameObject find = GameObject.Find(UpCameraGet.name + "UpCamera");//↑で取得したオブジェクト名＋UpCameraを探す
        CameraActive = find.GetComponent<Camera>();//Cameraを取得
        CameraActive.enabled = true;//↑のCameraをON
        UnderPanel.SetActive(true);//下のパネルをON
        RightPanel.SetActive(false); LeftPanel.SetActive(false);//左右のパネルをON
    }

    public void Locker()//真ん中のロッカーの際に、InputFieldで入力できないのを防ぐ
    {
        InputFieldImage.enabled = false;
    }

    public void DoorUp()//Doorを拡大したときのみInputFieldを入力可能にする
    {
        DoorInputField.enabled = true;
    }
}