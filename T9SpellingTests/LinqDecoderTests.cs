using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;

namespace T9SpellingTests
{
    [TestClass]
    public class LinqDecoderTests
    {
        [TestMethod]
        public void LinqConvert_emptyString_emptyStringReturned()
        {
            //arrange
            string input = "";
            string expected = "";

            //act
            LinqDecoder p = new LinqDecoder();
            string actual = p.Convert(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
