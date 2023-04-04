using System;

namespace QA_Lab3_Grigoryev
{
    /// <summary>
    /// Базовый класс "Урожай"
    /// </summary>
    class Crop
    {
        protected double fertilizerCostPerHectare;
        protected double revenuePerHectare;
        /// <summary>
        /// Конструктор класса Crop, инициализирующий переменные fertilizerCostPerHectare 
        /// и revenuePerHectare значениями переданных параметров
        /// </summary> 
        /// <param name="fertilizerCostPerHectare"></param> Стоимость удобрений на гектар
        /// <param name="revenuePerHectare"></param> Доход с гектара
        public Crop(double fertilizerCostPerHectare, double revenuePerHectare)
        {
            this.fertilizerCostPerHectare = fertilizerCostPerHectare;
            this.revenuePerHectare = revenuePerHectare;
        }
        /// <summary>
        /// Метод, расчитывающий прибыль от посева определенного количества тонн культуры
        /// Прибыль от посева заданного количества тонн культуры
        /// </summary>
        /// <param name="tonsPlanted"></param> Количество тонн посева
        /// <returns></returns>
        public virtual double CalculateProfit(int tonsPlanted)
        {
            double expenses = fertilizerCostPerHectare * tonsPlanted;
            double revenue = revenuePerHectare * tonsPlanted;
            return revenue - expenses;
        }
        /// <summary>
        /// Метод, вызываемый для ввода пользователем значений переменных 
        /// </summary>
        public virtual void Init()
        {
            Console.Write("Enter fertilizer cost per hectare: ");
            fertilizerCostPerHectare = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter revenue per hectare: ");
            revenuePerHectare = Convert.ToDouble(Console.ReadLine());
        }
        /// <summary>
        ///  Метод, выводящий значения переменных fertilizerCostPerHectare
        ///  и revenuePerHectare в консоль
        /// </summary>
        public virtual void Display()
        {
            Console.WriteLine("Fertilizer cost per hectare: {0}", fertilizerCostPerHectare);
            Console.WriteLine("Revenue per hectare: {0}", revenuePerHectare);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /**
         * Оператор сложения для двух объектов Crop, создает новый объект Crop с переменными значениями,
         * которые являются средними значениями переменных объектов, складываемых оператором сложения
         * @f$ fertilizerCostPerHectare = (c1.fertilizerCostPerHectare + c2.fertilizerCostPerHectare) / 2 @f$
         * @f$ revenuePerHectare = (c1.revenuePerHectare + c2.revenuePerHectare) / 2 @f$
         * @return новый экземпляр удобрение и стоимость на гектар
         */
        public static Crop operator +(Crop c1, Crop c2)
        {
            double fertilizerCostPerHectare = (c1.fertilizerCostPerHectare + c2.fertilizerCostPerHectare) / 2;
            double revenuePerHectare = (c1.revenuePerHectare + c2.revenuePerHectare) / 2;
            return new Crop(fertilizerCostPerHectare, revenuePerHectare);
        }
    }
    /// <summary>
    /// Производный класс "Выращивание урожая"
    /// </summary>
    class GrowingCrop : Crop
    {
        private double additionalEconomicActivityProfit;
        /// <summary>
        /// Конструктор класса GrowingCrop, инициализирующий переменные
        /// fertilizerCostPerHectare, revenuePerHectare и additionalEconomicActivityProfit
        /// значениями переданных параметров
        /// </summary>
        /// <param name="fertilizerCostPerHectare"></param> Стоимость удобрений на гектар
        /// <param name="revenuePerHectare"></param> Доход с гектара
        /// <param name="additionalEconomicActivityProfit"></param> Дополнительный экономический доход
        public GrowingCrop(double fertilizerCostPerHectare, double revenuePerHectare, double additionalEconomicActivityProfit)
            : base(fertilizerCostPerHectare, revenuePerHectare)
        {
            this.additionalEconomicActivityProfit = additionalEconomicActivityProfit;
        }
        /// <summary>
        /// Свойство AdditionalEconomicActivityProfit, 
        /// позволяющее получить и задать значение переменной additionalEconomicActivityProfit
        /// </summary>
        public double AdditionalEconomicActivityProfit
        {
            get { return additionalEconomicActivityProfit; }
            set { additionalEconomicActivityProfit = value; }
        }
        /// <summary>
        ///  Метод, вызывающий пользовательский ввод значения
        ///  переменной additionalEconomicActivityProfit
        /// </summary>
        public void PutAdditionalEconomicActivityProfit()
        {
            Console.Write("Enter additional economic activity profit: ");
            additionalEconomicActivityProfit = Convert.ToDouble(Console.ReadLine());
        }
        /// <summary>
        /// Метод, выводящий значение переменной additionalEconomicActivityProfit в консоль
        /// </summary>
        public void GetAdditionalEconomicActivityProfit()
        {
            Console.WriteLine("Additional economic activity profit: {0}", additionalEconomicActivityProfit);
        }
        /// <summary>
        /// Переопределенный метод CalculateProfit,
        /// расчитывающий прибыль от посева определенного количества тонн культуры,
        /// учитывая дополнительный экономический доход
        /// </summary>
        /// <param name="tonsPlanted"></param> Количество тонн посева
        /// <returns></returns>
        public override double CalculateProfit(int tonsPlanted)
        {
            double expenses = (fertilizerCostPerHectare * tonsPlanted) / 2;
            double revenue = (revenuePerHectare * tonsPlanted) + additionalEconomicActivityProfit;
            return revenue - expenses;
        }
        /// <summary>
        /// Переопределенный метод Init от базового класса Crop
        /// Запрос у пользователя на ввод прибыли от дополнительной экономической
        /// деятельности и сохранение данных в поле additionalEconomicActivityProfit
        /// </summary>
        public override void Init()
        {
            base.Init();
            Console.Write("Enter additional economic activity profit: ");
            additionalEconomicActivityProfit = Convert.ToDouble(Console.ReadLine());
        }
        /// <summary>
        /// Переопределенный метод Display от базового класса Crop
        /// Выводит на экран информацию о культуре
        /// То есть стоимость затрат на удобрение на гектар, стоимость от продажи с одного гектара
        /// и прибыль от дополнительной экономической деятельности
        /// </summary>
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Additional economic activity profit: {0}", additionalEconomicActivityProfit);
        }
    }
    /// <summary>
    /// Cодержит данные о типах выращиваемых культур и количестве посаженных тонн каждого типа,
    /// а также дополнительный доход
    /// Массив crops содержит три элемента типа Crop.
    ///Массив tonsPlanted содержит три элемента типа int.
    ///Каждый элемент соответствует количеству посаженных тонн для каждого элемента в массиве crops.
    ///Переменная additionalProfit содержит дополнительный доход,
    ///который может быть получен от выращивания культур.
    /// </summary>
    class Village
    {
        public Crop[] crops = new Crop[3];
        public int[] tonsPlanted = new int[3];
        public double additionalProfit;
        /// <summary>
        /// Конструктор Village принимает шесть параметров типа Crop, int и double.
        /// Он инициализирует массивы crops и tonsPlanted,
        /// а также переменную additionalProfit, используя переданные значения.
        /// </summary>
        /// <param name="crop1"></param> Первый урожай
        /// ![Image](../images/corn.jpg)
        /// <param name="crop2"></param> Второй урожай
        ///  ![Image](../images/corn7.jpg)
        /// <param name="crop3"></param> Третий урожай
        /// ![Image](../images/soya.jpg)
        /// <param name="tonsPlanted1"></param> Посажено тонн на первом
        /// <param name="tonsPlanted2"></param> Посажено тонн на втором
        /// <param name="tonsPlanted3"></param> Посажено тонн на третьем
        /// <param name="additionalProfit"></param>
        public Village(Crop crop1, Crop crop2, Crop crop3, int tonsPlanted1, int tonsPlanted2, int tonsPlanted3, double additionalProfit)
        {
            crops[0] = crop1;
            crops[1] = crop2;
            crops[2] = crop3;
            this.tonsPlanted[0] = tonsPlanted1;
            this.tonsPlanted[1] = tonsPlanted2;
            this.tonsPlanted[2] = tonsPlanted3;
            this.additionalProfit = additionalProfit;
        }
        /// <summary>
        /// Возвращает максимальную прибыль с выбором с/x культуры и ее индекс в массиве 
        /// </summary>
        /// <param name="cropIndex"></param>
        /// <returns></returns>
        public double MaxProfit(out int cropIndex)
        {
            double maxProfit = 0;
            cropIndex = -1;

            for (int i = 0; i < crops.Length; i++)
            {
                double profit = crops[i].CalculateProfit(tonsPlanted[i]) + additionalProfit;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                    cropIndex = i;
                }
            }
            return maxProfit;
        }
    }
    /// <summary>
    /// Cодержит метод Main, который является точкой входа в программу
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу - Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // create static objects
            Crop corn = new Crop(20.5, 1000); //кукуруза
            GrowingCrop soybean = new GrowingCrop(10.8, 1300, 5000); //соя 
            //село, которое содержит внутри себя кукурузу и сою
            Village village = new Village(corn, soybean, new Crop(30, 800), 100, 50, 75, 2000);
            //initialize objects для всех с/х культур
            corn.Init();
            soybean.Init();
            //display objects для всех с/х культур
            Console.WriteLine("Corn:");
            corn.Display();
            Console.WriteLine("Soybean:");
            soybean.Display();
            Console.WriteLine("Village crops:");
            for (int i = 0; i < village.crops.Length; i++)
            {
                Console.Write("Crop {0}: ", i + 1);
                village.crops[i].Display();
                Console.WriteLine("Tons planted: {0}", village.tonsPlanted[i]);
            }
            Console.WriteLine("Additional profit: {0}", village.additionalProfit);

            //расчет максимальной прибыли
            int cropIndex;
            double maxProfit = village.MaxProfit(out cropIndex);
            Console.WriteLine("Max profit: {0} from crop {1}", maxProfit, cropIndex + 1);

            //комбинированная культура 
            Crop combinedCrop = corn + soybean;
            Console.WriteLine("Combined crop:");
            combinedCrop.Display();
            Console.ReadKey();
        }
    }
}