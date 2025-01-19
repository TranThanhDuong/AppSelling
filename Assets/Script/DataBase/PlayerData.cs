using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData 
{
    [SerializeField]
    public PlayerInfo playerInfo= new PlayerInfo();
    [SerializeField]
    public PlayerInventory playerInventory = new PlayerInventory();
    [SerializeField]
    public Dictionary<string, EquipmentData> gunCollection = new Dictionary<string, EquipmentData>();
    [SerializeField]
    public Dictionary<string, EquipmentData> bodyCollection = new Dictionary<string, EquipmentData>();
    [SerializeField]
    public Dictionary<string, EquipmentData> equipCollection = new Dictionary<string, EquipmentData>();
    [SerializeField]
    public Dictionary<string, EquipmentData> missionCollection = new Dictionary<string, EquipmentData>();
    [SerializeField]
    public string TimeLogin;

}
[Serializable]
public class PlayerInfo
{
    public string uuid;
    public string email;
    public string userName;
    public int exp;
    public int level;
    public int gunID;
    public int bodyID;
    public int equipID;
}
[Serializable]
public class PlayerInventory
{
    [SerializeField]
    public Dictionary<string, int> items = new Dictionary<string, int>();

}
[Serializable]
public class EquipmentData
{
    public int id;
    public int level;
}


public static class DataUtilities
{

    public static string ToKey(this object data)
    {
        return "K_" + data.ToString();
    }
 
}