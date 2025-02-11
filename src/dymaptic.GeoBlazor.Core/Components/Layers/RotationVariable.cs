﻿using dymaptic.GeoBlazor.Core.Serialization;
using Microsoft.AspNetCore.Components;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components.Layers;

/// <summary>
///     The rotation visual variable defines how features rendered with marker symbols or text symbols in a MapView are
///     rotated. The rotation value is determined by mapping the values to data in a field, or by other arithmetic means
///     with an Arcade expression.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-renderers-visualVariables-RotationVariable.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
public class RotationVariable : VisualVariable
{
    /// <inheritdoc />
    [JsonPropertyName("type")]
    public override VisualVariableType VariableType => VisualVariableType.Rotation;

    /// <summary>
    ///     Only applicable when working in a SceneView.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Axis { get; set; }

    /// <summary>
    ///     Defines the origin and direction of rotation depending on how the angle of rotation was measured.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public RotationType? RotationType { get; set; }
}

/// <summary>
///     Options for rotation type for <see cref="RotationVariable" />
/// </summary>
[JsonConverter(typeof(EnumToKebabCaseStringConverter<RotationType>))]
public enum RotationType
{
#pragma warning disable CS1591
    Geographic,
    Arithmetic
#pragma warning restore CS1591
}