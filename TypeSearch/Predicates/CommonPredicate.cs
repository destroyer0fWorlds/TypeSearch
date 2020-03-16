using TypeSearch.Criteria;

namespace TypeSearch.Predicates
{
    class CommonPredicate : IPredicate
    {
        private readonly string _propertyName;
        private readonly string _value;
        private readonly SingleOperator _operator;

        public CommonPredicate(string propertyName, string value, SingleOperator @operator)
        {
            _propertyName = propertyName;
            _value = value;
            _operator = @operator;
        }

        public string Create()
        {
            string predicate = string.Empty;
            switch (_operator)
            {
                case SingleOperator.Equals:
                    predicate = $"{_propertyName} == {_value}";
                    break;
                case SingleOperator.NotEquals:
                    predicate = $"{_propertyName} != {_value}";
                    break;
                case SingleOperator.GreaterThan:
                    predicate = $"{_propertyName} > {_value}";
                    break;
                case SingleOperator.GreaterThanOrEqualTo:
                    predicate = $"{_propertyName} >= {_value}";
                    break;
                case SingleOperator.LessThan:
                    predicate = $"{_propertyName} < {_value}";
                    break;
                case SingleOperator.LessThanOrEqualTo:
                    predicate = $"{_propertyName} <= {_value}";
                    break;
                case SingleOperator.IsNull:
                    predicate = $"{_propertyName} == {_value}";
                    break;
                case SingleOperator.IsNotNull:
                    predicate = $"{_propertyName} != {_value}";
                    break;
            }
            return predicate;
        }
    }
}
