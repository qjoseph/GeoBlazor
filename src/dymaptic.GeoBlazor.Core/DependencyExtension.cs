﻿using dymaptic.GeoBlazor.Core.Model;
using dymaptic.GeoBlazor.Core.Objects;
using Microsoft.Extensions.DependencyInjection;


namespace dymaptic.GeoBlazor.Core;

/// <summary>
///     Static extension class for injecting GeoBlazor types
/// </summary>
public static class DependencyExtension
{
    /// <summary>
    ///     Adds the Logic components <see cref="GeometryEngine" /> and <see cref="Projection" /> to your dependency
    ///     injection collection.
    /// </summary>
    public static IServiceCollection AddGeoBlazor(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<GeometryEngine>()
            .AddScoped<Projection>()
            .AddScoped<AbortManager>();
    }
}