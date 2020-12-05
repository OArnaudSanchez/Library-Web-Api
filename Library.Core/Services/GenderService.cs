using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Interfaces;

namespace Library.Core.Services
{
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await _genderRepository.GetGenders();
        }

        public async Task<Gender> GetGender(int id)
        {
            return await _genderRepository.GetGender(id);
        }

        public async Task InsertGender(Gender genero)
        {
            //verificar si el genero ya existe
            var currentGenero = await _genderRepository.GetGenders();
            var isExists = currentGenero.Select(x=> x.NameGender == genero.NameGender).FirstOrDefault();
            if(isExists)
            {
                throw new Exception("El Genero Ya existe");
            }

            genero.Id = 0;
            await _genderRepository.InsertGender(genero);
        }

        public async Task<bool> UpdateGender(Gender genero)
        {
            var currentGenero = await _genderRepository.GetGender(genero.Id);
            if(currentGenero == null)
            {
                throw new Exception("El Genero no existe");
            }   

            return await _genderRepository.UpdateGender(genero) ? true : false;
        }

        public async Task<bool> DeleteGender(int id)
        {
            var currentGenero = await _genderRepository.GetGender(id);
            if(currentGenero == null)
            {
                throw new Exception("El Genero no existe");
            }   

            return await _genderRepository.DeleteGender(id) ? true : false;
        }
    }
}