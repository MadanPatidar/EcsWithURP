using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using Unity.Collections;

public class ChangeSceneScript : MonoBehaviour
{
    public Button NextSceneButton;
    public Text txtButton;

    public string buttonName;
    public string sceneName;

    private void Start()
    {
        NextSceneButton.onClick.AddListener(NextSceneButtonTap);
        txtButton.text = buttonName;
    }

    void NextSceneButtonTap()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        NativeArray<Entity> arrayEntities = entityManager.GetAllEntities();
        foreach (Entity entity in arrayEntities)
        {
            if (entity != null)
                entityManager.DestroyEntity(entity);
        }

        Application.LoadLevel(sceneName);    
    }

}