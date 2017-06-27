using UnityEngine;
using System.Collections;

public class Utils {

    public static GameObject Find(GameObject parent, string name)
    {
        string[] childs = name.Split('/');
        Transform p = parent.transform;
        foreach (string child in childs)
        {
            p = p.transform.Find(child);
            if (p == null)
            {               
                return null;
            }
        }

        return p.gameObject;
    }

}
public enum ChangeType { 
  None = 0,
  qiangai = 1,
  guolu =2
}
