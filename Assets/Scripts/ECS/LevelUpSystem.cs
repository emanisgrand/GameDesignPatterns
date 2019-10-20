// (ECS) BEHAVIOR DEFINITION

using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class LevelUpSystem : ComponentSystem{
    protected override void OnUpdate() {
        // Grab every entity by that has a LevelComponent. 
        Entities.ForEach((ref LevelComponent levelComponent) => {
            levelComponent.level += 1f * Time.deltaTime;
        });
    }
}
