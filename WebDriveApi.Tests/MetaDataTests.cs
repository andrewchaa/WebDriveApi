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
        public class Context
        {
            protected static MetaDataController _metaDataController;
            protected static Mock<IMetaDataRepository> _repository;
            protected static Document _document;
            protected static string _name;
            protected static string _fullName;
            protected static DateTime _lastUpdate;
            protected static Document _documentForVerification;

            Establish context = () =>
            {
                _name = "name";
                _fullName = "fullname";
                _lastUpdate = DateTime.UtcNow;
                _repository = new Mock<IMetaDataRepository>();
                _document = new Document { FullName = _fullName, Name = _name, LastUpdate = _lastUpdate };

                _metaDataController = new MetaDataController(_repository.Object);
            };
        }

        public class When_I_post_the_details_of_the_document : Context
        {
            Because of = () => _metaDataController.Post(_document);

            It should_save_the_meta_data = () => _repository.Verify(m => m.Save(_document));
        }

        public class When_I_post_the_details_of_the_document_second_time : Context
        {
            Establish context = () =>
                {
                    _documentForVerification = new Document
                        {
                            FullName = _document.FullName,
                            DownloadCount = _document.DownloadCount + 1,
                            LastUpdate = _document.LastUpdate,
                            Name = _document.Name
                        };
                };

            Because of = () =>
                {
                    _metaDataController.Post(_document);
                    _metaDataController.Post(_document);
                };

            It should_increase_the_download_count = () => _repository.Verify(m => m.Save(_documentForVerification)) ;
        }


    }

}
