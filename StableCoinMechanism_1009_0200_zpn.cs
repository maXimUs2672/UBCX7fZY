// 代码生成时间: 2025-10-09 02:00:25
// 使用C#和Unity框架创建的稳定币机制
// 文件名: StableCoinMechanism.cs

using System;

namespace StableCoinSystem
{
    /// <summary>
    /// 稳定币机制类，用于管理稳定币的发行与回收
    /// </summary>
    public class StableCoinMechanism
    {
        private double totalSupply; // 总发行量
        private double reserve; // 准备金
        private double issuanceRate; // 发行率
        private double redemptionRate; // 回收率
        private string currency; // 锚定的货币
        private string stableCoinSymbol; // 稳定币符号

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currency">锚定的货币</param>
        /// <param name="stableCoinSymbol">稳定币符号</param>
        /// <param name="initialSupply">初始发行量</param>
        public StableCoinMechanism(string currency, string stableCoinSymbol, double initialSupply)
        {
            this.currency = currency;
            this.stableCoinSymbol = stableCoinSymbol;
            this.totalSupply = initialSupply;
            this.reserve = 0;
            this.issuanceRate = 1;
            this.redemptionRate = 1;
        }

        /// <summary>
        /// 发行稳定币
        /// </summary>
        /// <param name="amount">发行数量</param>
        /// <returns>发行结果</returns>
        public string IssueStableCoin(double amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("发行数量必须为正数");
                }

                totalSupply += amount;
                reserve += amount;
                return $"成功发行 {amount} {stableCoinSymbol}";
            }
            catch (Exception ex)
            {
                return $"发行稳定币失败：{ex.Message}";
            }
        }

        /// <summary>
        /// 回收稳定币
        /// </summary>
        /// <param name="amount">回收数量</param>
        /// <returns>回收结果</returns>
        public string RedeemStableCoin(double amount)
        {
            try
            {
                if (amount <= 0 || amount > totalSupply)
                {
                    throw new ArgumentException("回收数量必须为正数且不超过总发行量");
                }

                totalSupply -= amount;
                reserve -= amount;
                return $"成功回收 {amount} {stableCoinSymbol}";
            }
            catch (Exception ex)
            {
                return $"回收稳定币失败：{ex.Message}";
            }
        }

        /// <summary>
        /// 获取总发行量
        /// </summary>
        /// <returns>总发行量</returns>
        public double GetTotalSupply()
        {
            return totalSupply;
        }

        /// <summary>
        /// 获取准备金
        /// </summary>
        /// <returns>准备金</returns>
        public double GetReserve()
        {
            return reserve;
        }
    }
}
