// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.AspNetCore.Mvc.ApplicationModels;

using Wangkanai.Detection.Models;
using Wangkanai.System.Extensions;

namespace Wangkanai.Responsive.Hosting;

internal sealed class ResponsivePageRouteModelConvention : IPageRouteModelConvention
{
    public void Apply(PageRouteModel model)
    {
        // Very interesting use of C# 8.0 array index from end operator
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/ranges
        var fileNameWithoutExtension = model.ViewEnginePath.Split('/')[^1];
        // Normal page, nothing to do!
        if (!fileNameWithoutExtension.Contains('.'))
            return;

        // This just implements the 'suffix' strategy
        var split = fileNameWithoutExtension.Split('.');
        if (split.Length != 2)
            throw new InvalidOperationException($"Wangkanai.Responsive.WebmasterPage '{model.RelativePath}' does not follow the required format.");

        var areaName   = model.AreaName;
        var pageName   = split[0];
        var deviceName = split[1];

        if (!Enum.TryParse<Device>(deviceName, true, out var device))
            throw new InvalidOperationException($"Device name could not be parsed for page '{model.RelativePath}'.");

        // Since the page name has something like `.mobile` in it, the special cased rules for Index.cshtml
        // don't apply. We know there's going to be one selector.
        var selector = model.Selectors.Single();

        // If the pages in an area, then add it to the route template too.
        var area = areaName.IsNullOrEmpty() ? "" : areaName + "/";

        // Remove the device name from the route template. This is complicated because the route template
        // can additional parameters defined in the page itself.
        //
        // Ex: we need to turn `About/Help.mobile/{id?}` into `About/Help/{id?}`

        // prefix = `About/`
        var prefix = model.ViewEnginePath.Substring(1, model.ViewEnginePath.LastIndexOf('/'));

        // We can get the route parameter that the user put in after `@page` by substringing.
        //
        // suffix = '/{id?}'
        var templateOld = selector.AttributeRouteModel.Template;
        var suffix      = templateOld.Substring(area.Length + prefix.Length + fileNameWithoutExtension.Length);

        if (pageName.Equals("Index", StringComparison.OrdinalIgnoreCase))
        {
            // Pages like About/Index.cshtml have special behavior. When the page is called Index, it will
            // have two selectors, one with `Index` as part of the template and one without.

            // Add another selector with matches the URL without `Index`
            var another = new SelectorModel(selector);
            model.Selectors.Add(another);
            another.AttributeRouteModel.Template = area + prefix.TrimEnd('/') + suffix;

            // Disable link generation for the original selector, to prefer the shorter URL.
            selector.AttributeRouteModel.SuppressLinkGeneration = true;

            // Allow routing to filter by device type.
            another.EndpointMetadata.Add(new ResponsiveAttribute(device));
        }

        var templateNew = area + prefix + pageName + suffix;
        // Now rewrite the original selector
        selector.AttributeRouteModel.Template = templateNew;

        // Allow routing to filter by device type.
        selector.EndpointMetadata.Add(new ResponsiveAttribute(device));
    }
}