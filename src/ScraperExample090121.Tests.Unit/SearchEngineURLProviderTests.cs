using NUnit.Framework;
using ScraperExample090121.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScraperExample090121.Tests.Unit
{
    [TestFixture]
    public class SearchEngineURLProviderTests
    {
        private SearchEngineURLProvider _searchEngineURLProvider;

        [SetUp]
        public void Setup()
        {
            _searchEngineURLProvider = new SearchEngineURLProvider();
        }


        [TestCase("test", "google", "https://www.google.co.uk/search?num=100&q=test")]
        [TestCase("test", "bing", "https://www.bing.com/search?count=100&q=test")]
        [TestCase("test", "yahoo", "https://uk.search.yahoo.com/search?p=test&n=100")]
        [TestCase("test", null, "https://www.google.co.uk/search?num=100&q=test")]
        public void Provide_Should_Provide_The_Correct_URL(string terms, string searchEnginePreference, string expectedResult)
        {
            //Act
            var url = _searchEngineURLProvider.Provide(terms, searchEnginePreference);

            //Assert
            Assert.AreEqual(url, expectedResult);
        }
    }
}
