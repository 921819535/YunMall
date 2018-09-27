﻿using System.Collections.Generic;
using YunMall.Entity.db;

namespace YunMall.Web.IDAL.finance {
    public interface IAccountsRepository : IAbsBaseRepository
    {
        /// <summary>
        /// 查询分页总数
        /// </summary>
        /// <param name="state"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        int SelectLimitCount(int state, string beginTime, string endTime, string where);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="state"></param>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        List<Accounts> SelectLimit(int page, string limit, int state, string beginTime, string endTime, string where);
    }
}