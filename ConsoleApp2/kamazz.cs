﻿namespace car
{
    class kamazz : Car
    {
        private int gryz;

        public kamazz(string num, double tank, double rate, int countgryz) : base(num, tank, rate)
        {
            gryz = countgryz;
        }

        public override void Out()
        {
            base.Out();
            Console.WriteLine($"Кол-во груза в Камазе: {gryz}");
        }

        public void Zagryzka(int cargo)
        {
            if (cargo > 0)
            {
                if (cargo + gryz <= 30)
                {
                    gryz += cargo;
                    if (gryz < 7)
                    {
                        speed -= 1.5;
                        rate += 0.15;
                    }
                    else if (gryz < 15)
                    {
                        speed -= 2.5;
                        rate += 0.25;
                    }
                    else if (gryz < 25)
                    {
                        speed -= 3.5;
                        rate += 0.35;
                    }
                    else if (gryz < 30)
                    {
                        speed -= 5.5;
                        rate += 0.55;
                    }

                    Console.WriteLine($"Загрузили {cargo} единиц груза. Всего груза: {gryz}. Расход горючего и скорость изменены.");
                }
                else
                {
                    Console.WriteLine($"Не удалось загрузить {cargo} единиц груза. Будет перегруз.");
                }
            }
        }


        public void Razgryzka(int cargo)
        {
            if (cargo > 0 && cargo <= gryz)
            {
                gryz -= cargo;

                if (gryz < 7)
                {
                    speed += 5.0;
                    rate -= 0.5;
                }
                else if (gryz < 15)
                {
                    speed += 3.5;
                    rate -= 0.35;
                }
                else if (gryz < 25)
                {
                    speed += 2.5;
                    rate -= 0.25;
                }
                else if (gryz < 30)
                {
                    speed += 1.5;
                    rate -= 0.15;
                }

                Console.WriteLine($"Выгрузили {cargo} единиц груза. Всего груза: {gryz}. Расход горючего и скорость изменены.");
            }
            else
            {
                Console.WriteLine("Невозможно выгрузить такое количество груза.");
            }
        }

    }
}