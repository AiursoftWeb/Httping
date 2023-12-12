using Aiursoft.CommandFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aiursoft.Httping.Tests;

[TestClass]
public class IntegrationTests
{
    private readonly SingleCommandApp<PingHandler> _program = new SingleCommandApp<PingHandler>()
        .WithDefaultOption(OptionsProvider.ServerOption);

    [TestMethod]
    public async Task InvokeHelp()
    {
        var result = await _program.TestRunAsync(new[] { "--help" }, defaultOption: OptionsProvider.ServerOption);
        Assert.AreEqual(0, result.ProgramReturn);
    }

    [TestMethod]
    public async Task InvokeVersion()
    {
        var result = await _program.TestRunAsync(new[] { "--version" }, defaultOption: OptionsProvider.ServerOption);
        Assert.AreEqual(0, result.ProgramReturn);
    }

    [TestMethod]
    public async Task InvokeUnknown()
    {
        var result = await _program.TestRunAsync(new[] { "--wtf" }, defaultOption: OptionsProvider.ServerOption);
        Assert.AreEqual(1, result.ProgramReturn);
    }

    [TestMethod]
    public async Task InvokeWithoutArg()
    {
        var result = await _program.TestRunAsync(Array.Empty<string>(), defaultOption: OptionsProvider.ServerOption);
        Assert.AreEqual(1, result.ProgramReturn);
    }
    
    [TestMethod]
    public async Task InvokePing()
    {
        // Run
        var result = await _program.TestRunAsync(new[]
        {
            "www.bing.com",
            "-n",
            "1"
        }, defaultOption: OptionsProvider.ServerOption);

        // Assert
        Assert.AreEqual(0, result.ProgramReturn);
    }
    
    [TestMethod]
    public async Task InvokePingFailed()
    {
        // Run
        var result = await _program.TestRunAsync(new[]
        {
            "wrong-value",
            "-n",
            "1",
        }, defaultOption: OptionsProvider.ServerOption);

        // Assert
        Assert.AreEqual(0, result.ProgramReturn);
    }
}
