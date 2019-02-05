using System;
using System.Collections.Generic;
using System.IO;
using nikolay_tashev_employess.Base.Common.Interfaces;
using nikolay_tashev_employess.Base.FileOperations.Interfaces;
using nikolay_tashev_employess.Base.Common.Exceptions;

namespace nikolay_tashev_employess.Base.FileOperations
{
    public class FileDataLoader<DataModel> : IDataLoader<DataModel>
    {
        string filePath = String.Empty;
        IFileParser<DataModel> fileParser;

        public FileDataLoader(string filePath, IFileParser<DataModel> fileParser)
        {
            if (filePath == null || filePath.Length <= 0)
                throw new BaseSystemException("Invalid Filepath");

            if (fileParser == null)
                throw new BaseSystemException("Invalid File Parser");

            this.filePath = filePath;
            this.fileParser = fileParser;
        }

        /// <summary> Parses the file into list of records </summary
        public List<DataModel> LoadData()
        {
            try
            {
                List<DataModel> dataArray = new List<DataModel>();

                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var bufferedStream = new BufferedStream(fileStream))
                using (var streamReader = new StreamReader(bufferedStream))
                {
                    int currentRow = 0;
                    string fileLine = String.Empty;
                    while ((fileLine = streamReader.ReadLine()) != null)
                    {
                        currentRow++;
                        dataArray.Add(fileParser.ParseData(fileLine, currentRow));
                    }
                }

                return dataArray;
            }
            catch (Exception exception)
            {
                throw new BaseSystemException("Error while reading file", exception);
            }
        }
    }
}
