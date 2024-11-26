using Corporativo.Util;
using Xunit;

namespace App.Test._6__Shared
{
    public class StringExtensionsTest
    {
        [Trait("Categoria", "ViewModel")]
        [Fact(DisplayName = "StringExtensionsTest  true")]

        public void listInt_retornar_DeveRetornar_ok()
        {
            var _test = UtilExtensions.ConvertStringInListInt("1,2");
            Assert.True(_test.Count == 2);

            _test = UtilExtensions.ConvertStringInListInt("");
            Assert.True(_test.Count == 0);


        }

        [Trait("Categoria", "ViewModel")]
        [Fact(DisplayName = "StringExtensionsTest  true")]

        public void ListString_retornar_DeveRetornar_ok()
        {
            var _test = UtilExtensions.ConvertStringInListString("1,2");
            Assert.True(_test.Count == 2);

            _test = UtilExtensions.ConvertStringInListString("");
            Assert.True(_test.Count == 0);


        }

        [Trait("Categoria", "ViewModel")]
        [Fact(DisplayName = "StringExtensionsTest  true")]

        public void ValidString_retornar_DeveRetornar_ok()
        {
            var _test = UtilExtensions.IsValidConvertStringInListInt("1,2");
            Assert.True(_test);

            _test = UtilExtensions.IsValidConvertStringInListInt("z");
            Assert.False(_test);


        }
    }
}
