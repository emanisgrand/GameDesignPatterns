﻿
using UnityEngine;

public class SpawnCubes : MonoBehaviour {
    public GameObject cube;
    public int rows;
    public int cols;
    void Start() {
        for (int x = 0; x < rows; x++) {
            for (int z = 0; z < cols; z++) {
                GameObject instance = Instantiate(cube);
                // use Perlin noise to give the y vector an uneven terrain. 
                Vector3 pos = new Vector3(x, Mathf.PerlinNoise(x*0.21f, z*0.21f),z);

                instance.transform.position = pos;
            }
        }
    }
}