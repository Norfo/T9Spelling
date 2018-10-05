using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;


namespace T9SpellingTests
{
    [TestClass]
    public class DecoderTests
    {
        #region Testing ConvertLine
        [TestMethod]
        public void ConvertLine_inputString_expectedLineReturned()
        {
            //arrange
            string input = "bbb b";
            string expected = "22 22 22022\r\n";

            //act
            Decoder p = new Decoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLine_outOfRangeLine_EmptyLineReturned()
        {
            //arrange
            string input = "~1234567890-=*-+_/?!@#%^&*().,<>абвгдABCD";
            string expected ="";

            //act
            Decoder p = new Decoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLine_empty_emptyReturned()
        {
            //arrange
            string input = "";
            string expected = "";

            //act
            Decoder p = new Decoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
