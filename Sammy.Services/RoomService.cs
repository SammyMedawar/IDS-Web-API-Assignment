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
    public class RoomService: IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await _unitOfWork.rooms.AddAsync(newRoom);
            await _unitOfWork.CommitAsync();
            return newRoom;
        }

        public async Task DeleteRoom(Room newRoom)
        {
            _unitOfWork.rooms.Remove(newRoom);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Room>> GetAllWithRooms()
        {
            return await _unitOfWork.rooms
                .GetAllWithRoomAsync();
        }

        public async Task<Room> GetRoomById(int id)
        {
            return await _unitOfWork.rooms
                .GetWithRoomByIdAsync(id);
        }

        public async Task updateRoom(Room oldRoom, Room newRoom)
        {
            oldRoom.Name = newRoom.Name;
            oldRoom.Location = newRoom.Location;
            oldRoom.Capacity = newRoom.Capacity;
            oldRoom.RoomDescription = newRoom.RoomDescription;
            oldRoom.CompanyId = newRoom.CompanyId;
            oldRoom.UserId = newRoom.UserId;

            await _unitOfWork.CommitAsync();
        }
    }
}
