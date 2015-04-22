using System.Collections.Generic;
using System.Threading.Tasks;
using GettyImages.Connect.Search.Entity;

namespace GettyImages.Connect.Search
{
    public interface IImagesSearch
    {
        Task<dynamic> ExecuteAsync();
        SearchImages WithPage(int val);
        SearchImages WithPageSize(int val);
        SearchImages WithPhrase(string val);
        SearchImages WithSortOrder(string val);
        SearchImages WithEmbedContentOnly(bool value = true);
        SearchImages WithExcludeNudity(bool value = true);
        SearchImages WithResponseField(string value);
        SearchImages WithResponseFields(IList<string> value);
        SearchImages WithGraphicalStyle(GraphicalStyles value);
        SearchImages WithOrientation(Orientation value);
        SearchImages WithEventId(int value);
        SearchImages WithFileType(FileType value);
        SearchImages WithKeywordId(int value);
        SearchImages WithNumberOfPeople(NumberOfPeople value);
        SearchImages WithPrestigeContentOnly(bool value = true);
        SearchImages WithProductType(ProductType value);
        SearchImages WithLocation(string value);
        SearchImages WithAgeOfPeople(AgeOfPeople value);
        SearchImages WithComposition(Composition value);
        SearchImages WithArtist(string value);
        SearchImages WithEthnicity(Ethnicity value);
        SearchImages WithCollectionCode(string value);
        SearchImages WithDateTo(string value);
        SearchImages WithDateFrom(string value);
        SearchImages WithCollectionFilterType(CollectionFilter value);
        SearchImages WithSpecificPeople(string value);
    }
}