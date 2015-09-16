using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GettyImages.Api;
using GettyImages.Api.Search;
using GettyImages.Api.Search.Entity;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ImageSearchQueryParameters
    {
        [Test]
        public void EditorialSegments()
        {
            var searchImages = SearchImages.GetInstance(null, "");

            searchImages.Editorial().WithEditorialSegment(EditorialSegment.Archival);
            searchImages.Editorial().WithEditorialSegment(EditorialSegment.Publicity);

            Assert.Contains(Constants.EditorialSegmentKey, searchImages.QueryParameters.Keys.ToArray());
            Assert.IsTrue((((EditorialSegment)searchImages.QueryParameters[Constants.EditorialSegmentKey]) & EditorialSegment.Archival) == EditorialSegment.Archival);
            Assert.IsTrue((((EditorialSegment)searchImages.QueryParameters[Constants.EditorialSegmentKey]) & EditorialSegment.Publicity) == EditorialSegment.Publicity);
        }

    }
}
