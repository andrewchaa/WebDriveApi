using System;

namespace WebDriveApi.Domain
{
    public interface IMetaDataRepository
    {
        void Save(Document document);
    }
}