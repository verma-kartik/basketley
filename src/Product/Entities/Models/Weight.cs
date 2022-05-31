using Entities.Models.Enums;

namespace Entities.Models
{
    public class Weight
    {
        public string Unit { get; set; }
        public double Value { get; set; }

        public Weight() : this(WeightUnit.G.ToString(), 0) { }

        public Weight(string unit, double value)
        {
            Unit = unit;
            Value = value;
        }
    }
}
