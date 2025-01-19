using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        DataAPIControler.instance.OnInit(InitDataDone);
    }

    private void InitDataDone()
    {
        //FB_Authentication.instance.InitFB();
        LoadingManager.instance.LoadSceneByIndex(1, () =>
        {
            //ViewManager.instances.OnSwitchView(ViewIndex.HomeView);
        });
    }
}
