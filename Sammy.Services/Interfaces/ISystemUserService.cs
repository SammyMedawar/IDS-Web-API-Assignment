using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace Sammy.Services.Interfaces
{
    public interface ISystemUserService
    {
        Task<IEnumerable<SystemUser>> GetAllWithSystemUsers();
        //Task<Music> GetMusicById(int id);
        //Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId);
        //Task<Music> CreateMusic(Music newMusic);
        //Task UpdateMusic(Music musicToBeUpdated, Music music);
        //Task DeleteMusic(Music music);
    }
}
