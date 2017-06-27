using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

  public  GameObject[] carModels = new GameObject[4];
    List<GameObject> preGai = new List<GameObject>();
    List<GameObject> carGulu = new List<GameObject>();
    ChangeType type = ChangeType.None;
	// Use this for initialization
    void Awake() {
        UIEventListener.Get(Utils.Find(this.gameObject, "LeftButton")).onClick = OnClickChange;
        UIEventListener.Get(Utils.Find(this.gameObject, "RightButton")).onClick = OnClickChange;
        UIEventListener.Get(Utils.Find(this.gameObject, "qiangaiBtn")).onClick = OnPreGaiHandle;

        UIEventListener.Get(Utils.Find(this.gameObject, "Container/qiangaiBtn1")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "Container/qiangaiBtn2")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "Container/qiangaiBtn3")).onClick = OnCLickSelectQianGai;
        UIEventListener.Get(Utils.Find(this.gameObject, "Container/qiangaiBtn4")).onClick = OnCLickSelectQianGai;

        //UIEventListener.Get(Utils.Find(this.gameObject, "LeftWheelBtn")).onClick = OnLeftWheelHandl;
    }        
	void Start () {
        type = ChangeType.qiangai;
        UpdateShowModle(0, type);        
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
    private void OnCLickSelectQianGai(GameObject go) {
        if (go.name == "qiangaiBtn1")
        {
            UpdateShowXiaModle(ChangeType.qiangai,0);
        }
        else if (go.name == "qiangaiBtn2")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 1);
        }
        else if (go.name == "qiangaiBtn3")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 2);
        }
        else if (go.name == "qiangaiBtn4")
        {
            UpdateShowXiaModle(ChangeType.qiangai, 3);
        }
    }
    int index = 0;         
    private void OnClickChange(GameObject go)
    {
        if (go.name == "LeftButton") {
            Debug.Log("1111");
            if (index > 0) {
                index--;
            }
        }
        else if (go.name == "RightButton") {
            Debug.Log("222");
            if (index < 3) {
                index++;
            }
        }
        for (int i = 0; i < 4; i++)
        {
            //carModels[i]
        }
        UpdateShowModle(index,type);
    }
    private void OnPreGaiHandle(GameObject go)
    {
        UpdateShowXiaModle(ChangeType.qiangai);
    }
    private void OnLeftWheelHandl(GameObject go)
    {
        //UpdateShowXiaModle(index, ChangeType.guolu);       
    }
    public void UpdateShowModle(int index,ChangeType type) {
        for (int i = 0; i < 4; i++)
        {
            if (i == index)
            {
                carModels[i].SetActive(true);
            }
            else {
                carModels[i].SetActive(false);
            }
        }
        
        
        //for (int i = 0; i < 4; i++)
        //{
        //foreach (Transform t in carModels[index].transform.FindChild("QianGaiPos").GetComponentsInChildren<Transform>())
        //{
        //  preGai.Add(t.gameObject);
        //}
        preGai.Clear();
        foreach (Transform child in carModels[index].transform.FindChild("QianGaiPos"))
        {
             preGai.Add(child.gameObject);
        }
        //}
        UpdateShowXiaModle(type);
        //preGai.Add();
    }
    
    public void UpdateShowXiaModle(ChangeType type,int qianGaiIndex=0) {
        preGai.Clear();
        foreach (Transform child in carModels[index].transform.FindChild("QianGaiPos"))
        {
            preGai.Add(child.gameObject);
        }
        switch ((int)type)
        {
            case 1:
                foreach (var item in preGai)
                {
                    item.SetActive(false);
                }
                preGai[qianGaiIndex].SetActive(true);
                break;
            case 2:

                break;
            default:
                break;
        }
    }
}
