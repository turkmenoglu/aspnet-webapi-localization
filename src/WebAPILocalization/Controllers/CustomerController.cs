using System.Web.Http;
using WebAPILocalization.Models;

namespace WebAPILocalization.Controllers
{
    public class CustomerController : ApiController
    {
        public Customer Get()
        {
            return new Customer()
            {
                Name = Resources.WebAPIResource.NameField,
                Email = Resources.WebAPIResource.EmailField
            };
        }
    }
}