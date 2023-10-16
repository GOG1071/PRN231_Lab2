namespace eBookStoreWebAPI.Controllers;

using BusinessObject;
using DataAccess.Repository;
using eBookStoreWebAPI.Controllers.Base;

public class PublishersController : BaseOdataController<Publisher, PublisherRepository>
{
    protected override PublisherRepository Repository => new();
}