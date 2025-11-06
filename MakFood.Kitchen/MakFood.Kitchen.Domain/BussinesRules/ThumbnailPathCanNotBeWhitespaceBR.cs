using MakFood.Kitchen.Domain.BussinesRules.Exceptions;
using MakFood.Kitchen.Domain.SharedKarnel;

namespace MakFood.Kitchen.Domain.BussinesRules
{
    public class ThumbnailPathCanNotBeWhitespaceBR : IBaseBusinessRule
    {
        private readonly string _thumbnailPath;

        public ThumbnailPathCanNotBeWhitespaceBR(string thumbnailPath)
        {
            _thumbnailPath = thumbnailPath;
        }

        public bool Check()
        {
            if(string.IsNullOrWhiteSpace(_thumbnailPath)) return false;
            return true;
        }

        public Exception Throws()
        {
            throw new ThumbnailPathCanNotBeWhitespaceException();
        }
    }
}
