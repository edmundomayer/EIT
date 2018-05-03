using System;
using System.Linq.Expressions;

namespace es.eit.application.Helpers
{
    public static class ModelVisitor
    {
        public static Expression<Func<NewParam, TResult>> ConvertToModelExpression<NewParam, OldParam, TResult>( Expression<Func<OldParam, TResult>> expression )
            where NewParam : OldParam
        {
            var param = Expression.Parameter( typeof( NewParam ) );

            return Expression.Lambda<Func<NewParam, TResult>>(
                expression.Body.Replace( expression.Parameters[ 0 ], param )
                , param );
        }

        internal class ReplaceVisitor : ExpressionVisitor
        {
            private readonly Expression from, to;

            public ReplaceVisitor( Expression from, Expression to )
            {
                this.from = from;
                this.to = to;
            }

            public override Expression Visit( Expression node )
            {
                return node == from ? to : base.Visit( node );
            }
        }

        public static Expression Replace( this Expression expression,
                                                Expression searchEx,
                                                Expression replaceEx )
        {
            return new ReplaceVisitor( searchEx, replaceEx ).Visit( expression );
        }
    }
}
