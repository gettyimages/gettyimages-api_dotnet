using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public abstract class AssetSearch : ApiRequest
    {
        protected readonly List<string> Fields = new List<string>();
        protected string AssetFamily;

        protected void AddResponseField(string value)
        {
            if (!QueryParameters.ContainsKey(Constants.FieldsKey))
            {
                QueryParameters.Add(Constants.FieldsKey, new List<string> {value});
            }
            else
            {
                var fields = (IList<string>) QueryParameters[Constants.FieldsKey];
                if (!fields.Contains(value))
                {
                    fields.Add(value);
                }
            }
        }

        protected void AddResponseFieldRange(IList<string> value)
        {
            if (!QueryParameters.ContainsKey(Constants.FieldsKey))
            {
                QueryParameters.Add(Constants.FieldsKey, value);
            }
            else
            {
                var fields = QueryParameters[Constants.FieldsKey] as IEnumerable<string>;
                fields = fields.Union(value).Distinct();
                QueryParameters[Constants.FieldsKey] = fields.ToList();
            }
        }

        protected void AddAgeOfPeopleFilter(AgeOfPeople value)
        {
            if (QueryParameters.ContainsKey(Constants.AgeOfPeopleKey))
            {
                QueryParameters[Constants.AgeOfPeopleKey] = value == AgeOfPeople.None
                    ? value
                    : (AgeOfPeople) QueryParameters[Constants.AgeOfPeopleKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.AgeOfPeopleKey, value);
            }
        }

        protected void AddCollectionCode(string value)
        {
            if (!QueryParameters.ContainsKey(Constants.CollectionCodeKey))
            {
                QueryParameters.Add(Constants.CollectionCodeKey, new List<string> {value});
            }
            else
            {
                var collectionCodes = (IList<string>) QueryParameters[Constants.CollectionCodeKey];
                if (!collectionCodes.Contains(value))
                {
                    collectionCodes.Add(value);
                }
            }
        }

        protected void AddCollectionFilterType(CollectionFilter value)
        {
            AddQueryParameter(Constants.CollectionFilterKey, value);
        }

        protected void AddExcludeNudity(bool value)
        {
            AddQueryParameter(Constants.Excludenudity, value);
        }

        protected void AddLicenseModel(LicenseModel value)
        {
            if (QueryParameters.ContainsKey(Constants.LicenseModelsKey))
            {
                QueryParameters[Constants.LicenseModelsKey] = value == LicenseModel.None
                    ? value
                    : (LicenseModel) QueryParameters[Constants.LicenseModelsKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.LicenseModelsKey, value);
            }
        }

        protected void AddPage(int value)
        {
            AddQueryParameter(Constants.PageKey, value);
        }

        protected void AddPageSize(int value)
        {
            AddQueryParameter(Constants.PageSizeKey, value);
        }

        protected void AddProductType(ProductType value)
        {
            if (QueryParameters.ContainsKey(Constants.ProductTypesKey))
            {
                QueryParameters[Constants.ProductTypesKey] = value == ProductType.None
                    ? value
                    : (ProductType) QueryParameters[Constants.ProductTypesKey] | value;
            }
            else
            {
                QueryParameters.Add(Constants.ProductTypesKey, value);
            }
        }

        protected void AddSortOrder(string value)
        {
            AddQueryParameter(Constants.SortOrderKey, value);
        }

        protected void AddSpecificPeople(string value)
        {
            if (!QueryParameters.ContainsKey(Constants.SpecificPeopleKey))
            {
                QueryParameters.Add(Constants.SpecificPeopleKey, new List<string> {value});
            }
            else
            {
                var people = (IList<string>) QueryParameters[Constants.SpecificPeopleKey];
                if (!people.Contains(value))
                {
                    people.Add(value);
                }
            }
        }

        protected void AddPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
        }
    }
}
