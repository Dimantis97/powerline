using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCarLibrary
{
    /// <summary>
    /// Абстрактны класс автомобиля.
    /// </summary>
    public abstract class TAuto
    {
        private string fsType;               //тип транспортного средства
        private float ffAvarFuelConsumption; //средний расход топлива л/сотню км.
        private float ffFuelTankVolume;      //объем топливного бака л.
        private float ffCurrFuelVolume;      //текущий объем топлива в баке
        private float ffSpeed;               //скорость км/ч

        #region Constructors
        /// <summary>
        /// Конмтруктор.
        /// </summary>
        public TAuto() : this("Автомобиль", 0, 0, 0, 0) { }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="_sType">Тип автомобиля.</param>
        /// <param name="_fAvarFuelConsumption">Средний расход топлива л/сотню км.</param>
        /// <param name="_fFuelTankVolume">Объем топливного бака л.</param>
        /// <param name="_fCurrFuelVolume">Текущий объем топлива в баке.</param>
        /// <param name="_fSpeed">Скорость в км/ч.</param>
        /// <exception cref="ArgumentOutOfRangeException">При неверном параметре - данный exception.</exception>
        public TAuto(string _sType, float _fAvarFuelConsumption, float _fFuelTankVolume, float _fCurrFuelVolume, float _fSpeed)
        {
            //блок проверок
            if (_fAvarFuelConsumption <= 0)
                throw new ArgumentOutOfRangeException("_fAvarFuelConsumption", "Потребление топлива не может быть меньше или равно 0.");
            if (_fFuelTankVolume <= 0)
                throw new ArgumentOutOfRangeException("_fFuelTankVolume", "Объем топливного бака не может быть меньше или равно 0.");
            if (_fCurrFuelVolume <= 0)
                throw new ArgumentOutOfRangeException("_fCurrFuelVolume", "Объем топлива не может быть меньше или равно 0.");
            if (_fCurrFuelVolume > _fFuelTankVolume)
                throw new ArgumentOutOfRangeException("_fCurrFuelVolume", "Объем топлива не может быть больше топливного бака.");
            if(_fSpeed < 0)
                throw new ArgumentOutOfRangeException("_fMaxSpeed", "Скорость не может быть меньше 0.");
            ffAvarFuelConsumption = _fAvarFuelConsumption;
            ffFuelTankVolume = _fFuelTankVolume;
            ffCurrFuelVolume = _fCurrFuelVolume;
            ffSpeed = _fSpeed;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Метод рассчета максимальной дистанции, которую может проехать автомобиль.
        /// </summary>
        /// <param name="_bCountCurrFuel">Учитывать текущий объем топлива. Если true - то рассчет по текущему объему топлива.</param>
        /// <returns>Дистанция в км.</returns>
        public float CalcMaxDist(bool _bCountCurrFuel=false)
        {
            if (_bCountCurrFuel)
                return fCurrFuelVolume / fAvarFuelConsumption * 100;
            else
                return fFuelTankVolume / fAvarFuelConsumption * 100;
        }
        /// <summary>
        /// Метод подсчета времени, за которое автомобиль проедет указанную дистанцию.
        /// </summary>
        /// <param name="_fFuelVolume">Объем топлива.</param>
        /// <param name="_fDistance">Дистанция.</param>
        /// <returns>Время в пути; если не хватает топлива, то -1.</returns>
        public float CalcTime(float _fFuelVolume, float _fDistance)
        {
            if (_fFuelVolume / fAvarFuelConsumption * 100 < _fDistance)
                return -1;
            return _fDistance / fSpeed;
        }
        /// <summary>
        /// Заправка автомобиля.
        /// </summary>
        /// <param name="_fFuelVolume">Объем топлива, заливаемого в бак.</param>
        /// <returns></returns>
        public void Refuel(float _fFuelVolume)
        {
            if (_fFuelVolume + fCurrFuelVolume > fFuelTankVolume)
                throw new ArgumentOutOfRangeException("_fFuelVolume", "Данный объем топлива не влезет в бак.");
            ffCurrFuelVolume += _fFuelVolume;
        }
        /// <summary>
        /// Подсчет текущего запаса хода в зависимости от количества пассажиров и груза.
        /// </summary>
        /// <returns>Запас хода в км.</returns>
        public abstract float CalcCurrDist();
        #endregion

        #region Properties
        /// <summary>
        /// Тип автомобиля.
        /// </summary>
        public string sType
        {
            get { return fsType; }
        }
        /// <summary>
        /// Средний расход топлива л/сотню км.
        /// </summary>
        public float fAvarFuelConsumption
        {
            get { return ffAvarFuelConsumption; }
        }
        /// <summary>
        /// Объем топливного бака.
        /// </summary>
        public float fFuelTankVolume
        {
            get { return ffFuelTankVolume; }
        }
        /// <summary>
        /// Текущий объем топлива в баке.
        /// </summary>
        public float fCurrFuelVolume
        {
            get { return ffCurrFuelVolume; }
        }
        /// <summary>
        /// Максимальная скорость автомобиля.
        /// </summary>
        public float fSpeed
        {
            get { return ffSpeed; }
        }
        #endregion
    }
}
