using Ace_of_Fade_Smart_Hairtstyle_Suggestion.Models;

namespace Ace_of_Fade_Smart_Hairtstyle_Suggestion.Interfaces
{
    public interface IBarberRepository
    {
        Task<Barber> CreateBarber(Barber barber);
        Task<List<Barber>> GetBarbers();
    }
}
