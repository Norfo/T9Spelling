using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using T9Spelling;

namespace T9SpellingTests
{
    [TestClass]
    public class ParserTests
    {
        #region Testing ConvertLine
        [TestMethod]
        public void ConvertLine_bbb_22space22space22NewLineReturned()
        {
            //arrange
            string input = "bbb";
            string expected = "22 22 22\r\n";

            //act
            LinqDecoder p = new LinqDecoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLine_monoNewLine_6space666space66spase666NewLineReturned()
        {
            //arrange
            string input = "mono\r\n";
            string expected = "6 666 66 666\r\n";

            //act
            LinqDecoder p = new LinqDecoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLine_aSpacaSpaceaSpaceaSpaceNewLine_202020NewLineReturned()
        {
            //arrange
            string input = "a a a \r\n";
            string expected = "202020\r\n";

            //act
            LinqDecoder p = new LinqDecoder();
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
            LinqDecoder p = new LinqDecoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertLine_3spaces_0space0space0NewLineReturned()
        {
            //arrange
            string input = "   ";
            string expected = "0 0 0\r\n";

            //act
            LinqDecoder p = new LinqDecoder();
            string actual = p.ConvertLine(input);

            //assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Testing Convert
        [TestMethod]
        public void Convert_smallText_numberCodeReturned()
        {
            //arrange
            string input = "100\r\nyes\r\nno\r\nfoo bar\r\nhello world\r\nhddq\r\nkkyhoyre\r\nuzfcnb\r\nacxrbgddvtcw\r\nhclntbql uu\r\nwdcugsavyc\r\ntlw\r\npmtrkiiay";
            string expected = "Case #1: 999337777\r\nCase #2: 66 666\r\nCase #3: 333666 666022 2777\r\nCase #4: 4433555 555666096667775553\r\nCase #5: 443 377\r\nCase #6: 55 559994466699977733\r\nCase #7: 8899993332226622\r\nCase #8: 2 222997772243 3888 82229\r\nCase #9: 442225556682277555088 88\r\nCase #10: 9322288477772888999222\r\nCase #11: 85559\r\nCase #12: 76877755444 4442999\r\n";

            //act
            LinqDecoder p = new LinqDecoder();
            string actual = p.Convert(input);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Convert_emptyString_emptyStringReturned()
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
        #endregion
    }
}
