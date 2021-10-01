using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darbas_su_ftp_serveriu
{
    class OneFtpItems
    {
        private string sizeInString;
        private long sizeInBytes;
        public string Name { get; set; }
        public long Size 
        { 
            get
            {
                return sizeInBytes;
            }
            set
            {
                sizeInBytes = value;
                sizeInString = ConvertBytesToSizeString(sizeInBytes);
            }
        }
        public DataType DataType { get; set; }
        public string LastModified { get; set; }
        public string SizeString 
        {
            get
            {
                return sizeInString;
            }
        }

        private string ConvertBytesToSizeString(long size)
        {
            if(size >= 0 && size < 1024)
            {
                return size + "B";
            }
            else if (size/1024 < 1024)
            {
                return Math.Round(size/1024f, 2) + "KB";
            }
            else if (size / 1024/ 1024f < 1024)
            {
                return Math.Round(size / 1024 / 1024f, 2) + "MB";
            }
            else if (size / 1024 / 1024 / 1024f < 1024)
            {
                return Math.Round(size / 1024 / 1024/ 1024f, 2) + "GB";
            }
            return "too big";
        }
    }
}
