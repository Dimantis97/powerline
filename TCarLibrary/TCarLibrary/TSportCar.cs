using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCarLibrary
{
    /// <summary>
    /// Класс спортивного автомобиля.
    /// </summary>
    public class TSportCar : TAuto
    {
        #region Constructors
        /// <summary>
        /// Конструктор.
        /// </summary>
        public TSportCar() : base("Спорткар", 0, 0, 0, 0) { }
        #endregion

        #region Methods
        /// <summary>
        /// Подсчет текущего запаса хода в зависимости от количества пассажиров и груза.
        /// </summary>
        /// <returns>Запас хода в км.</returns>
        public override float CalcCurrDist()
        {
            return CalcMaxDist(true);
        }
        #endregion
    }
}
