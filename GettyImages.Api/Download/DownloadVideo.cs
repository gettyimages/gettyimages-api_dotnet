using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettyImages.Api.Search.Entity;

namespace GettyImages.Api
{
    public class DownloadVideo :AssetDownload
    {
        private DownloadVideo(Credentials credentials, string baseUrl) : base(credentials, baseUrl)
        {
            AssetType = "videos";
        }

        internal static DownloadVideo GetInstance(Credentials credentials, string baseUrl)
        {
            return new DownloadVideo(credentials, baseUrl);
        }

        protected override sealed string AssetType { get; set; }

        public DownloadVideo WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public DownloadVideo WithSize(string value)
        {
            AddQueryParameter("size", value);
            return this;
        }
    }

    public class DownloadImage : AssetDownload
    {
        private const string AutoDownloadKey = "auto_download";
        private const string FileTypeKey = "file_type";
        private const string HeightKey = "height";
        private DownloadImage(Credentials credentials, string baseUrl)
            : base(credentials, baseUrl)
        {
            AssetType = "images";
        }

        internal static DownloadImage GetInstance(Credentials credentials, string baseUrl)
        {
            return new DownloadImage(credentials, baseUrl);
        }

        protected override sealed string AssetType { get; set; }

        public DownloadImage WithId(string value)
        {
            AssetId = value;
            return this;
        }

        public DownloadImage WithFileType(FileType value)
        {
            if (QueryParameters.ContainsKey(FileTypeKey))
            {
                QueryParameters[FileTypeKey] = value == FileType.None
                    ? value
                    : (FileType)QueryParameters[FileTypeKey] | value;
            }
            else
            {
                QueryParameters.Add(FileTypeKey, value);
            }
            return this;
        }

        public DownloadImage WithAutoDownload(bool value = false)
        {
            QueryParameters.Add(AutoDownloadKey, false);
            return this;
        }

        public DownloadImage WithHeight(int height)
        {
            QueryParameters.Add(HeightKey, height);
            return this;
        }
    }
}
