using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingBar;
    public GameObject prefabToTransfer;
    public int prefabNumberToTransfer;

    private AsyncOperation async;




    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            if (async.progress == 0.9f)
            {
                loadingBar.value = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }

        TransferPrefab();
    }

    private void TransferPrefab()
    {
        GameObject spawnAgentObj = GameObject.FindWithTag("SpawnAgent");
        if (spawnAgentObj != null)
        {
            SpawnAgent spawnAgent = spawnAgentObj.GetComponent<SpawnAgent>();
            spawnAgent.UpdateAgent(prefabNumberToTransfer);
        }
    }

    public void UpdateAgentInt(int _agentInt)
    {
        prefabNumberToTransfer = _agentInt;
    }
}