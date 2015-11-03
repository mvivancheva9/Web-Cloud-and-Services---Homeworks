namespace ArtistsSystem.Services.Controllers
{
    using System.Web.Http;
    using ArtistsSystem.Data;

    public class BaseController : ApiController
    {
        protected IArtistsSystemData data;

        public BaseController()
            :this(new ArtistsSystemData())
        {
        }

        public BaseController(IArtistsSystemData data)
        {
            this.data = data;
        }
    }
}
