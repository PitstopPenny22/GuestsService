using GuestsService.ServiceUtils;
using GuestsShared.Enums;
using GuestsShared.Interfaces;
using GuestsShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;

namespace GuestsService
{
    public class GuestsService : IGuestsService
    {
        private EntityConnection _entityConnection = DbConnectionUtils.GetEntityConnection();

        public List<HouseholdModel> GetAllHouseholds()
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                var householdDataModels = dbContext.Household.ToList();
                return householdDataModels.Select(dm => dm.ToModel()).ToList();
            }
        }

        public HouseholdModel GetHouseholdById(Guid householdId)
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                var householdDataModel = dbContext.Household.FirstOrDefault(dm => dm.Id == householdId);
                return householdDataModel?.ToModel();
            }
        }

        public List<GuestModel> GetAllGuests()
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                var guestsDataModels = dbContext.Guest.ToList();
                return guestsDataModels.Select(dm => dm.ToModel()).ToList();
            }
        }

        public GuestModel GetGuestById(Guid guestId)
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                var guestsDataModel = dbContext.Guest.FirstOrDefault(guest => guest.Id == guestId);
                return guestsDataModel.ToModel();
            }
        }

        public List<GuestModel> GetGuestsInHousehold(Guid householdId)
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                return dbContext.Guest.Where(guest => guest.HouseholdId == householdId).Select(dm => dm.ToModel()).ToList();
            }
        }

        public bool UpdateSeatByGuestId(Guid guestId, int seatNumber)
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                var guest = dbContext.Guest.FirstOrDefault(g => g.Id == guestId);
                if (guest == null)
                {
                    return false;
                }

                guest.SeatNumber = seatNumber;
                dbContext.SaveChanges();
                return true;
            }
        }

        public void AddNewGuest(GuestModel newGuestModel)
        {
            using (var dbContext = new GuestsDbContext(_entityConnection))
            {
                newGuestModel.Id = Guid.NewGuid();
                newGuestModel.RsvpStatusId = (int)RsvpOption.PendingInvitation;
                newGuestModel.HotelRequirement = GuestsShared.Enums.HotelRequirement.None;
                dbContext.Guest.Add(newGuestModel.ToDataModel());
                dbContext.SaveChanges();
            }
        }
    }
}
