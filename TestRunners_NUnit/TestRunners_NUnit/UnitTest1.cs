namespace TestRunners_NUnit
{
    [TestFixture]
    public class Tests
    {
        [OneTimeSetUp]
        public static void ClassPrecondition()
        {
            TestContext.WriteLine("Nunit Class Precondition output");
        }

        [SetUp]
        public void TestPrecondition()
        {
            TestContext.WriteLine("Nunit Test Precondition output");
        }


        [Test]
        public void Test_Pass()
        {
            string expected = "leshani";
            string actual = "leshani";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_Pass2()
        {
            void FunctionUnderTest()
            {
                throw new Exception();
            }

            Action _functionUnderTest = FunctionUnderTest;
            Assert.Throws<Exception>(() => _functionUnderTest());

        }

        [TestCase(4, 8, 12)]
        [TestCase(5, 10, 15)]
        [TestCase(100, 200, 300)]
        public void Test_Add(double x, double y, double e)
        {
            double expected = e;
            double actual = x + y;
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        [Ignore("Checking the ignore attribute")]
        public void Test_Ignore()
        {
            TestContext.WriteLine("Ignoring test");
        }

        [Test]
        public void Test_Fail()
        {
            Assert.Fail();
        }

        [Test]
        public void Test_Fail2()
        {
            string expected = "leshani";
            string actual = "leshani123";
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TearDown]
        public void NUnitTearDown()
        {
            TestContext.WriteLine("Nunit Test Postcondition output");
        }

        [OneTimeTearDown]
        public void NUnitOneTimeTearDown()
        {
            TestContext.WriteLine("Nunit Class Postcondition output");
        }

    }
}