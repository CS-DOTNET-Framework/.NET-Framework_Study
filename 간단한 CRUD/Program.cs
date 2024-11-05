using System;

namespace SimpleCrudApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            while (true)
            {
                Console.WriteLine("\n사용자 관리 시스템");
                Console.WriteLine("1. 사용자 추가");
                Console.WriteLine("2. 사용자 조회");
                Console.WriteLine("3. 사용자 수정");
                Console.WriteLine("4. 사용자 삭제");
                Console.WriteLine("5. 모든 사용자 조회");
                Console.WriteLine("0. 종료");
                Console.Write("메뉴를 선택하세요: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("이름: ");
                        var name = Console.ReadLine();
                        Console.Write("나이: ");
                        var age = int.Parse(Console.ReadLine());
                        userRepository.AddUser(name, age);
                        break;

                    case "2":
                        Console.Write("조회할 사용자 ID: ");
                        var idToGet = int.Parse(Console.ReadLine());
                        var user = userRepository.GetUser(idToGet);
                        if (user != null)
                            Console.WriteLine($"ID: {user.Id}, 이름: {user.Name}, 나이: {user.Age}");
                        else
                            Console.WriteLine("해당 ID의 사용자를 찾을 수 없습니다.");
                        break;

                    case "3":
                        Console.Write("수정할 사용자 ID: ");
                        var idToUpdate = int.Parse(Console.ReadLine());
                        Console.Write("새 이름: ");
                        var newName = Console.ReadLine();
                        Console.Write("새 나이: ");
                        var newAge = int.Parse(Console.ReadLine());
                        userRepository.UpdateUser(idToUpdate, newName, newAge);
                        break;

                    case "4":
                        Console.Write("삭제할 사용자 ID: ");
                        var idToDelete = int.Parse(Console.ReadLine());
                        userRepository.DeleteUser(idToDelete);
                        break;

                    case "5":
                        Console.WriteLine("모든 사용자 목록:");
                        var users = userRepository.GetAllUsers();
                        foreach (var u in users)
                            Console.WriteLine($"ID: {u.Id}, 이름: {u.Name}, 나이: {u.Age}");
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 시도하세요.");
                        break;
                }
            }
        }
    }
}
