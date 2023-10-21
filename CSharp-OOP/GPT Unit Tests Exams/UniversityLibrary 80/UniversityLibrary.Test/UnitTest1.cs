namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Linq;

    public class Tests
    {
        private UniversityLibrary universityLibrary;
        private TextBook testBook1;
        private TextBook testBook2;

        [SetUp]
        public void Setup()
        {
            this.universityLibrary = new UniversityLibrary();
            this.testBook1 = new TextBook("Test Book 1", "Test Author 1", "Test Category 1");
            this.testBook2 = new TextBook("Test Book 2", "Test Author 2", "Test Category 2");
        }

        [Test]
        public void Test_AddTextBookToLibrary_Should_AddTextBookCorrectly()
        {
            universityLibrary.AddTextBookToLibrary(testBook1);
            Assert.AreEqual(1, universityLibrary.Catalogue.Count);
            Assert.AreEqual("Test Book 1", universityLibrary.Catalogue.First().Title);
            Assert.AreEqual(1, universityLibrary.Catalogue.First().InventoryNumber);
        }

        [Test]
        public void Test_LoanTextBook_Should_AssignHolderToTextBook()
        {
            universityLibrary.AddTextBookToLibrary(testBook1);
            universityLibrary.LoanTextBook(1, "Test Student");
            Assert.AreEqual("Test Student", universityLibrary.Catalogue.First().Holder);
        }

        [Test]
        public void Test_LoanTextBook_Should_ReturnCorrectMessageWhenBookIsLoanedToSameStudent()
        {
            universityLibrary.AddTextBookToLibrary(testBook1);
            universityLibrary.LoanTextBook(1, "Test Student");
            string message = universityLibrary.LoanTextBook(1, "Test Student");
            Assert.AreEqual("Test Student still hasn't returned Test Book 1!", message);
        }

        [Test]
        public void Test_ReturnTextBook_Should_RemoveHolderFromTextBook()
        {
            universityLibrary.AddTextBookToLibrary(testBook1);
            universityLibrary.LoanTextBook(1, "Test Student");
            universityLibrary.ReturnTextBook(1);
            Assert.AreEqual(string.Empty, universityLibrary.Catalogue.First().Holder);
        }

        [Test]
        public void Test_ReturnTextBook_Should_ReturnCorrectMessageWhenBookIsReturned()
        {
            universityLibrary.AddTextBookToLibrary(testBook1);
            universityLibrary.LoanTextBook(1, "Test Student");
            string message = universityLibrary.ReturnTextBook(1);
            Assert.AreEqual("Test Book 1 is returned to the library.", message);
        }

    }
}
