using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBaseData
{
    public string name;
}

public class PoolBase : MonoBehaviour
{
    private string _name;

    public virtual void Init(PoolBaseData data)
    {
        //Override must use base.Init(data);
        _name = data.name;
    }

    public virtual void OnSpawned()
    {

    }

    protected void OnDespawned()
    {
        this.gameObject.SetActive(false);
        PoolManager.instance.ReturnToPoolParent(_name, this.gameObject);
    }

}
