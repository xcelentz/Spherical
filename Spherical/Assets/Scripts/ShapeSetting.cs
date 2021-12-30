using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSetting : ScriptableObject
{
   public float planetRadius = 1;
   public NoiseLayer[] noiseLayers;
   
   [System.Serializable]
   public class NoiseLayer
   {
      public NoiseSetting noiseSettings;
      public bool enabled = true;
      public bool useFirstLayerAsMask;
   }
}
