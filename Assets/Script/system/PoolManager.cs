using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PoolManager : Singleton<PoolManager>
{
    private Dictionary<string, PoolParent> m_DicPools;
    // Start is called before the first frame update
    void Start()
    {
        m_DicPools = new Dictionary<string, PoolParent>();
        //Add Action Change Scene here
        // += ClearPoolChangeScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClearPoolChangeScene()
    {
        foreach(var child in m_DicPools.Where(x => x.Value.GetClearChangeSceneStatus() == true).ToList())
        {
            m_DicPools.Remove(child.Key);
        }
    }

    public void AddNewPool(string _name, GameObject _prefab, bool _isAutoClearChangeScene = false)
    {
        if (m_DicPools.ContainsKey(_name))
            return;

        GameObject newPool = new GameObject(_name + "Parent");
        newPool.transform.SetParent(this.transform);
        newPool.transform.position = Vector3.zero;
        PoolParent poolParent = newPool.AddComponent<PoolParent>();
        m_DicPools.Add(_name, poolParent);
    }

    public T GetPoolObject<T>(string _name)
    {
        object data = null;
        if (m_DicPools.ContainsKey(_name))
        {
            GameObject pool = m_DicPools[_name].GetPoolObject();
            data = pool.GetComponent<T>();
            if (data == null)
                ReturnToPoolParent(_name, pool);
        }
        return (T)data;
    }

    public void ReturnToPoolParent(string _name, GameObject m_PoolPrefab)
    {
        if (!m_DicPools.ContainsKey(_name))
        {
            Destroy(m_PoolPrefab);
            return;
        }
        m_DicPools[_name].ReturnToPool(m_PoolPrefab);
    }
}
