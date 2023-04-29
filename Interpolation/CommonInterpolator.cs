using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    internal class CommonInterpolator
    {
        private double[] _x;
        private double[] _y;

        public CommonInterpolator(double[] x, double[] y)
        {
            _x = x;
            _y = y;
            
        }
        /// <summary>
        /// Кол-во точек
        /// </summary>
        protected int count => _x.Length;
        protected double[] x => _x;
        protected double[] y => _y;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x0">Точка, в которой ищем значение</param>
        /// <returns></returns>
        public virtual double CalculateValue(double x0, bool extra = false)
        {
            return 0;
        }
    }
}
