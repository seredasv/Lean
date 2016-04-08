/*
 * QUANTCONNECT.COM - Democratizing Finance, Empowering Individuals.
 * Lean Algorithmic Trading Engine v2.0. Copyright 2014 QuantConnect Corporation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*/

using System;
using System.Collections.Generic;
using QuantConnect.Interfaces;
using QuantConnect.Packets;

namespace QuantConnect.Brokerages.SmartCom
{
    /// <summary>
    /// Provides a base implementation of IBrokerageFactory that provides a helper for reading data from a job's brokerage data dictionary
    /// </summary>
    public abstract class BrokerageSmartComFactory : IBrokerageFactory
    {
        private readonly Type _brokerageType;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the type of brokerage produced by this factory
        /// </summary>
        public Type BrokerageType
        {
            get { return _brokerageType; }
        }

        /// <summary>
        /// Gets the brokerage data required to run the brokerage from configuration/disk
        /// </summary>
        /// <remarks>
        /// The implementation of this property will create the brokerage data dictionary required for
        /// running live jobs. See <see cref="IJobQueueHandler.NextJob"/>
        /// </remarks>
        public virtual Dictionary<string, string> BrokerageData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a brokerage model that can be used to model this brokerage's unique
        /// behaviors
        /// </summary>
        public virtual IBrokerageModel BrokerageModel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets a map of the default markets to be used for each security type
        /// </summary>
        public virtual IReadOnlyDictionary<SecurityType, string> DefaultMarkets
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Creates a new IBrokerage instance
        /// </summary>
        /// <param name="job">The job packet to create the brokerage for</param>
        /// <param name="algorithm">The algorithm instance</param>
        /// <returns>A new brokerage instance</returns>
        public virtual IBrokerage CreateBrokerage(LiveNodePacket job, IAlgorithm algorithm)
        {
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrokerageSmartComFactory"/> class for the specified <paramref name="brokerageType"/>
        /// </summary>
        /// <param name="brokerageType">The type of brokerage created by this factory</param>
        protected BrokerageSmartComFactory(Type brokerageType)
        {
            _brokerageType = brokerageType;
        }
        
        /// <summary>
        /// Reads a value from the brokerage data, adding an error if the key is not found
        /// </summary>
        //protected static T Read<T>(IReadOnlyDictionary<string, string> brokerageData, string key, ICollection<string> errors) 
        //    where T : IConvertible
        //{
        //    string value;
        //    if (!brokerageData.TryGetValue(key, out value))
        //    {
        //        errors.Add("BrokerageFactory.CreateBrokerage(): Missing key: " + key);
        //        return default(T);
        //    }

        //    try
        //    {
        //        return value.ConvertTo<T>();
        //    }
        //    catch (Exception err)
        //    {
        //        errors.Add(string.Format("BrokerageFactory.CreateBrokerage(): Error converting key '{0}' with value '{1}'. {2}", key, value, err.Message));
        //        return default(T);
        //    }
        //}
    }
}