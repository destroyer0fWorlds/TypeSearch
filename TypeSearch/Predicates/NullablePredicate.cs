using TypeSearch.Criteria;

namespace TypeSearch.Predicates
{
    class NullablePredicate : IPredicate
    {
        private readonly string _propertyName;
        private readonly string _value;
        private readonly SingleOperator _operator;

        public NullablePredicate(string propertyName, string value, SingleOperator @operator)
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
                case SingleOperator.StartsWith:
                    predicate = $"({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).StartsWith({_value})";
                    break;
                case SingleOperator.EndsWith:
                    predicate = $"({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).EndsWith({_value})";
                    break;
                case SingleOperator.Like:
                    predicate = $"({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).Contains({_value})";
                    break;
                case SingleOperator.DoesNotStartWith:
                    predicate = $"!({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).StartsWith({_value})";
                    break;
                case SingleOperator.DoesNotEndWith:
                    predicate = $"!({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).EndsWith({_value})";
                    break;
                case SingleOperator.NotLike:
                    predicate = $"!({_propertyName} == null ? string.Empty : {_propertyName}.ToString()).Contains({_value})";
                    break;
            }
            return predicate;
        }
    }
}
