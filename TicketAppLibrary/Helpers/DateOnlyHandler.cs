using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAppLibrary.Helpers
{
    public class DateOnlyHandler : SqlMapper.TypeHandler<DateOnly>
    {

        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value.ToDateTime(TimeOnly.MinValue);
        }

        public override DateOnly Parse(object value)
        {
            return DateOnly.FromDateTime((DateTime)value);
        }


    }
}
