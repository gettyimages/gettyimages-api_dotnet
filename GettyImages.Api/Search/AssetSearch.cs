using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api.Search
{
    public abstract class AssetSearch : ApiRequest
    {
        protected readonly List<string> Fields = new List<string>();
        protected string AssetFamily;

        protected AssetSearch(DelegatingHandler customHandler) : base(customHandler)
        {
            
        }
        protected void AddResponseField(string value)
        {
            AppendMultiValuedQueryParameter(Constants.FieldsKey,value);
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
            AppendMultiValuedQueryParameter(Constants.CollectionCodeKey,value);
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
            AppendMultiValuedQueryParameter(Constants.SpecificPeopleKey,value);
        }

        protected void AppendMultiValuedQueryParameter(string key, string value)
        {
            if (!QueryParameters.ContainsKey(key))
            {
                QueryParameters.Add(key,new List<string> { value });
            }
            else
            {
                var values = ((List<string>) QueryParameters[key]);
                if (!values.Contains(value))
                {
                    values.Add(value);
                }
            }
        }

        protected void AddPhrase(string value)
        {
            AddQueryParameter(Constants.PhraseKey, value);
        }

        protected void AddAcceptLanguage(string value)
        {
            AddHeaderParameter(Constants.AcceptLanguage, value);
        }
    }
}
