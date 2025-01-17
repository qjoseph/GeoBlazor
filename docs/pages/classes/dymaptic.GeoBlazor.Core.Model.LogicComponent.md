---
layout: default
title: LogicComponent
parent: Classes
---
#### [dymaptic.GeoBlazor.Core](index.html 'index')
### [dymaptic.GeoBlazor.Core.Model](index.html#dymaptic.GeoBlazor.Core.Model 'dymaptic.GeoBlazor.Core.Model')

## LogicComponent Class

A base class for non-map components, such as GeometryEngine, Projection, etc.

```csharp
public abstract class LogicComponent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LogicComponent

Derived  
&#8627; [GeometryEngine](dymaptic.GeoBlazor.Core.Model.GeometryEngine.html 'dymaptic.GeoBlazor.Core.Model.GeometryEngine')  
&#8627; [Projection](dymaptic.GeoBlazor.Core.Model.Projection.html 'dymaptic.GeoBlazor.Core.Model.Projection')
### Constructors

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration)'></a>

## LogicComponent(IJSRuntime, IConfiguration) Constructor

Default constructor

```csharp
public LogicComponent(Microsoft.JSInterop.IJSRuntime jsRuntime, Microsoft.Extensions.Configuration.IConfiguration configuration);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).jsRuntime'></a>

`jsRuntime` [Microsoft.JSInterop.IJSRuntime](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.JSInterop.IJSRuntime 'Microsoft.JSInterop.IJSRuntime')

Injected JavaScript Runtime reference

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.LogicComponent(Microsoft.JSInterop.IJSRuntime,Microsoft.Extensions.Configuration.IConfiguration).configuration'></a>

`configuration` [Microsoft.Extensions.Configuration.IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Configuration.IConfiguration 'Microsoft.Extensions.Configuration.IConfiguration')

Injected configuration object
### Properties

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptErrorHandler'></a>

## LogicComponent.OnJavascriptErrorHandler Property

Implement this handler in your calling code to catch and handle Javascript errors.

```csharp
public System.Func<dymaptic.GeoBlazor.Core.Exceptions.JavascriptException,System.Threading.Tasks.Task>? OnJavascriptErrorHandler { get; set; }
```

#### Property Value
[System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')
### Methods

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError)'></a>

## LogicComponent.OnJavascriptError(JavascriptError) Method

A JavaScript invokable method that returns a JS Error and converts it to an Exception.

```csharp
public void OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError error);
```
#### Parameters

<a name='dymaptic.GeoBlazor.Core.Model.LogicComponent.OnJavascriptError(dymaptic.GeoBlazor.Core.Exceptions.JavascriptError).error'></a>

`error` [JavascriptError](dymaptic.GeoBlazor.Core.Exceptions.JavascriptError.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptError')

The original JavaScript error.

#### Exceptions

[JavascriptException](dymaptic.GeoBlazor.Core.Exceptions.JavascriptException.html 'dymaptic.GeoBlazor.Core.Exceptions.JavascriptException')  
The converted error to exception.
