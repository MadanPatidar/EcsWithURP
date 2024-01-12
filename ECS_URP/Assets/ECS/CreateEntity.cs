using Unity.Entities;
using UnityEngine;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;
using Unity.Mathematics;
using System;

public class CreateEntity : MonoBehaviour
{   
    [SerializeField] Mesh mesh;
    [SerializeField] Material material;

    private void Start()
    {

        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(Translation),
             typeof(RenderMesh),
             typeof(LocalToWorld),
             typeof(MoveSpeedComponent)
            );

        NativeArray<Entity> arrayEntities = new NativeArray<Entity>(500, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, arrayEntities);

        /* entityArchetype = entityManager.CreateArchetype(typeof(LevelComponent));
         entity = entityManager.CreateEntity(entityArchetype);*/

        //Entity entity = entityManager.CreateEntity(typeof(LevelComponent));

        for (int i = 0; i< arrayEntities.Length; i++)
        {
            Entity entity = arrayEntities[i];

            entityManager.SetComponentData(entity,
                new LevelComponent
                {
                    LevenNumber = UnityEngine.Random.Range(10, 20)
                }
                );
            entityManager.SetComponentData(entity,
                new MoveSpeedComponent
                {
                    moveSpeed = UnityEngine.Random.Range(-2f, 2f)
                }
                );
            entityManager.SetComponentData(entity,
                new Translation {
                    Value = new float3(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-25, 25), UnityEngine.Random.Range(-5f, 5f))
                }
                );
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material
            });

            //---
            float fColorR = UnityEngine.Random.Range(0f, 0.9f);
            float fColorG = UnityEngine.Random.Range(0f, 0.9f);
            float fColorB = UnityEngine.Random.Range(0f, 0.9f);
            RenderMesh renderMesh = entityManager.GetSharedComponentData<RenderMesh>(entity);
            renderMesh.material.color = new UnityEngine.Color(fColorR, fColorG, fColorB, 1);
            entityManager.SetSharedComponentData(entity, renderMesh);
            //---

        }

        arrayEntities.Dispose();
    }

}