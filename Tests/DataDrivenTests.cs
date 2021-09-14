using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UtilHelper.Tests
{
    [TestFixture("arg1", "arg2")]
    [Parallelizable(ParallelScope.Fixtures)] // parallel tests runs
    public class DataDrivenTests
    {
        public DataDrivenTests(string arg1, string arg2)
        {

        }
        [Test]
        [Category("BasicTes"), Category("RunAllTest")]
        [TestCaseSource(typeof(DataDrivenTestsData),"HardCodedDataMethod")]
        public void Test1()
        {

        }
    }
    public static class DataDrivenTestsData
    {
        public static IEnumerable HardCodedDataMethod
        {
            get
            {
                yield return new TestCaseData("EUR");
                yield return new TestCaseData("USD");
                yield return new TestCaseData("GBP");


            }
        }
        public static IEnumerable getTest()
        {
            yield return new TestCaseData("data1");
        }
    }
}
