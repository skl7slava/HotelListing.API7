namespace HotelListing.Api.Core.Exceptions
{
    public class NotFoundException:ApplicationException
    {
        public NotFoundException(string Name, object key) : base($"{Name} {key} was not found)") 
        {
                
        }
    }
}
