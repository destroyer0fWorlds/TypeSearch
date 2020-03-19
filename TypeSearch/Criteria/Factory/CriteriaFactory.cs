using System.Collections.Generic;

namespace TypeSearch.Criteria.Factory
{
    class CriteriaFactory<T, TResult> : ICriteriaFactory<T, TResult>
        where T : class
    {
        protected LogicalOperator Operator { get; private set; }

        protected string PropertyName { get; private set; }

        public CriteriaFactory(string propertyName, LogicalOperator @operator)
        {
            this.PropertyName = propertyName;
            this.Operator = @operator;
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateBetweenCriteria(TResult startValue, TResult endValue)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.PropertyName,
                    Operator = RangeOperator.Between,
                    StartValue = startValue,
                    EndValue = endValue
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateContainsCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Like,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateEndsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.EndsWith,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateFalseCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = false
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateGreaterThanCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.GreaterThan,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateGreaterThanOrEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.GreaterThanOrEqualTo,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual FilterCriteria<T> CreateInCriteria(IEnumerable<TResult> values)
        {
            var inList = new FilterCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.Or,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.PropertyName,
                        Operator = SingleOperator.Equals,
                        Value = value
                    }
                });
            }
            return inList;
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateLessThanCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.LessThan,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateLessThanOrEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.LessThanOrEqualTo,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotBetweenCriteria(TResult startValue, TResult endValue)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                RangeCriterion = new RangeCriterion()
                {
                    Name = this.PropertyName,
                    Operator = RangeOperator.NotBetween,
                    StartValue = startValue,
                    EndValue = endValue
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotContainsCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.NotLike,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotEndsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.DoesNotEndWith,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotEqualToCriteria(TResult value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.NotEquals,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual FilterCriteria<T> CreateNotInCriteria(IEnumerable<TResult> values)
        {
            var inList = new FilterCriteria<T>();
            foreach (var value in values)
            {
                inList.Criteria.Add(new CriteriaContainer<T>()
                {
                    Operator = LogicalOperator.And,
                    SingleCriterion = new SingleCriterion<T>()
                    {
                        Name = this.PropertyName,
                        Operator = SingleOperator.NotEquals,
                        Value = value
                    }
                });
            }
            return inList;
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotNullCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.IsNotNull
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNotStartsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.DoesNotStartWith,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateNullCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.IsNull
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateStartsWithCriteria(string value)
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.StartsWith,
                    Value = value
                }
            };
        }

        /// <inheritdoc />
        public virtual CriteriaContainer<T> CreateTrueCriteria()
        {
            return new CriteriaContainer<T>()
            {
                Operator = this.Operator,
                SingleCriterion = new SingleCriterion<T>()
                {
                    Name = this.PropertyName,
                    Operator = SingleOperator.Equals,
                    Value = true
                }
            };
        }
    }
}
