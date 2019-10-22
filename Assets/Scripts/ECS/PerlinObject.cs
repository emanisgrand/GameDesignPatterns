using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class PerlinObject : MonoBehaviour {
    [SerializeField]
    private Mesh mesh;
    [SerializeField]
    private Material material;

    private void Start() {
        EntityManager entityManager = World.Active.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(LevelComponent),
            typeof(RenderMesh),
            typeof(LocalToWorld)
        );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(100, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        for (int i = 0; i < entityArray.Length; i++) {
            Entity entity = entityArray[i];

            for (int x = 0; x < 10; x++) {
                for (int z = 0; z < 10; z++) {
                    var pos = math.transform(float4x4.identity, //this needs to reference the entity's LocalToWorld params
                        new float3 ( x, 
                                    noise.cnoise(new float2(x, z) * 0.21f), 
                                     z));   
                    
                    
                    entityManager.SetComponentData(entity,
                        new Translation {Value = pos});
                }
            }
            
            entityManager.SetSharedComponentData(entity, 
                new RenderMesh {
                // and I'll bet physics is also shared component data. 
                // so is sound probably?
                mesh = mesh,
                material = material
            });
        }
        entityArray.Dispose();
    }
}