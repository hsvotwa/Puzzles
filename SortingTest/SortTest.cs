using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;
using System.Collections.Generic;

namespace SortingTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void Test()
        {
            //Dictionary of <input, expectedResult>
            Dictionary<string, string> testCases = new Dictionary<string, string>();
            testCases.Add("baba", "aabb");
            testCases.Add("X yB!a", "abxy");
            testCases.Add("BAx  ", "abx");
            testCases.Add("I am Hope!", "aehimop");

            string testResult;

            foreach (string key in testCases.Keys)
            {
                testResult = Program.sortStrBuiltIn(key);
                Assert.AreEqual(testCases[key], testResult);
            }
        }
    }
}
