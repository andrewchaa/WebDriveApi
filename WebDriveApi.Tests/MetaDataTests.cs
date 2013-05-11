using System;
using Machine.Specifications;
using Moq;
using WebDriveApi.Controllers;
using WebDriveApi.Domain;
using It = Machine.Specifications.It;

namespace WebDriveApi.Tests
{

    public class MetaDataTests
    {
        public class When_I_send_meta_data
        {
            private static MetaDataController _metaDataController;
            private static Mock<IMetaDataRepository> _metaDataRepository;
            private static Document _document;
            private static string _name;
            private static string _fullName;
            private static DateTime _lastUpdate;

            Establish context = () =>
                {
                    _name = "name";
                    _fullName = "fullname";
                    _lastUpdate = DateTime.UtcNow;
                    _metaDataRepository = new Mock<IMetaDataRepository>();
                    _document = new Document { FullName = _fullName, Name = _name, LastUpdate = _lastUpdate };

                    _metaDataController = new MetaDataController(_metaDataRepository.Object);
                };

            Because of = () => _metaDataController.Post(_document);

            It should_save_title = () => _metaDataRepository.Verify(m => m.Save(_document));
        }
    }

}
