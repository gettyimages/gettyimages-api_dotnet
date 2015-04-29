using System;

namespace GettyImages.Api
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DescriptionAttribute : Attribute
    {
        private readonly string _description;

        public DescriptionAttribute(string description)
        {
            _description = description;
        }

        public string Description
        {
            get { return _description; }
        }
    }
}