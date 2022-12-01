namespace TestRunners_MSTest
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassPrecondition(TestContext testContext)
        {
            testContext.WriteLine("MS test Class Precondition output");
        }

        [TestInitialize]
        public void TestPrecondition()
        {
            TestContext.WriteLine("MS test Test Precondition output");
        }

        [TestMethod]
        public void Test_Pass()
        {
            string expected = "leshani";
            string actual = "leshani";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Pass2()
        {

            void FunctionUnderTest()
            {
                throw new Exception();
            }

            Action _functionUnderTest = FunctionUnderTest;
            Assert.ThrowsException<Exception>(() => _functionUnderTest());

        }

        [DataTestMethod]
        [DataRow(8, 4, 4)]
        [DataRow(10, 5, 5)]
        [DataRow(10, 10, 0)]
        public void Test_Sub(double x, double y, double e)
        {
            double expected = e;
            double actual = x - y;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        [Ignore("Checking the ignore attribute")]
        public void Test_Ignore()
        {
            TestContext.WriteLine("Ignoring Test");
        }

        [TestMethod]
        public void Test_Fail()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Test_Fail2()
        {
            string expected = "leshani";
            string actual = "leshani123";
            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void MSTestCleanup()
        {
            TestContext.WriteLine("MS test Test Postcondition output");
        }

        [ClassCleanup]
        public static void MSTestClassCleanup()
        {
            int i = 0;
        }

    }
}