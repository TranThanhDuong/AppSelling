using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class DataAPIControler : Singleton<DataAPIControler>
{
    [SerializeField]
    private DataBaseLocal model;
    // Start is called before the first frame update
    private Dictionary<string, EquipmentData> weapons;
    private Dictionary<string, EquipmentData> equips;
    private Dictionary<string, EquipmentData> bodys;
    private Dictionary<string, EquipmentData> missions;
    private PlayerInfo info;
    public void OnInit(Action callback)
    {
        if (model.LoadData())
        {
            callback?.Invoke();

        }
        else
        {
            PlayerData playerData = new PlayerData();
            PlayerInfo info_ = new PlayerInfo();
            info_.userName = "";
            info_.exp = 0;
            info_.level = 1;
            info_.uuid = "";
            info_.email = "";
            info_.bodyID = 1;
            info_.equipID = 1;
            info_.gunID = 1;
            playerData.playerInfo = info_;

            PlayerInventory inventory = new PlayerInventory();

            playerData.playerInventory = inventory;

            Dictionary<string, EquipmentData> gunCollection_ = new Dictionary<string, EquipmentData>();
            Dictionary<string, EquipmentData> bodyCollection_ = new Dictionary<string, EquipmentData>();
            Dictionary<string, EquipmentData> equipCollection_ = new Dictionary<string, EquipmentData>();
            Dictionary<string, EquipmentData> missionCollection_ = new Dictionary<string, EquipmentData>();
            EquipmentData main = new EquipmentData();
            main.id = 1;
            main.level = 1;
            gunCollection_.Add(main.id.ToKey(), main);

            bodyCollection_.Add(main.id.ToKey(), main);

            equipCollection_.Add(main.id.ToKey(), main);

            main.level = 0;
            missionCollection_.Add(main.id.ToKey(), main);

            playerData.gunCollection = gunCollection_;
            playerData.bodyCollection = bodyCollection_;
            playerData.equipCollection = equipCollection_;
            playerData.missionCollection = missionCollection_;

            playerData.TimeLogin = DateTime.Now.ToString();

            model.CreateNewData(playerData);
            callback?.Invoke();

        }
        // setting get data 
        info = model.Read<PlayerInfo>(DataPath.PLAYER_INFO);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_INFO, (data) =>
        {
            info = (PlayerInfo)data;
        });
        weapons = model.Read<Dictionary<string, EquipmentData>>(DataPath.PLAYER_WEAPON);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_WEAPON, (data) =>
        {
            weapons = (Dictionary<string, EquipmentData>)data;
        });
        bodys = model.Read<Dictionary<string, EquipmentData>>(DataPath.PLAYER_BODY);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_BODY, (data) =>
        {
            bodys = (Dictionary<string, EquipmentData>)data;
        });
        equips = model.Read<Dictionary<string, EquipmentData>>(DataPath.PLAYER_EQUIP);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_EQUIP, (data) =>
        {
            equips = (Dictionary<string, EquipmentData>)data;
        });

        missions = model.Read<Dictionary<string, EquipmentData>>(DataPath.PLAYER_MISSION);
        DataTrigger.RegisterValueChange(DataPath.PLAYER_MISSION, (data) =>
        {
            missions = (Dictionary<string, EquipmentData>)data;
        });

    }
    //public void GetData(Action<bool> callback)
    //{
    //    bool isOK = false;
    //    HTTPController.instance.Post(PATH.GETDATA, null, (dataUser)=> {

    //        if (dataUser != "")
    //        {
    //            //Debug.LogError(dataUser);
    //            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(dataUser);
    //            model.CreateNewData(data);
    //            isOK = true;
    //            callback?.Invoke(isOK);
    //        }
    //        else
    //        {
    //            callback?.Invoke(isOK);
    //        }
    //    });
    //}
    //public void CreateNewData(object dataSend, Action<bool> callback)
    //{
    //    HTTPController.instance.Post(PATH.CREATENEWDATA, dataSend, (dataUser) => {

    //        if (dataUser != "")
    //        {
    //            //Debug.LogError("2:::::"+dataUser);
    //            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(dataUser);
    //            model.CreateNewData(data);
    //            callback?.Invoke(true);
    //        }
    //        else
    //        {
    //            callback?.Invoke(false);
    //        }
    //    });
    //}
    public PlayerInfo GetPlayerInfo()
    {
        return model.Read<PlayerInfo>(DataPath.PLAYER_INFO);
    }
    public PlayerInventory GetPlayerInventory()
    {
        return model.Read<PlayerInventory>(DataPath.PLAYER_INVENTORY);
    }

    //public void UpdateMission(int id, int level)
    //{
    //    EquipmentData send = new EquipmentData { id = id, level = level };
    //    HTTPController.instance.Post(PATH.UPDATE_MISSION, send, (mess) => {
    //        Debug.LogError(mess);
    //        if (mess != "")
    //        {
    //            Dictionary<string,EquipmentData> data = JsonConvert.DeserializeObject<Dictionary<string, EquipmentData>>(mess);
    //            model.UpdateData(DataPath.PLAYER_MISSION, data, null);
    //        }
    //        else
    //            Debug.LogError("NULL!");
    //    });
    //}
}