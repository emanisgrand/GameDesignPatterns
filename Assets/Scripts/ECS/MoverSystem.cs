// (ECS) BEHAVIOR DEFINITION

using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public class MoverSystem : ComponentSystem {
    protected override void OnUpdate() {
        // grab every entity that has a Translation and MoveSpeedComponent
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) => {
            // change the value of their translation.y
            translation.Value.y += moveSpeedComponent.moveSpeed * Time.deltaTime;
            
            // Move down when you reach the top of the screen, and up when you reach the bottom.
            if (translation.Value.y > 5f) {
                moveSpeedComponent.moveSpeed = -math.abs(moveSpeedComponent.moveSpeed);
            }
            if (translation.Value.y < -5) {
                moveSpeedComponent.moveSpeed = +math.abs(moveSpeedComponent.moveSpeed);
            }
        });
    }
}