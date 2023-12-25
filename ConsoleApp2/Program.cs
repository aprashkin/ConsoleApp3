﻿
using car;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите расстояние (в км): ");
        int roadDistance = int.Parse(Console.ReadLine());
        double totalDistance = 0;

        Car selectedVehicle = null;

        while (totalDistance < roadDistance)
        {
            if (selectedVehicle == null)
            {
                Console.WriteLine("Выберите тип транспорта:");
                Console.WriteLine("1 - Автобус");
                Console.WriteLine("2 - Камаз");
                int vehicleChoice = int.Parse(Console.ReadLine());

                if (vehicleChoice == 1)
                {
                    selectedVehicle = new bus("Bus", 80, 15.0, 0);
                }
                else if (vehicleChoice == 2)
                {
                    selectedVehicle = new kamazz("Autotruck", 80, 20.0, 0);
                }
                else
                {
                    Console.WriteLine("Неверный выбор транспорта. Попробуйте снова.");
                    continue;
                }
            }

            Console.WriteLine($"Выбран транспорт: {selectedVehicle.GetType().Name}");

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Движение");
            Console.WriteLine("2 - Разгон транспорта");
            Console.WriteLine("3 - Торможение транспорта");
            Console.WriteLine("4 - Оформить заправку транспорта");
            Console.WriteLine("5 - Вывести информацию о транспорте");
            Console.WriteLine("6 - Вход пассажиров или загрузка груза");
            Console.WriteLine("7 - Выход пассажиров или разгрузка груза");
            Console.WriteLine("8 - Выбрать другой транспорт");
            Console.WriteLine("9 - Выход");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите скорость для движения (в км/ч): ");
                    int speed = int.Parse(Console.ReadLine());
                    Console.Write("Введите расстояние: ");
                    double distance = double.Parse(Console.ReadLine());
                    selectedVehicle.PerformAction("move", speed, distance, 0);
                    totalDistance += distance;
                    break;

                case 2:
                    Console.Write("Введите скорость для разгона (в км/ч): ");
                    int additionalSpeed = int.Parse(Console.ReadLine());
                    selectedVehicle.PerformAction("razgon", additionalSpeed, 0, 0);
                    break;

                case 3:
                    selectedVehicle.PerformAction("tormozhenie", 0, 0, 0);
                    break;

                case 4:
                    Console.Write("Введите количество горючего для заправки (в литрах): ");
                    double top = double.Parse(Console.ReadLine());
                    selectedVehicle.PerformAction("zapravka", 0, 0, top);
                    break;

                case 5:
                    selectedVehicle.PerformAction("out", 0, 0, 0);
                    break;

                case 6:
                    if (selectedVehicle is bus)
                    {
                        Console.Write("Введите количество пассажиров для входа: ");
                        byte passToLoad = byte.Parse(Console.ReadLine());
                        ((bus)selectedVehicle).VhogPass(passToLoad);
                    }
                    else if (selectedVehicle is kamazz)
                    {
                        Console.Write("Введите количество груза для загрузки: ");
                        byte cargoToLoad = byte.Parse(Console.ReadLine());
                        ((kamazz)selectedVehicle).Zagryzka(cargoToLoad);
                    }
                    else
                    {
                        Console.WriteLine("Выбран неподходящий тип транспорта для посадки или загрузки.");
                    }
                    break;

                case 7:
                    if (selectedVehicle is bus)
                    {
                        Console.Write("Введите количество пассажиров для выхода: ");
                        byte passToUnload = byte.Parse(Console.ReadLine());
                        ((bus)selectedVehicle).VyhodPass(passToUnload);
                    }
                    else if (selectedVehicle is kamazz)
                    {
                        Console.Write("Введите количество груза для разгрузки: ");
                        byte cargoToUnload = byte.Parse(Console.ReadLine());
                        ((kamazz)selectedVehicle).Razgryzka(cargoToUnload);
                    }
                    else
                    {
                        Console.WriteLine("Выбран неподходящий тип транспорта для высадки или разгрузки.");
                    }
                    break;

                case 8:
                    selectedVehicle = null;
                    break;

                case 9:
                    Console.WriteLine("бб");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                    break;
            }

            if (selectedVehicle != null)
            {
                selectedVehicle.PerformAction("checkdtp", roadDistance, totalDistance, 1);
            }
        }
    }
}