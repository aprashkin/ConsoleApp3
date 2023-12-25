﻿using System.ComponentModel.DataAnnotations;

namespace car
{
    class Car
    {
        protected string number;
        protected double rate;
        protected double remainder;
        protected double speed;
        protected double run;

        public Car(string num, double tank, double rashod)
        {
            number = num;
            rate = rashod;
            remainder = tank;
            speed = 0.0;
            run = 0.0;
        } 
        public void info(string num, double tank, double rashod)
        {
            number = num;
            rate = rashod;
            remainder = tank;
            speed = 0.0;
            run = 0.0;
        }
        public virtual void Out()
        {
            Console.WriteLine($"Номер машины: {number}");
            Console.WriteLine($"Остаток топлива: {Math.Round(remainder, 2)} л");
            Console.WriteLine($"Расход топлива: {rate} л/100км");
            Console.WriteLine($"Скорость: {speed} км/ч");
            Console.WriteLine($"Пробег: {run} км");
        }
        protected void GetFuel(double getfuel)
        {
            if (getfuel <= 0)
            {
                Console.WriteLine("Нельзя не заправить машину или заправить отрицательным количеством топлива");
            }

            if (getfuel + remainder >= 70)
            {
                Console.WriteLine("Бак не резиновый. Максимум - 70 л. Всё остальное вылилось на асфальт...");
                remainder = 70;
            }

            else
            {
                remainder =+ getfuel;
                Console.WriteLine($"Вы заправили {getfuel:F2} литров бензина. В баке теперь {remainder:F2} литров.");
            }
        }
        protected void Tormoz()
        {
            speed = 0.0;
            Console.WriteLine("Транспорт остановлен.");
        }
        protected void Razgon(int razgon)
        {
            if (remainder >= 1.0)
            {
                if (razgon <= 150)
                {
                    speed = +razgon;
                    rate += 1.0;
                    Console.WriteLine($"Скорость транспорта увеличена до {speed}. Расход топлива увеличен.");
                }
                
            }
        }
        protected bool Dtp(int road, double totalroad)
        {
            if (road >= totalroad)
            {
                return true;
            }

            return false;
        }
        protected void ItogDistance(int distance)
        {
            run += distance;
        }
        protected double Ost()
        {
            return rate;
        }
        protected void Move(int speed, double distance)
        {
            if (speed <= 0)
            {
                Console.WriteLine("Скорость должна быть больше нуля.");
                return;
            }

            if (speed > 190)
            {
                Console.WriteLine("Скорость не может превышать 190 км/ч. Скорость установлена на максимум (190 км/ч).");
                speed = 190;
            }

            double time = distance / speed;
            double rashodToplivaNaKm = rate / 100;
            double rashod = distance * rashodToplivaNaKm;

            if (remainder >= rashod)
            {
                remainder -= rashod;
                run += distance;
                Console.WriteLine($"Проехано {distance} км со скоростью {speed} км/ч c временем {time:F2} ч. Остаток топлива: {remainder:F2} л");
                this.speed = speed;
            }
            else
            {
                double maxDistance = remainder / rashodToplivaNaKm;

                if (maxDistance > 0)
                {
                    Console.WriteLine($"Недостаточно топлива для поездки на всю дистанцию {distance} км.");
                    Console.WriteLine($"Машина проедет {maxDistance} км со скоростью {speed} км/ч.");
                    run += maxDistance;
                    Console.WriteLine("Машина проехала максимальное расстояние с текущим количеством топлива.");

                    double neededFuel = rashod - remainder;
                    Console.WriteLine($"Для дозаправки требуется {neededFuel:F2} литров топлива.");

                    if (neededFuel > 0)
                    {
                        Console.Write("Желаете дозаправить машину? (Да/Нет): ");
                        string choice = Console.ReadLine();
                        if (choice.ToLower() == "да")
                        {
                            Console.Write($"Введите желаемое количество топлива для дозаправки (максимум {remainder:F2} литров): ");
                            double topUpAmount = double.Parse(Console.ReadLine());

                            if (topUpAmount > 0 && topUpAmount <= neededFuel)
                            {
                                remainder += topUpAmount;
                                Console.WriteLine($"Заправлено {topUpAmount:F2} литров топлива. В баке теперь {remainder:F2} литров топлива.");
                            }
                            else if (topUpAmount > neededFuel)
                            {
                                Console.WriteLine("Бак был заправлен полностью.");
                            }
                            else
                            {
                                Console.WriteLine("Неправильное количество топлива. Введите положительное число.");
                            }

                            Move(speed, distance - maxDistance);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Недостаточно топлива для поездки.");
                }
            }
            
        }
        public void PerformAction(string action, int param1, double param2, double param3)
        {
            switch (action.ToLower())
            {
                case "info":
                    info(number, remainder, rate);
                    break;
                case "out":
                    Out();
                    break;
                case "zapravka":
                    GetFuel(param3);
                    break;
                case "move":
                    Move(param1, param2);
                    break;
                case "tormozhenie":
                    Tormoz();
                    break;
                case "razgon":
                    Razgon(param1);
                    break;
                case "checkdtp":
                    Dtp(param1, param2);
                    break;
                case "proydennoerast":
                    ItogDistance(param1);
                    break;
                case "ostatok":
                    Ost();
                    break;
                default:
                    Console.WriteLine("Такое.");
                    break;
            }
        }
    }
}