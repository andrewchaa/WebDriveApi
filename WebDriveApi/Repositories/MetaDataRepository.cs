using NHibernate.Criterion;
using WebDriveApi.Domain;
using WebDriveApi.Helpers;

namespace WebDriveApi.Repositories
{
    public class MetaDataRepository : IMetaDataRepository
    {
        public Document Get(string fullName)
        {
            using (var session = NHibernateHelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria<Document>()
                              .Add(Restrictions.Eq("FullName", fullName))
                              .UniqueResult<Document>();
            }
        }

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