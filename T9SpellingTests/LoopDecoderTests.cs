using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;

namespace T9SpellingTests
{
    [TestClass]
    public class LoopDecoderTests
    {
        [TestMethod]
        public void LoopConvert_emptyString_emptyStringReturned()
        {
            //arrange
            string input = "";
            string expected = "";

            //act
            LoopDecoder p = new LoopDecoder();
            string actual = p.Convert(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
