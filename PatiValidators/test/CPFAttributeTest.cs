using Xunit;

namespace Pati.Validators.Test;

public class CPFAttributeTest
{
    [Fact]
    public void ValidCPFReturnTrueSuccess()
    {
        // Prepare
        var sut = new CPFAttribute();

        // Act
        var res = sut.IsValid("26478449092");

        // Verify
        Assert.True(res);
    }

    [Fact]
    public void InvalidCPFReturnFalseSuccess()
    {
        // Prepare
        var sut = new CPFAttribute();

        // Act
        var res = sut.IsValid("26478449093");

        // Verify
        Assert.False(res);
    }

    [Fact]
    public void InvalidSmallerSizeCPFReturnFalseSuccess()
    {
        // Prepare
        var sut = new CPFAttribute();

        // Act
        var res = sut.IsValid("268449092");

        // Verify
        Assert.False(res);
    }

    [Fact]
    public void InvalidAllRepeatedSizeCPFReturnFalseSuccess()
    {
        // Prepare
        var sut = new CPFAttribute();

        // Act
        var res = sut.IsValid("11111111111");

        // Verify
        Assert.False(res);
    }
}