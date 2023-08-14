using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns20230211_Builder
{// ДЗ от 2023 02 11
    // 1. Реалізувати паттерн Builder, предметну область обрати самостійно

    // Продукт
    class Pizza
    {
        public string Dough { get; set; } // тесто
        public string Sauce { get; set; } // соус
        public string Topping { get; set; } // начинка

        public void ShowInfo()
        {
            Console.WriteLine($"Dough: {Dough}");
            Console.WriteLine($"Sauce: {Sauce}");
            Console.WriteLine($"Topping: {Topping}");
        }
    }

    // Абстрактный строитель
    interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildTopping();
        Pizza GetResult();
    }

    // Конкретный строитель для пиццы Margherita
    class MargheritaPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void BuildDough()
        {
            _pizza.Dough = "Thin dough";
        }

        public void BuildSauce()
        {
            _pizza.Sauce = "Tomato sauce";
        }

        public void BuildTopping()
        {
            _pizza.Topping = "Cheese and basil";
        }

        public Pizza GetResult()
        {
            return _pizza;
        }
    }
    // Конкретный строитель для пиццы Pepperoni
    class PepperoniPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void BuildDough()
        {
            _pizza.Dough = "Thick dough";
        }

        public void BuildSauce()
        {
            _pizza.Sauce = "Tomato sauce with spices";
        }

        public void BuildTopping()
        {
            _pizza.Topping = "Pepperoni, cheese, and peppers";
        }

        public Pizza GetResult()
        {
            return _pizza;
        }
    }

    // Конкретный строитель для пиццы Hawaiian
    class HawaiianPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void BuildDough()
        {
            _pizza.Dough = "Medium dough";
        }

        public void BuildSauce()
        {
            _pizza.Sauce = "Sweet tomato sauce";
        }

        public void BuildTopping()
        {
            _pizza.Topping = "Ham, pineapple, and cheese";
        }

        public Pizza GetResult()
        {
            return _pizza;
        }
    }

    // Конкретный строитель для пиццы Vegetarian
    class VegetarianPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza = new Pizza();

        public void BuildDough()
        {
            _pizza.Dough = "Thin dough";
        }

        public void BuildSauce()
        {
            _pizza.Sauce = "Pesto sauce";
        }

        public void BuildTopping()
        {
            _pizza.Topping = "Tomatoes, peppers, mushrooms, and olives";
        }

        public Pizza GetResult()
        {
            return _pizza;
        }
    }

    // Директор
    class PizzaDirector
    {
        private IPizzaBuilder _builder;

        // Конструктор класса директора
        // Принимает на вход объект строителя, который будет использоваться для создания пиццы
        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder; // Сохраняем переданный строитель в поле _builder
        }

        // Метод Construct выполняет последовательные шаги создания пиццы
        // с использованием методов строителя (BuildDough, BuildSauce, BuildTopping)
        // В результате выполнения этих методов, объект строителя формирует
        // состояние пиццы с заданными характеристиками
        public void Construct()
        {
            _builder.BuildDough();
            _builder.BuildSauce();
            _builder.BuildTopping();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            IPizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder(); // Создание строителя для пиццы Маргарита
            PizzaDirector director = new PizzaDirector(margheritaPizzaBuilder); // Создание директора и передача ему строителя
            director.Construct(); // Построение пиццы с помощью директора
            Pizza margheritaPizza = margheritaPizzaBuilder.GetResult();
            margheritaPizza.ShowInfo(); // Вывод информации о пицце
            Console.WriteLine();

            IPizzaBuilder pepperoniPizzaBuilder = new PepperoniPizzaBuilder();
            PizzaDirector pepperoniPizzaDirector = new PizzaDirector(pepperoniPizzaBuilder);
            pepperoniPizzaDirector.Construct();
            Pizza pepperoniPizza = pepperoniPizzaBuilder.GetResult();
            pepperoniPizza.ShowInfo();
            Console.WriteLine();

            IPizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
            PizzaDirector hawaiianPizzaDirector = new PizzaDirector(hawaiianPizzaBuilder);
            hawaiianPizzaDirector.Construct();
            Pizza hawaiianPizza = hawaiianPizzaBuilder.GetResult();
            hawaiianPizza.ShowInfo();
            Console.WriteLine();

            IPizzaBuilder vegetarianPizzaBuilder = new VegetarianPizzaBuilder();
            PizzaDirector vegetarianPizzaDirector = new PizzaDirector(vegetarianPizzaBuilder);
            vegetarianPizzaDirector.Construct();
            Pizza vegetarianPizza = hawaiianPizzaBuilder.GetResult();
            vegetarianPizza.ShowInfo();
            Console.WriteLine();
        }
    }
}

//Dough: Thin dough
//Sauce: Tomato sauce
//Topping: Cheese and basil

//Dough: Thick dough
//Sauce: Tomato sauce with spices
//Topping: Pepperoni, cheese, and peppers

//Dough: Medium dough
//Sauce: Sweet tomato sauce
//Topping: Ham, pineapple, and cheese

//Dough: Medium dough
//Sauce: Sweet tomato sauce
//Topping: Ham, pineapple, and cheese

//Press any key to continue . . .