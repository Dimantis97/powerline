using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCarLibrary
{
    /// <summary>
    /// Класс легкового автомобиля.
    /// </summary>
    public class TCar : TAuto
    {
        private int fiPassPlaces; //кол-во пассажирских мест
        private int fiPassNum; //кол-во пассажиров

        #region Constructors
        /// <summary>
        /// Конструктор.
        /// </summary>
        public TCar() : this("Легковой автомобиль", 0, 0, 0, 0, 0, 0) { }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="_sType">Тип автомобиля.</param>
        /// <param name="_fAvarFuelConsumption">Средний расход топлива л/сотню км.</param>
        /// <param name="_fFuelTankVolume">Объем топливного бака л.</param>
        /// <param name="_fCurrFuelVolume">Текущий объем топлива в баке.</param>
        /// <param name="_fSpeed">Скорость в км/ч.</param>
        /// <param name="_iPassPlaces">Количество пассажирских мест.</param>
        /// <param name="_iPassNum">Текущее количество пассажиров.</param>
        public TCar(string _sType, float _fAvarFuelConsumption, float _fFuelTankVolume, float _fCurrFuelVolume, float _fSpeed, int _iPassPlaces, int _iPassNum) : 
            base(_sType, _fAvarFuelConsumption, _fFuelTankVolume, _fCurrFuelVolume, _fSpeed)
        {
            if (_iPassNum > _iPassPlaces)
                throw new ArgumentOutOfRangeException("_iPassNum", "Количество пассажирова _iPassNum не может быть больше по значению количества пассажирских мест _iPassPlaces");
            if(_iPassNum < 0)
                throw new ArgumentOutOfRangeException("_iPassNum", "Количество пассажирова _iPassNum не может быть меньше 0");
            if (_iPassPlaces < 0)
                throw new ArgumentOutOfRangeException("_iPassPlaces", "Количество пассажирских мест _iPassPlaces не может быть меньше 0");
            fiPassNum = _iPassNum;
            fiPassPlaces = _iPassPlaces;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод посадки пассажиров.
        /// </summary>
        /// <param name="_iPassNum">Кол-во пассажиров.</param>
        /// <returns>Количество свободных мест.</returns>
        public int PassengersIn(int _iPassNum)
        {
            if (iPassNum + _iPassNum > iPassPlaces)
                throw new ArgumentOutOfRangeException("_iPassNum", "Слишком много пассажиров, не хватает свободных мест.");
            if(_iPassNum < 0)
                throw new ArgumentOutOfRangeException("_iPassNum", "Количество загружаемых пассажиров не может быть меньше 0");
            fiPassNum += _iPassNum;
            return iPassPlaces - iPassNum;
        }
        /// <summary>
        /// Метод выгрузки пассажиров.
        /// </summary>
        /// <param name="_iPassNum">Кол-во пассажиров.</param>
        /// <returns>Количество свободных мест.</returns>
        public int PassengersOut(int _iPassNum)
        {
            if (_iPassNum > iPassNum)
                throw new ArgumentOutOfRangeException("_iPassNum", "Слишком много пассажиров, в автомобиле меньшее количество пассажиров.");
            if (_iPassNum < 0)
                throw new ArgumentOutOfRangeException("_iPassNum", "Количество выгружаемых пассажиров не может быть меньше 0");
            fiPassNum -= _iPassNum;
            return iPassPlaces - iPassNum;
        }
        /// <summary>
        ///  Подсчет текущего запаса хода в зависимости от количества пассажиров.
        /// </summary>
        /// <returns>Запас хода в км.</returns>
        public override float CalcCurrDist()
        {
            return CalcMaxDist(true) * ((float)(1 - iPassNum * 0.06));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Количество пассажирских мест.
        /// </summary>
        public int iPassPlaces
        {
            get { return fiPassPlaces; }
        }
        /// <summary>
        /// Количество пассажиров.
        /// </summary>
        public int iPassNum
        {
            get { return fiPassNum; }
        }
        #endregion
    }
}
