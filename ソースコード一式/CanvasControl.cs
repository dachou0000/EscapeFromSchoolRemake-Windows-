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
        for(int i = 1; i < CameraPosition.Length; ++i) { CameraPosition[i].enabled = false; }//���ʈȊO�̃J������OFF
        CameraPosition[CameraControl].enabled = true;//���ʂ̃J������ON
        UnderPanel.SetActive(false);//���̃{�^����off
        RightPanel.SetActive(true); LeftPanel.SetActive(true);//���E�̃p�l����on
        /*�g��ł���{�^�����i�[���ꂽ�z���2�����z��ɓ���Ă���*/
        UpCameraControl[0] = UpCameraFront;
        UpCameraControl[1] = UpCameraRight;
        UpCameraControl[2] = UpCameraBack;
        UpCameraControl[3] = UpCameraLeft;
        for(int i = 1; i < 4; ++i)
        {
            for(int t = 0; t < UpCameraControl[i].Length; ++t) { UpCameraControl[i][t].SetActive(false); }//���ʈȊO�̊g��ł���{�^����S��OFF
        }
        DoorInputField.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//Item�擾��if��
        {
            Ray ray = CameraActive.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 40.0f))
            {
                if (hit.collider.gameObject.tag == "Item") { ItemControl.ItemGet(hit.collider.gameObject); }//"�A�C�e��"�^�O��t�^���AItemGet���Ăяo��
            }
        }
    }

    public void RightTurn()//�E�̃p�l���������Ɖ�]����
    {
        CameraPosition[CameraControl].enabled = false;//���̎��_�̃J������OFF
        for(int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(false); }//���̎��_�̊g��ł���{�^����S��OFF
        /*�v�f�ԍ������炷*/
        if (CameraControl == CameraPosition.Length - 1) { CameraControl = 0; }
        else { ++CameraControl; }

        CameraPosition[CameraControl].enabled = true;//�E�ɂX�O�x��]��̎��_�̃J������ON
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(true); }//�E�ɂX�O�x��]��̎��_�̊g��ł���{�^����S��ON
    }

    public void LeftTurn()//���̃p�l���������Ɖ�]����
    {
        CameraPosition[CameraControl].enabled = false;//���̎��_�̃J������OFF
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(false); }//���̎��_�̊g��ł���{�^����S��OFF
        /*�v�f�ԍ������炷*/
        if (CameraControl == 0) { CameraControl = CameraPosition.Length - 1; }
        else { --CameraControl; }

        CameraPosition[CameraControl].enabled = true;//���ɂX�O�x��]��̎��_�̃J������ON
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) { UpCameraControl[CameraControl][i].SetActive(true); }//���̎��_�̊g��ł���{�^����S��OFF
    }

    public void Under()//�Y�[���A�E�g����
    {
        CameraActive.enabled = false;
        DoorInputField.enabled = false;
        InputFieldImage.enabled = true;
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i)
        {
            UpCameraControl[CameraControl][i].SetActive(true);//�g��ł���{�^����S��ON
        }
        UnderPanel.SetActive(false);//���̃p�l����OFF
        RightPanel.SetActive(true); LeftPanel.SetActive(true);//���E�̃p�l����ON
    }

    public void UpCamera()//�Y�[���C������
    {
        for (int i = 0; i < UpCameraControl[CameraControl].Length; ++i) 
        {
            UpCameraControl[CameraControl][i].SetActive(false);//�g��ł���{�^����S��OFF
        }
        GameObject UpCameraGet = EventSystem.currentSelectedGameObject;//�����ꂽ�{�^���̃I�u�W�F�N�g���擾
        GameObject find = GameObject.Find(UpCameraGet.name + "UpCamera");//���Ŏ擾�����I�u�W�F�N�g���{UpCamera��T��
        CameraActive = find.GetComponent<Camera>();//Camera���擾
        CameraActive.enabled = true;//����Camera��ON
        UnderPanel.SetActive(true);//���̃p�l����ON
        RightPanel.SetActive(false); LeftPanel.SetActive(false);//���E�̃p�l����ON
    }

    public void Locker()//�^�񒆂̃��b�J�[�̍ۂɁAInputField�œ��͂ł��Ȃ��̂�h��
    {
        InputFieldImage.enabled = false;
    }

    public void DoorUp()//Door���g�債���Ƃ��̂�InputField����͉\�ɂ���
    {
        DoorInputField.enabled = true;
    }
}