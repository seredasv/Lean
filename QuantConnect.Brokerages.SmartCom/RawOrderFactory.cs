using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using TRL.Connect.Smartcom.Models;
using SCModels = QuantConnect.Brokerages.SmartCom.Models;
using QuantConnect.Brokerages.SmartCom.Models;
using QuantConnect.Orders;
//using TRL.Common.Models;
using SmartCOM3Lib;
//using TRL.Common;
//using TRL.Common.TimeHelpers;

namespace QuantConnect.Brokerages.SmartCom
{
    public class RawOrderFactory
    {
        //private ITradingSchedule schedule { get; set; }

        //public RawOrderFactory(ITradingSchedule schedule)
        //{
        //    this.schedule = schedule;
        //}

        public RawOrder Make(Order order)
            {
            RawOrder smartComOrder = new RawOrder();

            //smartComOrder.Portfolio = order.Portfolio;
            throw new NotImplementedException();
            smartComOrder.Portfolio = order.Tag;
            smartComOrder.Symbol = order.Symbol.ID.Symbol;
            ///Вид торговой операции. Принимает следующие значения: 
            ///StOrder_Action_Buy = 1, -Купить  
            ///stOrder_Action_Sell = 2, -Продать  
            ///stOrder_Action_Short = 3, -Открыть «короткую позицию»  
            ///StOrder_Action_Cover = 4 – Закрыть «короткую» позицию
            //smartComOrder.Action = Make(order.TradeAction);
            smartComOrder.Action = Make(order.Direction);
            //smartComOrder.Amount = order.Amount;
            smartComOrder.Amount = order.Quantity;
            //smartComOrder.Type = GetStOrderType(order.OrderType);
            smartComOrder.Type = GetStOrderType(order.Type);
            smartComOrder.Validity = MakeValidity(order.Duration);
            smartComOrder.Cookie = order.Id;
            smartComOrder.Id = smartComOrder.Cookie;
            smartComOrder.ExpirationDate = DateTime.Now.AddSeconds(60);

            if (smartComOrder.Type == StOrder_Type.StOrder_Type_Stop) {
                //smartComOrder.Stop = order.Stop;
                throw new NotImplementedException();
                smartComOrder.Stop = (double)order.Price;
            }
            else if (smartComOrder.Type == StOrder_Type.StOrder_Type_Limit)
                smartComOrder.Price = (double)order.Price;
            else
                smartComOrder.Price = 0;

            return smartComOrder;
        }
        
        private StOrder_Validity MakeValidity(OrderDuration duration)
        {
            if (duration == OrderDuration.GTC)
                return StOrder_Validity.StOrder_Validity_Gtc;
            return StOrder_Validity.StOrder_Validity_Day;
        }

        //private StOrder_Validity MakeValidity(DateTime date)
        //{
        //    if (date > this.schedule.SessionEnd)
        //        return StOrder_Validity.StOrder_Validity_Gtc;
        //    return StOrder_Validity.StOrder_Validity_Day;
        //}

        private static StOrder_Type GetStOrderType(OrderType type)
        {
            //if (type == OrderType.Stop)
            if (type == OrderType.StopMarket)
                return StOrder_Type.StOrder_Type_Stop;

            if (type == OrderType.Limit)
                return StOrder_Type.StOrder_Type_Limit;

            return StOrder_Type.StOrder_Type_Market;
        }

        //private static StOrder_Action Make(TradeAction action)
        //{
        //    if (action.Equals(TradeAction.Buy))
        //        return StOrder_Action.StOrder_Action_Buy;

        //    return StOrder_Action.StOrder_Action_Sell;
        //}
        private static StOrder_Action Make(OrderDirection action)
        {
            if (action.Equals(OrderDirection.Buy))
                return StOrder_Action.StOrder_Action_Buy;

            return StOrder_Action.StOrder_Action_Sell;
        }

        private static StOrder_Type Make(double price)
        {
            if (price > 0)
                return StOrder_Type.StOrder_Type_Limit;

            return StOrder_Type.StOrder_Type_Market;
        }
    }
}
