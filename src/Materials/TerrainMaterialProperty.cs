using System;
using UnityEngine;

namespace Phenotype.Terrain.Materials
{
    /// <summary>
    /// Represents a single property of a terrain material, such as a texture,
    /// color, or scalar parameter used by the rendering pipeline.
    /// </summary>
    public class TerrainMaterialProperty
    {
        /// <summary>
        /// Name of the property. Used as the key when binding to shaders.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Data type of this property.
        /// </summary>
        public TerrainMaterialPropertyType Type { get; }

        private float _floatValue;
        private Color _colorValue;
        private string _texturePath;
        private Vector3 _vectorValue;

        /// <summary>
        /// Creates a float property.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="value">Initial float value.</param>
        public TerrainMaterialProperty(string name, float value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Property name must not be null or empty.", nameof(name));

            Name = name;
            Type = TerrainMaterialPropertyType.Float;
            _floatValue = value;
        }

        /// <summary>
        /// Creates a color property.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="value">Initial color value.</param>
        public TerrainMaterialProperty(string name, Color value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Property name must not be null or empty.", nameof(name));

            Name = name;
            Type = TerrainMaterialPropertyType.Color;
            _colorValue = value;
        }

        /// <summary>
        /// Creates a texture property.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="texturePath">Path or identifier for the texture asset.</param>
        public TerrainMaterialProperty(string name, string texturePath)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Property name must not be null or empty.", nameof(name));

            Name = name;
            Type = TerrainMaterialPropertyType.Texture;
            _texturePath = texturePath ?? string.Empty;
        }

        /// <summary>
        /// Creates a vector property.
        /// </summary>
        /// <param name="name">Property name.</param>
        /// <param name="value">Initial vector value.</param>
        public TerrainMaterialProperty(string name, Vector3 value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Property name must not be null or empty.", nameof(name));

            Name = name;
            Type = TerrainMaterialPropertyType.Vector;
            _vectorValue = value;
        }

        /// <summary>
        /// Gets or sets the float value. Only valid when <see cref="Type"/> is <see cref="TerrainMaterialPropertyType.Float"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the property is not a float type.</exception>
        public float FloatValue
        {
            get
            {
                if (Type != TerrainMaterialPropertyType.Float)
                    throw new InvalidOperationException($"Property '{Name}' is not a float type.");
                return _floatValue;
            }
            set
            {
                if (Type != TerrainMaterialPropertyType.Float)
                    throw new InvalidOperationException($"Property '{Name}' is not a float type.");
                _floatValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the color value. Only valid when <see cref="Type"/> is <see cref="TerrainMaterialPropertyType.Color"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the property is not a color type.</exception>
        public Color ColorValue
        {
            get
            {
                if (Type != TerrainMaterialPropertyType.Color)
                    throw new InvalidOperationException($"Property '{Name}' is not a color type.");
                return _colorValue;
            }
            set
            {
                if (Type != TerrainMaterialPropertyType.Color)
                    throw new InvalidOperationException($"Property '{Name}' is not a color type.");
                _colorValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the texture path. Only valid when <see cref="Type"/> is <see cref="TerrainMaterialPropertyType.Texture"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the property is not a texture type.</exception>
        public string TexturePath
        {
            get
            {
                if (Type != TerrainMaterialPropertyType.Texture)
                    throw new InvalidOperationException($"Property '{Name}' is not a texture type.");
                return _texturePath;
            }
            set
            {
                if (Type != TerrainMaterialPropertyType.Texture)
                    throw new InvalidOperationException($"Property '{Name}' is not a texture type.");
                _texturePath = value ?? string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the vector value. Only valid when <see cref="Type"/> is <see cref="TerrainMaterialPropertyType.Vector"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the property is not a vector type.</exception>
        public Vector3 VectorValue
        {
            get
            {
                if (Type != TerrainMaterialPropertyType.Vector)
                    throw new InvalidOperationException($"Property '{Name}' is not a vector type.");
                return _vectorValue;
            }
            set
            {
                if (Type != TerrainMaterialPropertyType.Vector)
                    throw new InvalidOperationException($"Property '{Name}' is not a vector type.");
                _vectorValue = value;
            }
        }
    }
}
