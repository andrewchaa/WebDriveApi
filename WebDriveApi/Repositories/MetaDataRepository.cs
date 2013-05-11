using WebDriveApi.Domain;
using WebDriveApi.Helpers;

namespace WebDriveApi.Repositories
{
    public class MetaDataRepository : IMetaDataRepository
    {
        public void Save(Document document)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(document);
                transaction.Commit();
            }
        }
    }
}