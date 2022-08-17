using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCarLibrary
{
    /// <summary>
    /// Класс грузового автомобиля.
    /// </summary>
    public class TTrack : TAuto
    {
        private float ffMaxCargoWeight; //макс. вес груза в кг.
        private float ffCurrCargoWeight; //текущий вес груза в кг.

        #region Constructors
        /// <summary>
        /// Конструктор.
        /// </summary>
        public TTrack() : this("Грузовой автомобиль", 0, 0, 0, 0, 0, 0) { }
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="_sType">Тип автомобиля.</param>
        /// <param name="_fAvarFuelConsumption">Средний расход топлива л/сотню км.</param>
        /// <param name="_fFuelTankVolume">Объем топливного бака л.</param>
        /// <param name="_fCurrFuelVolume">Текущий объем топлива в баке.</param>
        /// <param name="_fSpeed">Скорость в км/ч.</param>
        /// <param name="_fMaxCargoWeight">Макс. вес груза в кг.</param>
        /// <param name="_fCurrCargoWeight">Текущий вес груза в кг.</param>
        public TTrack(string _sType, float _fAvarFuelConsumption, float _fFuelTankVolume, float _fCurrFuelVolume, float _fSpeed, float _fMaxCargoWeight, float _fCurrCargoWeight) :
            base(_sType, _fAvarFuelConsumption, _fFuelTankVolume, _fCurrFuelVolume, _fSpeed)
        {
            if (_fCurrCargoWeight > _fMaxCargoWeight)
                throw new ArgumentOutOfRangeException("_fCurrCargoWeight", "Количество груза _fCurrCargoWeight не может быть больше по значению максимальной грузоподъемности _fMaxCargoWeight");
            if (_fMaxCargoWeight < 0)
                throw new ArgumentOutOfRangeException("_fMaxCargoWeight", "Максимальная грузоподъемнось _fMaxCargoWeight не может быть меньше 0");
            if (_fCurrCargoWeight < 0)
                throw new ArgumentOutOfRangeException("_fCurrCargoWeight", "Текущий вес груза _fCurrCargoWeight не может быть меньше 0");
            ffCurrCargoWeight = _fCurrCargoWeight;
            ffMaxCargoWeight = _fMaxCargoWeight;
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Подсчет текущего запаса хода в зависимости от веса груза.
        /// </summary>
        /// <returns>Запас хода в км.</returns>
        public override float CalcCurrDist()
        {
            /*
             * Метод подсчета: вычисляем, сколько раз по 200 кг в текущем грузе,
             * затем умножаем на 4%. Затем вычитем из 100%. Получаем % от текущей 
             * максимальной дальности. Умножаем на максимальную дальность на текущем
             * запасе топлива.
             */
            return CalcMaxDist(true) * (float)(1 - ((int)Math.Truncate((double)(fCurrCargoWeight / 200)))*0.04);
        }
        /// <summary>
        /// Метод загрузки груза.
        /// </summary>
        /// <param name="_fCargoWeight">Загружаемый груз в кг.</param>
        /// <returns>Запас грузоподъемности в кг.</returns>
        public float LoadCargo(float _fCargoWeight)
        {
            if (fCurrCargoWeight + _fCargoWeight > fMaxCargoWeight)
                throw new ArgumentOutOfRangeException("_fCargoWeight", "Слишком большой вес груза. С текущим грузом превышает грузоподъемность");
            if (_fCargoWeight < 0)
                throw new ArgumentOutOfRangeException("_fCargoWeight", "Вес груза не может быть меньше 0.");
            ffCurrCargoWeight += _fCargoWeight;
            return fMaxCargoWeight - fCurrCargoWeight;

        }
        /// <summary>
        /// Метод разгрузки груза.
        /// </summary>
        /// <param name="_fCargoWeight">Выгружаемый груз в кг.</param>
        /// <returns>Запас грузоподъемности в кг.</returns>
        public float UnloadCargo(float _fCargoWeight)
        {
            if (_fCargoWeight > fCurrCargoWeight)
                throw new ArgumentOutOfRangeException("_fCargoWeight", "Слишком большой вес груза. Больше текущего груза.");
            if (_fCargoWeight < 0)
                throw new ArgumentOutOfRangeException("_fCargoWeight", "Вес груза не может быть меньше 0.");
            ffCurrCargoWeight -= _fCargoWeight;
            return fMaxCargoWeight - fCurrCargoWeight;
        }
        /// <summary>
        /// Проверка, можно ли загрузить максимальный груз.
        /// </summary>
        /// <returns>true - если да, false - если нет.</returns>
        public bool CheckMaxWeightLosd()
        {
            return fCurrCargoWeight == 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Макс. вес груза в кг.
        /// </summary>
        public float fMaxCargoWeight
        {
            get { return ffMaxCargoWeight; }
        }
        /// <summary>
        /// Текущий вес груза в кг.
        /// </summary>
        public float fCurrCargoWeight
        {
            get { return ffCurrCargoWeight; }
        }
        #endregion
    }
}
