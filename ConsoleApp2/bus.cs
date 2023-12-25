﻿namespace car
{
    class bus : Car
    {
        private int passanger;

        public bus(string num, double tank, double remainder, int passcount) : base(num, tank, remainder)
        {
            passanger = passcount;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"В автобусе {passanger} пассажиров");
        }

        public void VhogPass(int pass)
        {
            if (pass > 0)
            {
                if (pass + passanger <= 30)
                {
                    passanger += pass;
                    
                    if (passanger < 7)
                    {
                        speed -= 1.5;
                        rate += 0.15;
                    }
                    else if (passanger >= 7 && passanger < 15)
                    {
                        speed -= 2.5;
                        rate += 0.25;
                    }
                    else if (passanger >= 15 && passanger < 25)
                    {
                        speed -= 3.5;
                        rate += 0.35;
                    }
                    else if (passanger >= 25 && passanger < 30)
                    {
                        speed -= 5.0;
                        rate += 0.5;
                    }

                    Console.WriteLine($"В автобус зашло {pass} человек. Общее кол-во пассажиров: {passanger}. Расход горючего и скорость изменены.");
                }
                else
                {
                    Console.WriteLine("Превышено максимальное кол-во пассажиров (30 человек)");
                }
            }
        }

        public void VyhodPass(int pass)
        {
            if (pass > 0 && pass <= passanger)
            {
                passanger -= pass;
                if (passanger < 7)
                {
                    speed += 1.5;
                    rate -= 0.15;
                }
                else if (passanger >= 7 && passanger < 15)
                {
                    speed += 2.5;
                    rate -= 0.25;
                }
                else if (passanger >= 15 && passanger < 25)
                {
                    speed += 3.5;
                    rate -= 0.35;
                }
                else if (passanger >= 25 && passanger < 30)
                {
                    speed += 5.0;
                    rate -= 0.5;
                }

                Console.WriteLine($"Из автобуса вышло {pass} человек. Общее кол-во пассажиров: {passanger} человек. Расход горючего и скорость изменены.");
            }
            else
            {
                Console.WriteLine("Из автобуса не может выйти столько человек.");
            }
        }
    }
}