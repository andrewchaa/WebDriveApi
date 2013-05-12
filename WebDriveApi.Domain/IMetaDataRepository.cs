using System;

namespace WebDriveApi.Domain
{
    public interface IMetaDataRepository
    {
        Document Get(string fullName);
        void Save(Document document);
    }
}