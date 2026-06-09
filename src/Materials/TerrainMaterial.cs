using System;
using System.Collections.Generic;
using UnityEngine;

namespace Phenotype.Terrain.Materials
{
    /// <summary>
    /// Represents a material configuration for terrain rendering.
    /// Holds a collection of properties (textures, colors, scalars) that
    /// describe the surface appearance of a terrain chunk.
    /// </summary>
    public class TerrainMaterial
    {
        /// <summary>
        /// Unique identifier for this material.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Human-readable name of the material.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Base color tint applied to the terrain surface.
        /// </summary>
        public Color BaseColor { get; set; } = Color.white;

        /// <summary>
        /// Path to the primary diffuse texture (albedo map).
        /// </summary>
        public string MainTexturePath { get; set; } = string.Empty;

        /// <summary>
        /// Path to the normal map texture.
        /// </summary>
        public string NormalMapPath { get; set; } = string.Empty;

        /// <summary>
        /// Scale of the UV tiling for the main texture.
        /// </summary>
        public float TextureScale { get; set; } = 1f;

        /// <summary>
        /// Smoothness factor for the terrain surface.
        /// </summary>
        public float Smoothness { get; set; } = 0.5f;

        /// <summary>
        /// Metallic factor for the terrain surface.
        /// </summary>
        public float Metallic { get; set; } = 0f;

        private readonly Dictionary<string, TerrainMaterialProperty> _properties;

        /// <summary>
        /// Creates a new terrain material with the specified name.
        /// </summary>
        /// <param name="name">Human-readable material name.</param>
        public TerrainMaterial(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Material name must not be null or empty.", nameof(name));

            Id = Guid.NewGuid();
            Name = name;
            _properties = new Dictionary<string, TerrainMaterialProperty>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Adds a property to the material.
        /// </summary>
        /// <param name="property">The property to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when property is null.</exception>
        /// <exception cref="ArgumentException">Thrown when a property with the same name already exists.</exception>
        public void AddProperty(TerrainMaterialProperty property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));
            if (_properties.ContainsKey(property.Name))
                throw new ArgumentException($"Property '{property.Name}' already exists.", nameof(property));

            _properties[property.Name] = property;
        }

        /// <summary>
        /// Removes a property from the material by name.
        /// </summary>
        /// <param name="name">Name of the property to remove.</param>
        /// <returns>True if the property was removed; false if it did not exist.</returns>
        public bool RemoveProperty(string name)
        {
            return _properties.Remove(name);
        }

        /// <summary>
        /// Retrieves a property by name.
        /// </summary>
        /// <param name="name">Name of the property to retrieve.</param>
        /// <returns>The matching <see cref="TerrainMaterialProperty"/>.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the property does not exist.</exception>
        public TerrainMaterialProperty GetProperty(string name)
        {
            if (!_properties.TryGetValue(name, out var property))
                throw new KeyNotFoundException($"Property '{name}' not found on material '{Name}'.");
            return property;
        }

        /// <summary>
        /// Attempts to retrieve a property by name.
        /// </summary>
        /// <param name="name">Name of the property to retrieve.</param>
        /// <param name="property">When this method returns, contains the property if found; otherwise null.</param>
        /// <returns>True if the property was found; otherwise false.</returns>
        public bool TryGetProperty(string name, out TerrainMaterialProperty property)
        {
            return _properties.TryGetValue(name, out property);
        }

        /// <summary>
        /// Returns whether a property with the given name exists.
        /// </summary>
        /// <param name="name">Property name to check.</param>
        /// <returns>True if the property exists; otherwise false.</returns>
        public bool HasProperty(string name)
        {
            return _properties.ContainsKey(name);
        }

        /// <summary>
        /// Returns a read-only view of all property names.
        /// </summary>
        public IReadOnlyCollection<string> PropertyNames => _properties.Keys;

        /// <summary>
        /// Returns the total number of properties on this material.
        /// </summary>
        public int PropertyCount => _properties.Count;
    }
}
