using UnityEngine;

namespace Phenotype.Terrain.Materials
{
    /// <summary>
    /// Defines the data type of a terrain material property.
    /// </summary>
    public enum TerrainMaterialPropertyType
    {
        /// <summary>A scalar float value.</summary>
        Float,
        /// <summary>A 4-component color value.</summary>
        Color,
        /// <summary>A 2D texture reference.</summary>
        Texture,
        /// <summary>A 3-component vector value.</summary>
        Vector,
    }
}
