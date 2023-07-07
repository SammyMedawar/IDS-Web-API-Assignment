using ClassLibrary1.Interfaces;
using Sammy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Services
{
    public class ReservationService: IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Reservation> CreateReservation(Reservation newReservation)
        {
            await _unitOfWork.reservations.AddAsync(newReservation);
            await _unitOfWork.CommitAsync();
            return newReservation;
        }

        public async Task DeleteReservation(Reservation newReservation)
        {
            _unitOfWork.reservations.Remove(newReservation);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllWithReservations()
        {
            return await _unitOfWork.reservations
                .GetAllWithReservationsAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _unitOfWork.reservations
                .GetReservationByIdAsync(id);
        }

        public async Task updateReservation(Reservation oldReservation, Reservation newReservation)
        {
            oldReservation.ReservationDate = newReservation.ReservationDate;
            oldReservation.StartTime = newReservation.StartTime;
            oldReservation.Endtime = newReservation.Endtime;
            oldReservation.RoomId = newReservation.RoomId;
            oldReservation.UserId = newReservation.UserId;
            oldReservation.NumberAttendees = newReservation.NumberAttendees;
            oldReservation.MeetingStatus = newReservation.MeetingStatus;
            oldReservation.User = newReservation.User;

            await _unitOfWork.CommitAsync();
        }
    }
}
