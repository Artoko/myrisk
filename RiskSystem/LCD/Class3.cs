using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace Wjb.ReadOrWriteIniAndReg
{
    /// <summary>
    /// HardDiskVal 的摘要说明。
    /// 读取指定盘符的硬盘序列号
    /// 功能：读取指定盘符的硬盘序列号
    /// </summary>
    public class HardDiskVal
    {
        [DllImport("kernel32.dll")]
        private static extern int GetVolumeInformation(

             string lpRootPathName,

             string lpVolumeNameBuffer,

             int nVolumeNameSize,

             ref int lpVolumeSerialNumber,

             int lpMaximumComponentLength,

             int lpFileSystemFlags,

             string lpFileSystemNameBuffer,

             int nFileSystemNameSize

             );

        /// <summary>

        /// 获得盘符为drvID的硬盘序列号，缺省为C

        /// </summary>

        /// <param name="drvID"></param>

        /// <returns></returns>

        public string HDVal(string drvID)
        {

            const int MAX_FILENAME_LEN = 256;

            int retVal = 0;

            int a = 0;

            int b = 0;

            string str1 = null;

            string str2 = null;

            int i = GetVolumeInformation(

                 drvID + @":\",

                 str1,

                 MAX_FILENAME_LEN,

                 ref retVal,

                 a,

                 b,

                 str2,

                 MAX_FILENAME_LEN

                 );

            return retVal.ToString();

        }

        public string HDVal()
        {

            const int MAX_FILENAME_LEN = 256;

            int retVal = 0;

            int a = 0;

            int b = 0;

            string str1 = null;

            string str2 = null;

            int i = GetVolumeInformation(

                 "c:\\",

                 str1,

                 MAX_FILENAME_LEN,

                 ref retVal,

                 a,

                 b,

                 str2,

                 MAX_FILENAME_LEN

                 );

            return retVal.ToString();

        }

    }

}
