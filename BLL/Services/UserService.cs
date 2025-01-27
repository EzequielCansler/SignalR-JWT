using DAL.Repositories;
using EL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }   

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public bool Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
                throw new ArgumentException("El nombre del usuario es obligatorio");
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("El correo del usuario es obligatorio");
            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("La contraseña del usuario es obligatorio");
            try
            {
                return _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al crear el usuario en el repo");
            }
            
        }
    }
}
