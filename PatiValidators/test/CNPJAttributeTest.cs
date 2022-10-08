using Xunit;

namespace Pati.Validators.Test
{
    public class CNPJAttributeTest
    {
        [Fact]
        public void ValidCNPJReturnTrueSuccess()
        {
            // Prepare
            var sut = new CNPJAttribute();

            // Act
            var res = sut.IsValid("11222333000181");

            // Verify
            Assert.True(res);
        }

        [Theory]
        [InlineData("11222333000182")]
        [InlineData("11222333000171")]
        public void InvalidCNPJReturnFalseSuccess(string cnpj)
        {
            // Prepare
            var sut = new CNPJAttribute();

            // Act
            var res = sut.IsValid(cnpj);

            // Verify
            Assert.False(res);
        }

        [Fact]
        public void InvalidSmallerSizeCNPJReturnFalseSuccess()
        {
            // Prepare
            var sut = new CNPJAttribute();

            // Act
            var res = sut.IsValid("1122233300018");

            // Verify
            Assert.False(res);
        }

        [Fact]
        public void InvalidAllRepeatedSizeCNPJReturnFalseSuccess()
        {
            // Prepare
            var sut = new CNPJAttribute();

            // Act
            var res = sut.IsValid("11111111111111");

            // Verify
            Assert.False(res);
        }
    }
}
