// (ECS) CONSTRUCTOR

using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using Random = UnityEngine.Random;

public class Testing : MonoBehaviour {
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    
    void Start() {
        EntityManager entityManager = World.Active.EntityManager;

        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(LevelComponent),
            typeof(Translation),
            // This is a shared component 
            typeof(RenderMesh),  
            // in order to view the RenderMesh
            typeof(LocalToWorld),
            typeof(MoveSpeedComponent)
        );
        NativeArray<Entity> entityArray = new NativeArray<Entity>(1000, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);
//      Entity entity = entityManager.CreateEntity(entityArchetype);  --before creating an array
//      Entity entity = entityManager.CreateEntity(typeof(LevelComponent)); --before archetype constructor

        for (int i = 0; i < entityArray.Length; i++) {
            Entity entity = entityArray[i];
            entityManager.SetComponentData(entity, 
                new LevelComponent {
                    level = Random.Range(10f, 20f)
                });
            
            entityManager.SetComponentData(entity, 
                new MoveSpeedComponent {
                    moveSpeed = Random.Range(1f, 2f)
                });
            
            entityManager.SetComponentData(entity, 
                new Translation {
                        Value = new float3( Random.Range(-8f, 8f), 
                                            Random.Range(-5, 5f), 
                                            0)
                });
            
            entityManager.SetSharedComponentData(entity, 
                new RenderMesh {
                    /*
                        public Mesh mesh;
                        public Material material;
                        public int subMesh
                        [LayerField] public int layer;
                        (bool)ShadowCastingMode castShadows;
                        bool receiveShadows;
                    */
                    mesh = mesh,
                    material = material,
             });
        }
        entityArray.Dispose();
    }
}