﻿using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dymaptic.GeoBlazor.Core.Components;

/// <summary>
///     Actions are customizable behavior which can be executed in certain widgets such as Popups, a BasemapLayerList, or a
///     LayerList.
///     <a target="_blank" href="https://developers.arcgis.com/javascript/latest/api-reference/esri-support-actions-ActionBase.html">
///         ArcGIS
///         JS API
///     </a>
/// </summary>
[JsonConverter(typeof(ActionBaseConverter))]
public abstract class ActionBase : MapComponent
{
    /// <summary>
    ///     The title of the action.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>
    ///     This adds a CSS class to the ActionButton's node.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }

    /// <summary>
    ///     The name of the ID assigned to this action.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public new string? Id { get; set; }

    /// <summary>
    ///     Set this property to true to display a spinner icon. You should do this if the action executes an async operation,
    ///     such as a query, that requires letting the end user know that a process is ongoing in the background. Set the
    ///     property back to false to communicate to the user that the process has finished.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Active { get; set; }

    /// <summary>
    ///     Indicates whether this action is disabled.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Disabled { get; set; }

    /// <summary>
    ///     Indicates if the action is visible.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Visible { get; set; }

    /// <summary>
    ///     The action function to perform on click.
    /// </summary>
    [Parameter]
    [EditorRequired]
    [JsonIgnore]
    [RequiredProperty]
    public Func<Task>? CallbackFunction { get; set; }

    /// <summary>
    ///     Specifies the type of action. Choose between "button" or "toggle".
    /// </summary>
    public virtual string Type { get; } = default!;
}

/// <summary>
///     A customizable button that performs a specific action(s) used in widgets such as the Popup, LayerList, and
///     BasemapLayerList.
/// </summary>
public class ActionButton : ActionBase
{
    /// <inheritdoc />
    public override string Type => "button";

    /// <summary>
    ///     The URL to an image that will be used to represent the action. This property will be used as a background image for
    ///     the node. It may be used in conjunction with the className property or by itself. If neither image nor className
    ///     are specified, a default icon will display
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Image { get; set; }
}

/// <summary>
///     A customizable toggle used in the LayerList widget that performs a specific action(s) which can be toggled on/off.
/// </summary>
public class ActionToggle : ActionBase
{
    /// <inheritdoc />
    public override string Type => "toggle";

    /// <summary>
    ///     Indicates the value of whether the action is toggled on/off.
    /// </summary>
    [Parameter]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Value { get; set; }
}

internal class ActionBaseConverter : JsonConverter<ActionBase>
{
    public override ActionBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var newOptions = new JsonSerializerOptions(options)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        Utf8JsonReader cloneReader = reader;

        if (JsonSerializer.Deserialize<Dictionary<string, object?>>(ref reader, newOptions) is not
            IDictionary<string, object?> temp)
        {
            return null;
        }

        if (temp.ContainsKey("type"))
        {
            switch (temp["type"]?.ToString())
            {
                case "button":
                    return JsonSerializer.Deserialize<ActionButton>(ref cloneReader, newOptions);
                case "toggle":
                    return JsonSerializer.Deserialize<ActionToggle>(ref cloneReader, newOptions);
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer, ActionBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, typeof(object), options);
    }
}