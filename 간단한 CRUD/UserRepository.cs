using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCrudApp
{
    public class UserRepository
    {
        private List<User> _users = new List<User>();
        private int _nextId = 1;

        // Create
        public void AddUser(string name, int age)
        {
            var user = new User { Id = _nextId++, Name = name, Age = age };
            _users.Add(user);
            Console.WriteLine("사용자가 추가되었습니다.");
        }

        // Read
        public User GetUser(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        // Update
        public void UpdateUser(int id, string name, int age)
        {
            var user = GetUser(id);
            if (user != null)
            {
                user.Name = name;
                user.Age = age;
                Console.WriteLine("사용자 정보가 수정되었습니다.");
            }
            else
            {
                Console.WriteLine("해당 ID의 사용자를 찾을 수 없습니다.");
            }
        }

        // Delete
        public void DeleteUser(int id)
        {
            var user = GetUser(id);
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine("사용자가 삭제되었습니다.");
            }
            else
            {
                Console.WriteLine("해당 ID의 사용자를 찾을 수 없습니다.");
            }
        }
    }
}
