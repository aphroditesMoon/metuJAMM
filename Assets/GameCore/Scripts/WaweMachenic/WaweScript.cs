using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaweScript : MonoBehaviour
{
    public GameObject[] objectsToSwitch;
    private int currentObjectIndex = 0;

    private void Start()
    {
        // Başlangıçta sadece ilk GameObject aktif olsun, diğerleri pasif.
        for (int i = 0; i < objectsToSwitch.Length; i++)
        {
            objectsToSwitch[i].SetActive(i == 0);
        }
    }

    private void Update()
    {
        // Aktif olan objenin çocuklarının hepsi set active false ise
        if (AllChildrenInactive(objectsToSwitch[currentObjectIndex].transform))
        {
            // Mevcut GameObject'in çocuklarını pasif yap.
            DeactivateChildren(objectsToSwitch[currentObjectIndex].transform);

            // Mevcut GameObject'u pasif yap.
            objectsToSwitch[currentObjectIndex].SetActive(false);

            if (currentObjectIndex == objectsToSwitch.Length - 1)
            {
                Time.timeScale = 0f;
                ChangeToNextScene();
            }
            else
            {
                // Sıradaki GameObject'un çocuklarını aktif yap.
                currentObjectIndex = (currentObjectIndex + 1) % objectsToSwitch.Length;
                ActivateChildren(objectsToSwitch[currentObjectIndex].transform);

                // Sıradaki GameObject'u aktif yap.
                objectsToSwitch[currentObjectIndex].SetActive(true);
            }
        }
    }
    
    private void ChangeToNextScene()
    {
        // Aktif olan sahnenin indeksini alıyoruz.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Bir sonraki sahnenin indeksi, mevcut sahnenin indeksine 1 eklenerek elde edilir.
        int nextSceneIndex = currentSceneIndex + 1;
        
        //await Task.Delay(1000);
        
        // Sonraki sahneye geçiş yapılır.
        SceneManager.LoadScene(nextSceneIndex);

        //await Task.Yield();
    }

    private bool AllChildrenInactive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void DeactivateChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ActivateChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(true);
        }
    }
}
