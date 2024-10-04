using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class PostYardNormal : PostYardBase
{

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
    public override void InitState()
    {
        throw new System.NotImplementedException();
    }
    public override void HandleEffect()
    {
        throw new System.NotImplementedException();
    }

    
    #region ToolEdit
    public void HandleSave()
    {
        var lsid = new List<int>();
        foreach (var item in lsNearYard)
        {
            lsid.Add(item.id);
        }

        var temp = JsonConvert.SerializeObject(lsid);
        PlayerPrefs.SetString("HexaMap" + id.ToString(), temp);
        Debug.LogError("Save");
    }

    public void HandleLoad()
    {
        lsNearYard = new List<PostYardBase>();
        var data = PlayerPrefs.GetString("HexaMap" + id.ToString());
        var tempLoad = JsonConvert.DeserializeObject<List<int>>(data);
        foreach (var item in tempLoad)
        {
           
            lsNearYard.Add(PostYardController.Instance.GetPostYardBase(item));
        }
        Debug.LogError("Load");
    }
    #endregion

}
