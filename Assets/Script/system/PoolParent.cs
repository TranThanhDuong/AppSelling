using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolParent : MonoBehaviour
{
    [SerializeField]
    private string m_PoolName;
    private bool m_IsAutoClearChangeScene;
    private Queue<GameObject> m_Pooling;
    private GameObject m_Prefab;
    public void Init(string _name, GameObject _prefab, bool _isAutoClearChangeScene = false)
    {
        m_PoolName = _name;
        m_Prefab = _prefab;
        m_IsAutoClearChangeScene = _isAutoClearChangeScene;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetClearChangeSceneStatus()
    {
        return m_IsAutoClearChangeScene;
    }

    public GameObject GetPoolObject()
    {
        if(m_Pooling.Count == 0)
        {
            GameObject obj = Instantiate(m_Prefab, this.transform);
            obj.name = m_PoolName;
            return obj;
        }
        return m_Pooling.Dequeue();
    }

    public void ReturnToPool(GameObject m_PoolPrefab)
    {
        m_Pooling.Enqueue(m_PoolPrefab);
    }
}
