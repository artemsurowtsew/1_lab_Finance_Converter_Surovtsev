using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_lab_Finance_converter_Surovtsev
{
    internal class Program
    {
        /// <summary>
        /// Основна точка входу для програми.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Це дозволяє працювати з графічним інтерфейсом Windows Forms.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Запускаємо вашу форму ExchangeRate як головну форму.
            Application.Run(new ExchangeRate());
        }
    }
}
    

