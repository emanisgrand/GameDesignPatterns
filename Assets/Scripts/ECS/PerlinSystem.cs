﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

public class PerlinSystem : ComponentSystem {
    
    
    
    protected override void OnUpdate() {
        Entities.ForEach((ref Translation translation) => {
            
        });
    }
}