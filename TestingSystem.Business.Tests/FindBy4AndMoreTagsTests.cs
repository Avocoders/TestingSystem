using NUnit.Framework;
using System.Collections.Generic;

namespace TestingSystem.Business.Tests
{
    public class FindBy4AndMoreTagsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CreateListFromStringTest(int num)
        {
            CreateListFromStringMock mock = new CreateListFromStringMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<string> actual =tags.CreateListFromString(mock.GetActual(num));
            CollectionAssert.AreEqual(mock.GetExpected(num), actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FindTagsIDTest(int num)
        {
            FindTagsIDMock mock = new FindTagsIDMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<int> actual = tags.FindTagsID(mock.GetTagDTOs(num), mock.GetTags(num));
            CollectionAssert.AreEqual(mock.GetExpected(num), actual);
        }
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void TestTagDTOToTestTagsModelTest(int num)
        {
            TagDTOToTestTagsModelMock mock = new TagDTOToTestTagsModelMock();
            FindBy4AndMoreTags tags = new FindBy4AndMoreTags();
            List<TestTagsModel> actual= tags.TestTagDTOToTestTagsModel(mock.GetActual(num));
            int i = -1;
            foreach (var a in mock.GetExpected(num))
            {
                i++;
                Assert.AreEqual(a.TestID, actual[i].TestID);
                CollectionAssert.AreEqual(a.TagsID, actual[i].TagsID);
            }
        }
    }
}