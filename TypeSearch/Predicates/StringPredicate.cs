using TypeSearch.Criteria;

namespace TypeSearch.Predicates
{
    class StringPredicate : IPredicate
    {
        private readonly string _propertyName;
        private readonly string _value;
        private readonly SingleOperator _operator;

        public StringPredicate(string propertyName, string value, SingleOperator @operator)
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
                    predicate = $"({_propertyName} ?? string.Empty).StartsWith({_value})";
                    break;
                case SingleOperator.EndsWith:
                    predicate = $"({_propertyName} ?? string.Empty).EndsWith({_value})";
                    break;
                case SingleOperator.Like:
                    predicate = $"({_propertyName} ?? string.Empty).Contains({_value})";
                    break;
                case SingleOperator.DoesNotStartWith:
                    predicate = $"!({_propertyName} ?? string.Empty).StartsWith({_value})";
                    break;
                case SingleOperator.DoesNotEndWith:
                    predicate = $"!({_propertyName} ?? string.Empty).EndsWith({_value})";
                    break;
                case SingleOperator.NotLike:
                    predicate = $"!({_propertyName} ?? string.Empty).Contains({_value})";
                    break;
            }
            return predicate;
        }
    }
}
