// Copyright (c) 2014-2022 Sarin Na Wangkanai, All Rights Reserved.Apache License, Version 2.0

using Wangkanai.Detection.Extensions;
using Wangkanai.Detection.Models;
using Wangkanai.Extensions;

namespace Wangkanai.Detection.Services;

public sealed class BrowserService : IBrowserService
{
	private readonly IEngineService    _engineService;
	private readonly IUserAgentService _userAgentService;

	private Browser? _browser;
	private Version? _version;

	public BrowserService(IUserAgentService userAgentService,
		IEngineService                      engineService)
	{
		_userAgentService = userAgentService;
		_engineService    = engineService;
	}

	public Browser Name    => _browser ??= GetBrowser();
	public Version Version => _version ??= GetVersion();

	private Browser GetBrowser()
	{
		var agent  = _userAgentService.UserAgent.ToLower();
		var engine = _engineService.Name;

		if (string.IsNullOrEmpty(agent))
			return Browser.Unknown;
		if (IsEdge(agent))
			return Browser.Edge;
		if (agent.Contains(Browser.Chrome))
			return Browser.Chrome;
		if (IsInternetExplorer(agent, engine))
			return Browser.InternetExplorer;
		if (agent.Contains(Browser.Safari))
			return Browser.Safari;
		if (agent.Contains(Browser.Firefox))
			return Browser.Firefox;
		if (agent.Contains(Browser.Opera))
			return Browser.Opera;

		return Browser.Others;
	}

	private Version GetVersion()
	{
		var agent   = _userAgentService.UserAgent.ToLower();
		var browser = Name;

		if (string.IsNullOrEmpty(agent))
			return new Version();

		if (agent.Contains("rv:11.0", StringComparison.Ordinal) ||
		    agent.Contains("ie 11.0", StringComparison.Ordinal))
			return new Version(11, 0);
		if (agent.Contains("msie 10", StringComparison.Ordinal))
			return new Version(10, 0);
		if (agent.Contains("msie 9", StringComparison.Ordinal))
			return new Version(9, 0);

		if (browser == Browser.Edge && !agent.Contains("edge", StringComparison.Ordinal))
			return GetVersionCommon(agent.Replace("edg", "edge", StringComparison.Ordinal), browser);

		if (browser == Browser.Safari && agent.Contains("version/", StringComparison.Ordinal))
			return GetVersionSafari(agent);

		return GetVersionCommon(agent, browser);
	}

	private static Version GetVersionCommon(string agent, Browser browser)
	{
		var name  = browser.ToStringInvariant();
		var first = agent.IndexOf(name, StringComparison.Ordinal);

		if (first < 0 || first + name.Length > agent.Length)
			return new Version();

		var cut = agent.Length > first + name.Length + 1 ? agent.Substring(first + name.Length + 1) : agent.Substring(first + name.Length);

		var indexOfSpace = cut.IndexOf(' ', StringComparison.Ordinal);
		var version      = indexOfSpace != -1 ? cut.Substring(0, indexOfSpace) : cut;
		return version.ToVersion();
	}

	private static Version GetVersionSafari(string agent)
	{
		var version      = agent.Substring(agent.IndexOf("version/", StringComparison.Ordinal) + "version/".Length);
		var indexOfSpace = version.IndexOf(" ", StringComparison.Ordinal);

		if (indexOfSpace != -1)
			version = version.Substring(0, indexOfSpace);

		return version.ToVersion();
	}

	private static bool IsEdge(string agent)
	{
		return agent.Contains(Browser.Edge)
		       || agent.Contains("win64", StringComparison.Ordinal) &&
		       agent.Contains("edg", StringComparison.Ordinal);
	}

	private static bool IsInternetExplorer(string agent, Engine engine)
	{
		return engine == Engine.Trident
		       || agent.Contains("msie", StringComparison.Ordinal)
		       && !agent.Contains(Browser.Opera);
	}
}