using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDHomeworkDay1
{
    public class CalculateSum
    {
        private IEnumerable<object> Entities;
        private string Column;
        private int GroupSize;

        public CalculateSum()
        {
        }

        public CalculateSum(IEnumerable<object> entities, string column, int groupSize)
        {
            this.Entities = entities;

            var t = this.Entities.GetType().GetGenericArguments().FirstOrDefault();
            var properties = t.GetProperties().Select(x => x.Name);

            if (t != null && properties.Contains(column))
            {
                this.Column = column;
            }
            else
            {
                throw new ArgumentException();
            }

            if (groupSize > 1)
            {
                this.GroupSize = groupSize;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public List<int> CalculateSumByColumnAndGroupSize()
        {
            List<int> result = new List<int>();

            for (int i = 0; i * GroupSize < this.Entities.Count(); i++)
            {
                var sum = this.Entities.Skip(i * GroupSize).Take(GroupSize).Sum(x => Convert.ToInt32(GetPropValue(x, Column)));
                result.Add(sum);
            }

            return result;
        }

        public object GetPropValue(object src, string propName)
        {
            //source:https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection-in-c-sharp
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }

    public class Entity
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }
    }
}
