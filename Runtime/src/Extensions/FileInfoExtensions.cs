// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Microsoft.Extensions.FileProviders;

namespace Wangkanai.Extensions;

public static class FileInfoExtensions
{
    public static string ContentType(this IFileInfo fileInfo)
    {
        var name = fileInfo.Name;

        if (name.IsExtension("jpg"))
            return "image/jpeg";
        if (name.IsExtension("gif"))
            return "image/gif";
        if (name.IsExtension("png"))
            return "image/png";
        if (name.IsExtension("svg"))
            return "image/svg";

        return "application/octet-stream";
    }

    private static bool IsExtension(this string name, string extension)
    {
        return name.EndsWith(extension, StringComparison.OrdinalIgnoreCase);
    }
}