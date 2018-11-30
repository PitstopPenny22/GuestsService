using System.Linq;
using GuestsShared.Models;

namespace GuestsService.ServiceUtils
{
    public static class Extensions
    {
        public static HouseholdModel ToModel(this Household householdDataModel)
        {
            return new HouseholdModel
            {
                Id = householdDataModel.Id,
                EmailAddress = householdDataModel.EmailAddress,
                GuestsInHousehold = householdDataModel.Guest.Select(guest => guest.ToModel()).ToList() 
            };
        }

        public static GuestModel ToModel(this Guest guestDataModel)
        {
            return new GuestModel
            {
                DietaryRequirements = guestDataModel.DietaryRequirements,
                FirstName = guestDataModel.FirstName,
                HotelRequirement = (GuestsShared.Enums.HotelRequirement)guestDataModel.HotelRequirementId,
                HouseholdId = guestDataModel.HouseholdId,
                Id = guestDataModel.Id,
                IsChild = guestDataModel.IsChild,
                LastName = guestDataModel.LastName,
                NeedsTransport = guestDataModel.RequiresTransport,
                RsvpStatusId = guestDataModel.RsvpStatusId,
                SeatNumber = guestDataModel.SeatNumber,
                SongRequest = guestDataModel.SongRequest,
            };
        }

        public static Guest ToDataModel(this GuestModel guestModel)
        {
            return new Guest
            {
                DietaryRequirements = guestModel.DietaryRequirements,
                FirstName = guestModel.FirstName,
                HotelRequirementId = (int)guestModel.HotelRequirement,
                HouseholdId = guestModel.HouseholdId,
                Id = guestModel.Id,
                IsChild = guestModel.IsChild,
                LastName = guestModel.LastName,
                RequiresTransport = guestModel.NeedsTransport,
                RsvpStatusId = guestModel.RsvpStatusId,
                SeatNumber = guestModel.SeatNumber,
                SongRequest = guestModel.SongRequest
            };
        }
    }
}