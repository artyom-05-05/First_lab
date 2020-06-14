using System;

namespace Lab7
{
    class Program9
    //Variant 2
    {
        static void Main(string[] args)
        {
            Complex_number a = new Complex_number(1, 3);
            Complex_number b = new Complex_number(3.5, -4);
            Complex_number c = new Complex_number(-7.5, -11.8);

            b.SetReZ(2.5);
            Console.WriteLine("Комплексное число b = {0}", b.AlgebraicForm());

            Console.WriteLine($"Сумма a + b = ({a.AlgebraicForm()}) + ({b.AlgebraicForm()}) = {a.Sum(b).AlgebraicForm()}");
            Console.WriteLine($"Разность a - b = ({a.AlgebraicForm()}) - ({b.AlgebraicForm()}) = {a.Difference(b).AlgebraicForm()}");
            Console.WriteLine($"Произвдение a * b = ({a.AlgebraicForm()}) * ({b.AlgebraicForm()}) = {a.Product(b).AlgebraicForm()}");

            Console.WriteLine($"Модуль числа с = {c.FindModulus()}");
        }
    }
}
